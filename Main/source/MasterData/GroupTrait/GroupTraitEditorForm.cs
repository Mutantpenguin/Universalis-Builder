using System;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class GroupTraitEditorForm : Form
    {
        public GroupTraitEditorForm( GroupTrait groupTrait )
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            m_originalGroupTrait = groupTrait;

            m_modifiedGroupTrait = new GroupTrait( groupTrait );

            groupTraitBindingSource.DataSource = m_modifiedGroupTrait;


            toolStripComboBoxFaction.ComboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
            toolStripComboBoxFaction.ComboBox.SelectedValueChanged += ComboBox_SelectedValueChanged;
            toolStripComboBoxFaction.ComboBox.DataSource = Enum.GetValues( typeof( EPermissionType ) );

            toolStripComboBoxFaction.ComboBox.SelectedItem = m_modifiedGroupTrait.FactionPermissions?.PermissionType ?? EPermissionType.None;
            
            RefreshGridViews();
        }

        private readonly GroupTrait m_originalGroupTrait;
        private GroupTrait m_modifiedGroupTrait;

        private void RefreshGridViews()
        {
            factionsBindingSource.DataSource = m_modifiedGroupTrait.FactionPermissions?.Values.OrderBy( x => x.Name )
                                                                                              .ToList();
        }

            private void ComboBox_SelectionChangeCommitted( object sender, EventArgs e )
        {
            switch( (EPermissionType)toolStripComboBoxFaction.SelectedItem )
            {
                case EPermissionType.None:
                    m_modifiedGroupTrait.FactionPermissions = null;
                    break;

                default:
                    if( m_modifiedGroupTrait.FactionPermissions != null )
                    {
                        m_modifiedGroupTrait.FactionPermissions.PermissionType = (EPermissionType)toolStripComboBoxFaction.SelectedItem;
                    }
                    else
                    {
                        m_modifiedGroupTrait.FactionPermissions = new PermissionSet<Faction>( (EPermissionType)toolStripComboBoxFaction.SelectedItem );
                    }
                    break;
            }
        }

        private void ComboBox_SelectedValueChanged( object sender, EventArgs e )
        {
            if( ( m_modifiedGroupTrait.FactionPermissions == null )
                ||
                ( m_modifiedGroupTrait.FactionPermissions.PermissionType == EPermissionType.None ) )
            {
                toolStripButtonFactionDelete.Visible = false;
                toolStripButtonFactionAdd.Visible = false;
                dataGridViewFaction.Visible = false;
            }
            else
            {
                toolStripButtonFactionDelete.Visible = true;
                toolStripButtonFactionAdd.Visible = true;
                dataGridViewFaction.Visible = true;
            }
        }

        private bool mandatoryFieldsFilled()
        {
            if( String.IsNullOrEmpty( textBoxName.Text ) )
            {
                MessageBox.Show( "Name ist leer, bitte angeben!" );
                return ( false );
            }

            if( String.IsNullOrEmpty( textBoxRules.Text ) )
            {
                MessageBox.Show( "Regeln sind leer, bitte angeben!" );
                return ( false );
            }

            if( !String.IsNullOrEmpty( textBoxRules.Text )
                &&
                ( numericUpDownPoints.Value == 0 ) )
            {
                MessageBox.Show( "Achtung, die zusätzlichen Punkte stehen auf '0', obwohl Regeln eingetragen wurden!" );
            }

            if( String.IsNullOrEmpty( textBoxRules.Text )
                &&
                ( numericUpDownPoints.Value > 0 ) )
            {
                MessageBox.Show( "Achtung, es sind keine Regeln eingetragen, die zusätzlichen Punkte stehen aber nicht auf '0'!" );
            }

            return ( true );
        }

        private void GroupTraitEditorForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            GroupTrait groupTraitModified = (GroupTrait)groupTraitBindingSource.DataSource;

            if( !groupTraitModified.Equals( m_originalGroupTrait ) )
            {
                switch( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3 ) )
                {
                    case DialogResult.Yes:
                        if( mandatoryFieldsFilled() )
                        {
                            m_originalGroupTrait.Set( groupTraitModified );
                            MasterDataStorage.GroupTrait.Save( m_originalGroupTrait );
                        }
                        else
                        {
                            if( MessageBox.Show( "Es fehlen noch Pflichtangaben! Änderungen verwerfen?", "Pflichtangaben fehlen", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2 ) == DialogResult.No )
                            {
                                e.Cancel = true;
                            }
                        }
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void toolStripButtonSave_Click( object sender, EventArgs e )
        {
            if( mandatoryFieldsFilled() )
            {
                m_originalGroupTrait.Set( (GroupTrait)groupTraitBindingSource.DataSource );
                MasterDataStorage.GroupTrait.Save( m_originalGroupTrait );
            }
        }

        private void TraitEditorForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void toolStripButtonFactionDelete_Click( object sender, EventArgs e )
        {
            if( dataGridViewFaction.SelectedRows.Count > 0 )
            {
                var faction = (Faction)dataGridViewFaction.SelectedRows[ 0 ].DataBoundItem;
                m_modifiedGroupTrait.FactionPermissions.Values.Remove( faction );

                RefreshGridViews();
            }
        }

        private void toolStripButtonFactionAdd_Click( object sender, EventArgs e )
        {
            using( FactionSelectionForm factionSelectionForm = new FactionSelectionForm( m_modifiedGroupTrait.FactionPermissions?.Values.ToList() ) )
            {
                if( factionSelectionForm.ShowDialog( this ) == DialogResult.OK )
                {
                    if( factionSelectionForm.SelectedFaction != null )
                    {
                        m_modifiedGroupTrait.FactionPermissions.Values.Add( factionSelectionForm.SelectedFaction );

                        RefreshGridViews();
                    }
                }
            }
        }
    }
}

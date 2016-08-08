using System;
using System.Linq;
using System.Windows.Forms;

namespace Tesserakt
{
    public partial class TraitEditorForm : Form
    {
        public TraitEditorForm( Trait trait )
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            eTraitLevelBindingSource.DataSource = TraitLevel.ELevelList;

            m_originalTrait = trait;

            Trait modifiedTrait = new Trait( trait );

            traitBindingSource.DataSource = modifiedTrait;

            comboBoxType.SelectedItem = modifiedTrait.Type;

            updateLevels();
        }

        private readonly Trait m_originalTrait;

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

            Trait traitModified = (Trait)traitBindingSource.DataSource;

            if( traitModified.TraitLevelList.Count == 0 )
            {
                MessageBox.Show( "Sie müssen mindestens 1 Stufe anlegen!" );
                return ( false );
            }

            foreach( TraitLevel traitLevel in traitModified.TraitLevelList )
            {
                if( traitLevel.Points == 0 )
                {
                    MessageBox.Show( "Achtung, die Punkte bei mindestens einer Stufe stehen auf '0'!" );
                    break;
                }
            }

            if( traitModified.TraitLevelList.Find( x => x.Level == TraitLevel.ELevel.Kein ) != null )
            {
                if( traitModified.TraitLevelList.Find( x => x.Level != TraitLevel.ELevel.Kein ) != null )
                {
                    MessageBox.Show( $"Achtung, Sie haben die Stufe '{TraitLevel.ELevel.Kein.ToString()}' mit mindestens einer Anderen kombiniert!" );
                    return ( false );
                }
            }
            else
            {
                foreach( TraitLevel.ELevel eLevel in TraitLevel.ELevelList )
                {
                    if( traitModified.TraitLevelList.Count( x => x.Level == eLevel ) > 1 )
                    {
                        MessageBox.Show( $"Achtung, Sie haben die Stufe '{eLevel.ToString()}' mehr als 1 Mal verwendet!" );
                        return ( false );
                    }
                }
            }

            return ( true );
        }

        private void TraitEditorForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            Trait traitModified = (Trait)traitBindingSource.DataSource;

            if( !traitModified.Equals( m_originalTrait ) )
            {
                switch( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3 ) )
                {
                    case DialogResult.Yes:
                        if( mandatoryFieldsFilled() )
                        {
                            m_originalTrait.Set( traitModified );
                            TraitStorage.Save( m_originalTrait );
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
                if( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    m_originalTrait.Set( (Trait)traitBindingSource.DataSource );
                    TraitStorage.Save( m_originalTrait );
                }
            }
        }

        private void TraitEditorForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void updateLevels()
        {
            Trait trait = (Trait)traitBindingSource.DataSource;

            if( null != trait.TraitLevelList )
            {
                traitLevelsBindingSource.DataSource = trait.TraitLevelList.OrderBy( x => (int)x.Level )
                                                                          .ToList();
            }

            dataGridViewLevel.ClearSelection();
        }

        private void comboBoxType_SelectionChangeCommitted( object sender, EventArgs e )
        {
            ( (Trait)traitBindingSource.DataSource ).Type = (string)comboBoxType.SelectedItem;
        }

        private void dataGridViewLevel_CurrentCellDirtyStateChanged( object sender, EventArgs e )
        {
            if( dataGridViewLevel.CurrentCell.ColumnIndex == levelDataGridViewComboBoxColumn.Index )
            {
                dataGridViewLevel.CommitEdit( DataGridViewDataErrorContexts.Commit );
            }
        }

        private void toolStripButtonRemoveLevel_Click( object sender, EventArgs e )
        {
            if( dataGridViewLevel.SelectedRows.Count > 0 )
            {
                TraitLevel traitLevel = ( (TraitLevel)( dataGridViewLevel.Rows[ dataGridViewLevel.SelectedRows[ 0 ].Index ].DataBoundItem ) );

                var actorsWithTraitLevel = ActorStorage.Instance.ActorsWithTraitLevel( m_originalTrait, traitLevel );

                if( actorsWithTraitLevel.Any() )
                {
                    using( ActorDisplayForm actorDisplay = new ActorDisplayForm( actorsWithTraitLevel ) )
                    {
                        actorDisplay.ShowDialog( this );
                    }
                }
                else
                {
                    ( (Trait)traitBindingSource.DataSource ).TraitLevelList.RemoveAll( s => s == traitLevel );

                    updateLevels();
                }
            }
        }

        private void toolStripButtonAddLevel_Click( object sender, EventArgs e )
        {
            Trait traitModified = (Trait)traitBindingSource.DataSource;

            if( traitModified.TraitLevelList.Count == 0 )
            {
                traitModified.TraitLevelList.Add( new TraitLevel()
                {
                    Level = TraitLevel.ELevel.Kein
                } );

                updateLevels();
            }
            else
            {
                foreach( TraitLevel.ELevel eLevel in TraitLevel.ELevelList.OrderBy( x => x ) )
                {
                    if( traitModified.TraitLevelList.Find( x => x.Level == eLevel ) == null )
                    {
                        traitModified.TraitLevelList.Add( new TraitLevel()
                        {
                            Level = eLevel
                        } );
                        updateLevels();
                        break;
                    }
                }
            }
        }

        private void toolStripButtonUsage_Click( object sender, EventArgs e )
        {
            if( dataGridViewLevel.SelectedRows.Count > 0 )
            {
                using( ActorDisplayForm actorDisplay = new ActorDisplayForm( ActorStorage.Instance.ActorsWithTraitLevel( m_originalTrait, (TraitLevel)dataGridViewLevel.SelectedRows[ 0 ].DataBoundItem ) ) )
                {
                    actorDisplay.ShowDialog( this );
                }
            }
        }

        private void toolStripButtonInsertLevelString_Click( object sender, EventArgs e )
        {
            textBoxRules.Paste( Trait.LevelString );
        }

        private void toolStripButton1_Click( object sender, EventArgs e )
        {
            using( ActorDisplayForm actorDisplay = new ActorDisplayForm( ActorStorage.Instance.ActorsWithTrait( m_originalTrait ) ) )
            {
                actorDisplay.ShowDialog( this );
            }
        }
    }
}

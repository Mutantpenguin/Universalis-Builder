using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class AddActorToGroupForm : Form
    {
        public AddActorToGroupForm( Guid factionID )
        {
            InitializeComponent();

            m_factionID = factionID;

            filterType.ComboBox.DataSource = Profile.ETypeList;
            filterType.ComboBox.SelectionChangeCommitted += FilterType_SelectionChangeCommitted;

            updateDataGridViewActors();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private readonly Guid m_factionID;

        private void updateDataGridViewActors()
        {
            actorBindingSource.DataSource = MasterDataStorage.Actor.Actors.Where( x => x.Faction.ID == m_factionID )
                                                                          .Where( s => filterType.Enabled ? s.Archetype.Profile.Type == ( (Profile.EType)filterType.ComboBox.SelectedValue ) : true )
                                                                          .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                          .OrderBy( x => x.Name )
                                                                          .ToList();
        }

        private void buttonCancel_Click( object sender, EventArgs e )
        {
            Close();
        }

        private void buttonOk_Click( object sender, EventArgs e )
        {
            CloseWithSelected();
        }

        private void CloseWithSelected()
        {
            SelectedActors = new List<Actor>();

            for( int i = 0; i < dataGridViewActors.SelectedRows.Count; i++ )
            {
                SelectedActors.Add( (Actor)dataGridViewActors.Rows[ dataGridViewActors.SelectedRows[ i ].Index ].DataBoundItem );
            }

            Close();
        }

        public List<Actor> SelectedActors
        {
            get;
            private set;
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            updateDataGridViewActors();
        }

        private void FilterType_SelectionChangeCommitted( object sender, EventArgs e )
        {
            updateDataGridViewActors();
        }

        private void dataGridViewArmor_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                SelectedActors = new List<Actor>
                {
                    (Actor)dataGridViewActors.Rows[ e.RowIndex ].DataBoundItem
                };

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void dataGridViewActors_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Actor actor = (Actor)dataGridViewActors.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = actor.Name + ":" + Environment.NewLine + ToolTipHelper.FormatMaxWidth( actor.Description );
            }
        }

        private void checkBoxFilterType_Click( object sender, EventArgs e )
        {
            filterType.Enabled = !filterType.Enabled;

            checkBoxFilterType.Image = checkBoxFilterType.Checked ? Properties.Resources.ui_check_box : Properties.Resources.ui_check_box_uncheck;

            updateDataGridViewActors();
        }

        private void dataGridViewActors_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                this.DialogResult = DialogResult.OK;
                e.Handled = true;
                CloseWithSelected();
            }
        }

        private void toolStripTextBoxSearch_KeyDown( object sender, KeyEventArgs e )
        {
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewActors, e.KeyCode ) )
            {
                e.Handled = true;
            }
        }
    }
}

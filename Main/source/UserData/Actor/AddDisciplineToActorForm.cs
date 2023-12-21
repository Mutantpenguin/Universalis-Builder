using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class AddDisciplineToActorForm : Form
    {
        public AddDisciplineToActorForm( Faction faction, Archetype archetype, List<Discipline> disciplinesList )
        {
            InitializeComponent();

            m_faction = faction;
            m_archetype = archetype;
            m_disciplineList = disciplinesList;

            updateDataGridViewDisciplines();

            toolStripTextBoxSearch.TextBox.Select();

            this.Icon = System.Drawing.Icon.FromHandle( Properties.Resources.icon_discipline.GetHicon() );
        }

        private readonly Faction m_faction;
        private readonly Archetype m_archetype;
        private readonly List<Discipline> m_disciplineList;

        public List<Discipline> SelectedDisciplines
        {
            get;
            private set;
        }

        private void updateDataGridViewDisciplines()
        {
            disciplineBindingSource.DataSource = MasterDataStorage.Discipline.Disciplines.Where( s => s.Active )
                                                                          .Where( s => !m_disciplineList.Any( x => x.ID == s.ID ) )
                                                                          .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                          .Where( s => s.Permissions?.Granted(m_faction, m_archetype ) ?? true )
                                                                          .OrderBy( x => x.Name )
                                                                          .ToList();
        }

        private void buttonOk_Click( object sender, EventArgs e )
        {
            CloseWithSelected();
        }

        private void CloseWithSelected()
        {
            SelectedDisciplines = new List<Discipline>();

            for( int i = 0; i < dataGridViewDisciplines.SelectedRows.Count; i++ )
            {
                SelectedDisciplines.Add( (Discipline)dataGridViewDisciplines.Rows[ dataGridViewDisciplines.SelectedRows[ i ].Index ].DataBoundItem );
            }

            Close();
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            updateDataGridViewDisciplines();
        }

        private void toolStripMenuItemPositives_CheckedChanged( object sender, EventArgs e )
        {
            updateDataGridViewDisciplines();
        }

        private void toolStripMenuItemNegatives_CheckedChanged( object sender, EventArgs e )
        {
            updateDataGridViewDisciplines();
        }

        private void toolStripMenuItemNeutrals_CheckedChanged( object sender, EventArgs e )
        {
            updateDataGridViewDisciplines();
        }

        private void dataGridViewDisciplines_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                SelectedDisciplines = new List<Discipline>
                {
                    (Discipline)dataGridViewDisciplines.Rows[ e.RowIndex ].DataBoundItem
                };

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void dataGridViewDisciplines_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Discipline discipline = (Discipline)dataGridViewDisciplines.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = discipline.Name + ":" + Environment.NewLine + ToolTipHelper.FormatMaxWidth( discipline.Description );
            }
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void dataGridViewDisciplines_KeyDown( object sender, KeyEventArgs e )
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
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewDisciplines, e.KeyCode ) )
            {
                e.Handled = true;
            }
        }

        private void dataGridViewDisciplines_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewDisciplines );
        }
    }
}

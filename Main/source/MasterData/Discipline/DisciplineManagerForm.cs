using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class DisciplineManagerForm : Form
    {
        public DisciplineManagerForm()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            refreshGridView();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private void refreshGridView()
        {
            /* TODO
            List<Discipline> disciplines = MasterDataStorage.Discipline.Disciplines.Where( s => s.Active )
                                                                                   .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                                   .OrderBy( x => x.Name )
                                                                                   .ToList();

            disciplineBindingSource.DataSource = disciplines;
            dataGridViewDisciplines.ClearSelection();

            toolStripStatusLabelCount.Text = $"Anzahl: {disciplines.Count}";
            */
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            refreshGridView();
        }

        private void toolStripButtonAddDiscipline_Click( object sender, EventArgs e )
        {
            /* TODO
            Discipline discipline = DisciplineStorage.Create();

            toolStripTextBoxSearch.Text = String.Empty;

            editDiscipline( discipline );

            refreshGridView();

            dataGridViewDisciplines.ClearSelection();
            foreach( DataGridViewRow row in dataGridViewDisciplines.Rows )
            {
                if( discipline.ID == ( (Discipline)row.DataBoundItem ).ID )
                {
                    row.Selected = true;
                    break;
                }
            }
            */
        }

        private void toolStripButtonDeleteDiscipline_Click( object sender, EventArgs e )
        {
            /* TODO
            if( dataGridViewDisciplines.SelectedCells.Count > 0 )
            {
                Discipline discipline = (Discipline)dataGridViewDisciplines.SelectedRows[ 0 ].DataBoundItem;

                if( MessageBox.Show( $"Disziplin '{discipline.Name}' wirklich löschen?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    MasterDataStorage.Discipline.Delete( discipline );

                    refreshGridView();
                }
            }
            */
        }

        private void dataGridViewDiscipline_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            /* TODO
            if( -1 != e.RowIndex )
            {
                editDiscipline( (Discipline)dataGridViewDisciplines.Rows[ e.RowIndex ].DataBoundItem );
            }
            */
        }

        private void editDiscipline( Faction faction )
        {
            /* TODO
            using( DisciplineEditorForm disciplineEditorForm = new DisciplineEditorForm( discipline ) )
            {
                this.Hide();

                disciplineEditorForm.ShowDialog( this );

                this.Show();
            }

            disciplineBindingSource.ResetBindings( false );
            */
        }

        private void DisciplineManagerForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void dataGridViewDisciplines_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            /* TODO
            if( e.RowIndex > -1 )
            {
                Discipline discipline = (Discipline)dataGridViewDisciplines.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = ToolTipHelper.FormatMaxWidth( discipline.Description );
            }
            */
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void toolStripTextBoxSearch_KeyDown( object sender, KeyEventArgs e )
        {
            /* TODO
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewDisciplines, e.KeyCode ) )
            {
                e.Handled = true;
            }
            else if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editDiscipline( (Discipline)dataGridViewDisciplines.CurrentRow.DataBoundItem );
            }
            */
        }

        private void dataGridViewDisciplines_KeyDown( object sender, KeyEventArgs e )
        {
            /* TODO
            if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editDiscipline( (Discipline)dataGridViewDisciplines.CurrentRow.DataBoundItem );
            }
            */
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class DamageEffectManagerForm : Form
    {
        public DamageEffectManagerForm(Image icon)
        {
            InitializeComponent();

            this.Icon = Icon.FromHandle(((Bitmap)icon).GetHicon());

            refreshGridView();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private void dataGridViewDamageEffects_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                editDamageEffect( (DamageEffect)dataGridViewDamageEffects.Rows[ e.RowIndex ].DataBoundItem );
            }
        }

        private void editDamageEffect( DamageEffect damageEffect )
        {
            using( DamageEffectEditorForm damageEffectEditorForm = new DamageEffectEditorForm( damageEffect ) )
            {
                this.Hide();

                damageEffectEditorForm.ShowDialog( this );

                this.Show();
            }

            damageEffectBindingSource.ResetBindings( false );
        }

        private void toolStripButtonAddDamageEffect_Click( object sender, EventArgs e )
        {
            DamageEffect damageEffect = DamageEffectStorage.Create();

            toolStripTextBoxSearch.Text = String.Empty;

            editDamageEffect( damageEffect );

            refreshGridView();

            dataGridViewDamageEffects.ClearSelection();
            foreach( DataGridViewRow row in dataGridViewDamageEffects.Rows )
            {
                if( damageEffect.ID == ( (DamageEffect)row.DataBoundItem ).ID )
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        private void toolStripButtonDeleteDamageEffect_Click( object sender, EventArgs e )
        {
            if( dataGridViewDamageEffects.SelectedRows.Count > 0 )
            {
                DamageEffect damageEffect = (DamageEffect)dataGridViewDamageEffects.SelectedRows[ 0 ].DataBoundItem;

                if( MessageBox.Show( $"Schadenseffekt '{damageEffect.Name}' wirklich löschen?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    MasterDataStorage.DamageEffect.Delete( damageEffect );

                    refreshGridView();
                }
            }
        }

        private void refreshGridView()
        {
            List<DamageEffect> damageEffects = MasterDataStorage.DamageEffect.DamageEffects.Where( s => s.Active )
                                                                                           .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                                           .OrderBy( x => x.Name )
                                                                                           .ToList();

            damageEffectBindingSource.DataSource = damageEffects;
            dataGridViewDamageEffects.ClearSelection();

            toolStripStatusLabelCount.Text = $"Anzahl: {damageEffects.Count}";
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            refreshGridView();
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void dataGridViewDamageEffects_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                DamageEffect damageEffect = (DamageEffect)dataGridViewDamageEffects.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = ToolTipHelper.FormatMaxWidth( damageEffect.Description );
            }
        }

        private void DamageEffectManagerForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void toolStripTextBoxSearch_KeyDown( object sender, KeyEventArgs e )
        {
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewDamageEffects, e.KeyCode ) )
            {
                e.Handled = true;
            }
            else if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editDamageEffect( (DamageEffect)dataGridViewDamageEffects.CurrentRow.DataBoundItem );
            }
        }

        private void dataGridViewDamageEffects_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editDamageEffect( (DamageEffect)dataGridViewDamageEffects.CurrentRow.DataBoundItem );
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class DamageEffectSelectionForm : Form
    {
        public DamageEffectSelectionForm( List<DamageEffect> damageEffectList  )
        {
            InitializeComponent();

            damageEffectBindingSource.DataSource = MasterDataStorage.DamageEffect.DamageEffects.Where( s => damageEffectList.Find( x => x.ID == s.ID ) == null )
                                                                                               .OrderBy( x => x.Name )
                                                                                               .ToList();
        }

        public List<DamageEffect> SelectedDamageEffects
        {
            get;
            private set;
        }

        private void buttonOk_Click( object sender, EventArgs e )
        {
            SelectedDamageEffects = new List<DamageEffect>();

            for( int i = 0; i < dataGridViewDamageEffects.SelectedRows.Count; i++ )
            {
                SelectedDamageEffects.Add( (DamageEffect)dataGridViewDamageEffects.Rows[ dataGridViewDamageEffects.SelectedRows[ i ].Index ].DataBoundItem );
            }

            Close();
        }

        private void dataGridView1_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                SelectedDamageEffects = new List<DamageEffect>
                {
                    (DamageEffect)dataGridViewDamageEffects.Rows[e.RowIndex].DataBoundItem
                };

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}

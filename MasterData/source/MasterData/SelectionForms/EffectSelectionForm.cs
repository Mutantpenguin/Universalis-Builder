using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tesserakt
{
    public partial class EffectSelectionForm : Form
    {
        public EffectSelectionForm( List<DamageEffect> damageEffectList  )
        {
            InitializeComponent();

            List<DamageEffect> effectsList = new List<DamageEffect>();

            foreach( DamageEffect.EType type in DamageEffect.ETypelList.OrderBy( x => x.ToString() ) )
            {
                if( ( null == damageEffectList ) || ( null == damageEffectList.Find( x => x.Type == type ) ) )
                {
                    effectsList.Add( new DamageEffect { Type = type } );
                }
            }

            damageEffectBindingSource.DataSource = effectsList;
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
                SelectedDamageEffects = new List<DamageEffect>();
                SelectedDamageEffects.Add( (DamageEffect)dataGridViewDamageEffects.Rows[ e.RowIndex ].DataBoundItem );

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}

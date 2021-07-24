using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class DamageTypeSelectionForm : Form
    {
        public DamageTypeSelectionForm( List<DamageType> damageTypeList )
        {
            InitializeComponent();

            List<DamageType> typeList = new List<DamageType>();

            foreach( DamageType.EType type in DamageType.ETypeList.OrderBy( x => x.ToString() ) )
            {
                if( ( null == damageTypeList ) || ( null == damageTypeList.Find( x => x.Type == type ) ) )
                {
                    typeList.Add( new DamageType() { Type = type, Level = DamageType.ELevel.I } );
                }
            }

            damageTypeBindingSource.DataSource = typeList;
        }

        public List<DamageType> SelectedDamageTypes
        {
            get;
            private set;
        }

        private void buttonOk_Click( object sender, EventArgs e )
        {
            SelectedDamageTypes = new List<DamageType>();

            for( int i = 0; i < dataGridViewDamageTypes.SelectedRows.Count; i++ )
            {
                SelectedDamageTypes.Add( (DamageType)dataGridViewDamageTypes.Rows[ dataGridViewDamageTypes.SelectedRows[ i ].Index ].DataBoundItem );
            }

            Close();
        }

        private void dataGridViewDamageTypes_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                SelectedDamageTypes = new List<DamageType>
                {
                    (DamageType)dataGridViewDamageTypes.Rows[ e.RowIndex ].DataBoundItem
                };

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}

using System;
using System.Reflection;
using System.Windows.Forms;

namespace Universalis
{
    public static class DataGridViewHelper
    {
        public static bool HandleArrowUpDown( DataGridView dataGridView, Keys pressedKey )
        {
            if( dataGridView == null )
            {
                throw new System.ArgumentNullException( nameof( dataGridView ) );
            }

            if( dataGridView.CurrentRow != null )
            {
                int currentRowIndex = dataGridView.CurrentRow.Index;

                if( dataGridView.RowCount == 1 )
                {
                    dataGridView.CurrentRow.Selected = false;
                    dataGridView.CurrentCell = dataGridView.Rows[ currentRowIndex ].Cells[ 0 ];
                    dataGridView.CurrentRow.Selected = true;
                }
                else
                {
                    switch( pressedKey )
                    {
                        case Keys.Up:
                            if( currentRowIndex > 0 )
                            {
                                dataGridView.CurrentRow.Selected = false;
                                dataGridView.CurrentCell = dataGridView.Rows[ currentRowIndex - 1 ].Cells[ 0 ];
                                dataGridView.CurrentRow.Selected = true;
                            }
                            return ( false );

                        case Keys.Down:
                            if( currentRowIndex < ( dataGridView.RowCount - 1 ) )
                            {
                                dataGridView.CurrentRow.Selected = false;
                                dataGridView.CurrentCell = dataGridView.Rows[ currentRowIndex + 1 ].Cells[ 0 ];
                                dataGridView.CurrentRow.Selected = true;
                            }
                            return ( true );
                    }
                }
            }

            return ( false );
        }

        public static void MemberPropertyFormatter( DataGridViewCellFormattingEventArgs e, DataGridView dataGridView )
        {
            object dataBoundItem = dataGridView.Rows[ e.RowIndex ].DataBoundItem;
            string dataPropertyName = dataGridView.Columns[ e.ColumnIndex ].DataPropertyName;

            if( ( dataBoundItem != null ) && ( dataPropertyName.Contains( "." ) ) )
            {
                e.Value = BindMemberProperty( dataBoundItem, dataPropertyName );
            }
        }

        private static object BindMemberProperty( object property, string propertyName )
        {
            if( propertyName.Contains( "." ) )
            {
                string leftPropertyName = propertyName.Substring( 0, propertyName.IndexOf( "." ) );

                foreach( PropertyInfo propertyInfo in property.GetType().GetProperties() )
                {
                    if( propertyInfo.Name == leftPropertyName )
                    {
                        return ( BindMemberProperty( propertyInfo.GetValue( property, null ), propertyName.Substring( propertyName.IndexOf( "." ) + 1 ) ) );
                    }
                }
            }
            else
            {
                return ( property.GetType().GetProperty( propertyName ).GetValue( property, null ).ToString() );
            }

            return ( String.Empty );
        }
    }
}

using System.Windows.Forms;

namespace Tesserakt
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
    }
}

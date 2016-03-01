using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Tesserakt
{
    public partial class FactionEditorForm : Form
    {
        public FactionEditorForm( Faction faction )
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            m_originalFaction = faction;

            factionBindingSource.DataSource = new Faction( faction );

            comboBoxType.DataSource = Faction.ETypeList;
            comboBoxType.SelectedItem = faction.Type;
        }

        Faction m_originalFaction;

        private bool mandatoryFieldsFilled()
        {
            if( String.IsNullOrEmpty( textBoxName.Text ) )
            {
                MessageBox.Show( "Name ist leer, bitte angeben!" );
                return ( false );
            }

            if( String.IsNullOrEmpty( textBoxDescription.Text ) )
            {
                MessageBox.Show( "Beschreibung ist leer, bitte angeben!" );
                return ( false );
            }

            if( pictureBoxFactionIcon.Image == null )
            {
                MessageBox.Show( "Icon ist leer, bitte angeben!" );
                return ( false );
            }

            return ( true );
        }

        private void pictureBoxIcon_DoubleClick( object sender, EventArgs e )
        {
            using( OpenFileDialog iconFileDialog = new OpenFileDialog() )
            {
                iconFileDialog.InitialDirectory = Properties.Settings.Default.factionIconFilePath;

                if( iconFileDialog.ShowDialog() == DialogResult.OK )
                {
                    Properties.Settings.Default.factionIconFilePath = Path.GetDirectoryName( iconFileDialog.FileName );
                    Properties.Settings.Default.Save();

                    Image img = ImageHelper.CreateIconFromImage( ImageHelper.LoadImage( iconFileDialog.FileName ) );

                    if( img != null )
                    {
                        pictureBoxFactionIcon.Image = img;
                        ( (Faction)factionBindingSource.DataSource ).Icon = new Bitmap( img );
                    }
                }
            }
        }

        private void FactionEditorForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            Faction factionModified = (Faction)factionBindingSource.DataSource;

            if( !factionModified.Equals( m_originalFaction ) )
            {
                switch( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3 ) )
                {
                    case DialogResult.Yes:
                        if( mandatoryFieldsFilled() )
                        {
                            m_originalFaction.Set( factionModified );
                            FactionStorage.Save( m_originalFaction );
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
                    m_originalFaction.Set( (Faction)factionBindingSource.DataSource );
                    FactionStorage.Save( m_originalFaction );
                }
            }
        }

        private void FactionEditorForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void comboBoxType_SelectionChangeCommitted( object sender, EventArgs e )
        {
            ( (Faction)factionBindingSource.DataSource ).Type = (Faction.EType)comboBoxType.SelectedItem;
        }
    }
}

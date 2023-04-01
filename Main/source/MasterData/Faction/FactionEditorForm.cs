using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class FactionEditorForm : Form
    {
        public FactionEditorForm( Faction faction )
        {
            InitializeComponent();

            pictureBoxFactionIcon.AllowDrop = true;

            this.Icon = Properties.Resources.icon;

            m_originalFaction = faction;

            factionBindingSource.DataSource = new Faction( faction );

            comboBoxType.DataSource = MasterDataStorage.Faction.Factions.Select( x => x.Type )
                                                                        .Distinct()
                                                                        .OrderBy( x => x )
                                                                        .ToList();
            comboBoxType.SelectedItem = faction.Type;
        }

        private readonly Faction m_originalFaction;
        private bool m_dragndrop;

        private bool mandatoryFieldsFilled()
        {
            if( String.IsNullOrEmpty( textBoxName.Text ) )
            {
                MessageBox.Show( "Name ist leer, bitte angeben!" );
                return false;
            }

            if( String.IsNullOrEmpty( textBoxDescription.Text ) )
            {
                MessageBox.Show( "Beschreibung ist leer, bitte angeben!" );
                return false;
            }

            if( pictureBoxFactionIcon.Image == null )
            {
                MessageBox.Show( "Icon ist leer, bitte angeben!" );
                return false;
            }

            return true;
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

                    SetIconFromPath( iconFileDialog.FileName );
                }
            }
        }

        private void SetIconFromPath( String path )
        {
            var img = ImageHelper.CreateIconFromImage( ImageHelper.LoadImage( path ), withTransparency: false );

            if( img != null )
            {
                pictureBoxFactionIcon.Image = img;
                ( (Faction)factionBindingSource.DataSource ).Icon = new Bitmap( img );
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
                            MasterDataStorage.Faction.Save( m_originalFaction );
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
                m_originalFaction.Set( (Faction)factionBindingSource.DataSource );
                MasterDataStorage.Faction.Save( m_originalFaction );
            }
        }

        private void FactionEditorForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void FactionEditorForm_DragEnter( object sender, DragEventArgs e )
        {
            m_dragndrop = true;
            pictureBoxFactionIcon.Refresh();

            if( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FactionEditorForm_DragLeave( object sender, EventArgs e )
        {
            m_dragndrop = false;
            pictureBoxFactionIcon.Refresh();
        }

        private void FactionEditorForm_DragDrop( object sender, DragEventArgs e )
        {
            m_dragndrop = false;
            pictureBoxFactionIcon.Refresh();
        }

        private void pictureBoxFactionIcon_Paint( object sender, PaintEventArgs e )
        {
            if( m_dragndrop )
            {
                ControlPaint.DrawBorder( e.Graphics, e.ClipRectangle,
                          Color.Red, 3, ButtonBorderStyle.Solid,
                          Color.Red, 3, ButtonBorderStyle.Solid,
                          Color.Red, 3, ButtonBorderStyle.Solid,
                          Color.Red, 3, ButtonBorderStyle.Solid );
            }
            else
            {
                ControlPaint.DrawBorder( e.Graphics, e.ClipRectangle, this.BackColor, ButtonBorderStyle.None );
            }
        }

        private void pictureBoxFactionIcon_DragDrop( object sender, DragEventArgs e )
        {
            m_dragndrop = false;
            pictureBoxFactionIcon.Refresh();

            string[] s = (string[])e.Data.GetData( DataFormats.FileDrop, false );

            if( s.Length == 1 )
            {
                SetIconFromPath( s[0] );
            }
        }

        private void pictureBoxFactionIcon_DragEnter( object sender, DragEventArgs e )
        {
            m_dragndrop = true;
            pictureBoxFactionIcon.Refresh();

            if( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}

using System;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class DisciplineEditorForm : Form
    {
        public DisciplineEditorForm( Discipline discipline )
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            m_originalDiscipline = discipline;

            m_modifiedDiscipline = new Discipline( discipline );

            disciplineBindingSource.DataSource = m_modifiedDiscipline;

            if( null != m_modifiedDiscipline.Permissions )
            {
                toolStripButtonPermissions.Checked = true;
                toolStripButtonPermissions.Image = Properties.Resources.ui_check_box;

                textBoxPermissions.Text = m_modifiedDiscipline.Permissions.Summary();
            }
            else
            {
                toolStripButtonPermissionsEditor.Enabled = false;
                panelPermissions.Visible = false;
            }

            pictureBoxColor.BackColor = m_modifiedDiscipline.Color;

            updateGridViewPowers();
        }

        private void updateGridViewPowers()
        {
            powersBindingSource.DataSource = null;
            powersBindingSource.DataSource = m_modifiedDiscipline.Powers.ToList();

            dataGridViewPowers.ClearSelection();

            if( dataGridViewPowers.RowCount > 0 )
            {
                dataGridViewPowers.Rows[0].Selected = true;
            }
        }

        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                components?.Dispose();

                pictureBoxPower.Image?.Dispose();
            }

            base.Dispose( disposing );
        }

        private readonly Discipline m_originalDiscipline;
        private Discipline m_modifiedDiscipline;

        private bool mandatoryFieldsFilled()
        {
            if( String.IsNullOrEmpty( textBoxName.Text ) )
            {
                MessageBox.Show( "Name ist leer, bitte angeben!" );
                return false;
            }

            return true;
        }

        private void DisciplineEditorForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if( !m_modifiedDiscipline.Equals( m_originalDiscipline ) )
            {
                switch( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3 ) )
                {
                    case DialogResult.Yes:
                        if( mandatoryFieldsFilled() )
                        {
                            m_originalDiscipline.Set( m_modifiedDiscipline );
                            MasterDataStorage.Discipline.Save( m_originalDiscipline );
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
                m_originalDiscipline.Set( (Discipline)disciplineBindingSource.DataSource );
                MasterDataStorage.Discipline.Save( m_originalDiscipline );
            }
        }

        private void DisciplineEditorForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void openPermissionsEditor()
        {
            var discipline = (Discipline)disciplineBindingSource.DataSource;

            using( var permissionsEditor = new PermissionsEditor( discipline.Permissions ) )
            {
                if( permissionsEditor.ShowDialog( this ) == DialogResult.OK )
                {
                    discipline.Permissions = permissionsEditor.Permissions;
                    textBoxPermissions.Text = discipline.Permissions.Summary();
                    disciplineBindingSource.ResetBindings( false );
                }
            }
        }

        private void toolStripButtonPermissions_Click( object sender, EventArgs e )
        {
            var discipline = (Discipline)disciplineBindingSource.DataSource;

            if( toolStripButtonPermissions.Checked )
            {
                toolStripButtonPermissions.Image = Properties.Resources.ui_check_box;

                var permissions = new Permissions();

                discipline.Permissions = permissions;

                toolStripButtonPermissionsEditor.Enabled = true;
                panelPermissions.Visible = true;

                openPermissionsEditor();
            }
            else
            {
                toolStripButtonPermissions.Image = Properties.Resources.ui_check_box_uncheck;

                discipline.Permissions = null;

                toolStripButtonPermissionsEditor.Enabled = false;
                panelPermissions.Visible = false;

                textBoxPermissions.Text = String.Empty;

                disciplineBindingSource.ResetBindings( false );
            }
        }

        private void toolStripButtonPermissionsEditor_Click( object sender, EventArgs e )
        {
            openPermissionsEditor();
        }

        private void textBoxPermissions_TextChanged( object sender, EventArgs e )
        {
            var messageSize = TextRenderer.MeasureText( textBoxPermissions.Text,
                                                        textBoxPermissions.Font,
                                                        new System.Drawing.Size( textBoxPermissions.Width, 0 ) );

            textBoxPermissions.Height = messageSize.Height;
        }

        private void pictureBoxColor_MouseDoubleClick( object sender, MouseEventArgs e )
        {
            using( var colorDialog = new ColorDialog() )
            {
                if( colorDialog.ShowDialog() == DialogResult.OK )
                {
                    var color = colorDialog.Color;
                    pictureBoxColor.BackColor = color;
                    m_modifiedDiscipline.Color = color;

                    UpdateCard();
                }
            }
        }

        private void dataGridViewPowers_SelectionChanged( object sender, EventArgs e )
        {
            UpdateCard();
        }

        private void UpdateCard()
        {
            pictureBoxPower.Image?.Dispose();

            if( dataGridViewPowers.SelectedRows.Count > 0 )
            {
                Power power = (Power)dataGridViewPowers.SelectedRows[0].DataBoundItem;

                pictureBoxPower.Image = PowerCardPainter.GetBitmap( m_modifiedDiscipline, power );
            }
            else
            {
                pictureBoxPower.Image = null;
            }
        }
    }
}

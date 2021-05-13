using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    public class DamageEffectStorage
    {
        private const string s_folderName = "DamageEffects";

        private readonly string s_path;
        private readonly string s_pathTrash;

        public DamageEffectStorage( string path, BackgroundWorker backgroundWorker )
        {
            s_path = Path.Combine( path, Storage.dataSubfolderName, s_folderName );
            s_pathTrash = Path.Combine( path, Storage.trashSubfolderName, s_folderName );

            if( !Directory.Exists( s_path ) )
            {
                Directory.CreateDirectory( s_path );
            }

            backgroundWorker.DoWork += ( sender, e ) =>
            {
                string[] files = Directory.GetFiles( s_path, Storage.filePattern, SearchOption.TopDirectoryOnly );

                int i = 1;

                foreach( string file in files )
                {
#if DEBUG
                    System.Threading.Thread.Sleep( Storage.delayLoadingMs );
#endif

                    try
                    {
                        DamageEffect damageEffect = JsonConvert.DeserializeObject<DamageEffect>( File.ReadAllText( file ) );
#if DEBUG
                        if( damageEffect.ID != new Guid( Path.GetFileNameWithoutExtension( file ) ) )
                        {
                            MessageBox.Show( $"ACHTUNG, die Eigenschaft '{damageEffect.Name}' hat eine abweichende ID im Dateinamen!" + Environment.NewLine + Environment.NewLine + Path.GetFileName( file ) );
                        }

                        DamageEffect damageEffectSearch = m_damageEffectList.Find( x => x.ID == damageEffect.ID );
                        if( damageEffectSearch != null )
                        {
                            MessageBox.Show( $"ACHTUNG, die Eigenschaft '{damageEffect.Name}' hat die gleiche ID wie die Eigenschaft '{damageEffectSearch.Name}'!" + Environment.NewLine + Environment.NewLine + damageEffect.ID );
                        }
#endif
                        m_damageEffectList.Add( damageEffect );
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show( $"Problem beim Lesen der Eigenschaft-Datei '{Path.GetFileName( file )}':\n{ex.Message}" );
                    }

                    backgroundWorker.ReportProgress( Convert.ToInt32( (float)i / files.Length * 100 ), $"Eigenschaft {i}/{files.Length}" );

                    i++;
                }
            };
        }

        public void Save( DamageEffect damageEffect )
        {
            if( null == damageEffect )
            {
                throw new ArgumentNullException( nameof( damageEffect ) );
            }
            string filename = GetFilename( damageEffect );
            string filenameBackup = Path.ChangeExtension( filename, Storage.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( damageEffect, Storage.formatting ) );
                File.Delete( filenameBackup );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Fehler beim Schreiben der Datei '{filename}':\n{ex.Message}" );
            }
        }

        private string GetFilename( DamageEffect damageEffect )
        {
            return Path.ChangeExtension( Path.Combine( s_path, damageEffect.ID.ToString() ), Storage.fileExtension );
        }

        private string GetFilenameTrash( DamageEffect damageEffect )
        {
            return Path.ChangeExtension( Path.Combine( s_pathTrash, damageEffect.ID.ToString() ), Storage.fileExtension );
        }

        public DamageEffect Get( Guid id )
        {
            DamageEffect damageEffect = m_damageEffectList.Find( x => x.ID == id );

            if( null == damageEffect )
            {
                throw new InvalidOperationException( $"Die Eigenschaft mit der ID {id} konnte nicht gefunden werden!" );
            }

            return ( damageEffect );
        }

        public DamageEffect Create()
        {
            DamageEffect damageEffect = new DamageEffect();

            Save( damageEffect );

            m_damageEffectList.Add( damageEffect );

            return ( damageEffect );
        }

        public void Delete( DamageEffect damageEffect )
        {
            if( null == damageEffect )
            {
                throw new ArgumentNullException( nameof( damageEffect ) );
            }

            m_damageEffectList.Remove( damageEffect );

            if( !Directory.Exists( s_pathTrash ) )
            {
                Directory.CreateDirectory( s_pathTrash );
            }

            File.Move( GetFilename( damageEffect ), GetFilenameTrash( damageEffect ) );
        }

        public IList<DamageEffect> DamageEffects => ( m_damageEffectList.AsReadOnly() );

        private readonly List<DamageEffect> m_damageEffectList = new List<DamageEffect>();
    }
}

using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tesserakt
{
    public class TLock : IDisposable
    {
        private const string fileExtension = ".lock";

        private class LockFileContents
        {
            public string UserName
            {
                get;
                set;
            }

            public string Machine
            {
                get;
                set;
            }

            public DateTime LockDate
            {
                get;
                set;
            }

            public int PID
            {
                get;
                set;
            }
        }

        public class TLockNotSuccessfullException : Exception
        {
        }

        public TLock()
        {
            string exeName = Path.GetFileName( System.Reflection.Assembly.GetEntryAssembly().Location );

            m_fileName = Path.Combine( Directory.GetCurrentDirectory(), "~" + exeName + fileExtension );

            try
            {
                LockFileContents lockFile = JsonConvert.DeserializeObject<LockFileContents>( File.ReadAllText( m_fileName ) );

                if( ( SystemInformation.ComputerName == lockFile.Machine )
                    &&
                    ( !Process.GetProcesses().Any( x => x.Id == lockFile.PID ) ) )
                {
                    File.Delete( m_fileName );

                    CreateLockFile();
                }
                else
                {
                    MessageBox.Show( $"'{exeName}' wird durch '{lockFile.UserName}' seit '{lockFile.LockDate}' verwendet!",
                                     String.Empty,
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning );

                    throw new TLockNotSuccessfullException();
                }
            }
            catch( FileNotFoundException )
            {
                CreateLockFile();
            }
        }

        readonly string m_fileName = null;

        private void CreateLockFile()
        {
            LockFileContents lockFile = new LockFileContents()
            {
                UserName = Environment.UserName,
                Machine = SystemInformation.ComputerName,
                LockDate = DateTime.Now,
                PID = Process.GetCurrentProcess().Id
            };

            File.WriteAllText( m_fileName, JsonConvert.SerializeObject( lockFile, Storage.formatting ) );

            File.SetAttributes( m_fileName, FileAttributes.Hidden );
        }

        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        protected virtual void Dispose( bool disposing )
        {
            if( disposing )
            {
                File.Delete( m_fileName );
            }
        }
    }
}

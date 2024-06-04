using System;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Deployment.Application;
using Valil.Chess.Model;
using Valil.Chess.WinFX.Properties;
//using System.Windows.Forms;

namespace Valil.Chess.WinFX
{
    /// <summary>
    /// Manages the load and autosaving operations.
    /// </summary>
    public class AutoSaveOperationsManager : Component
    {
        /// <summary>
        /// The game description proxy.
        /// </summary>
        private GameStringDescriptionProxy proxy;

        /// <summary>
        /// Keeps the PGN string for saving later in case the application is autosaving.
        /// </summary>
        private string autoSaveStore;

        /// <summary>
        /// The autosave background worker.
        /// The autosaving process will run in another thread, so the UI won't block.
        /// </summary>
        private BackgroundWorker autoSaveBackgroundWorker;

        /// <summary>
        /// The game description proxy.
        /// </summary>
        public GameStringDescriptionProxy Proxy
        {
            get { return proxy; }
            set
            {
                if (value != null)
                {
                    proxy = value;

                    // set the autosave handler
                    proxy.Save = new AutoSavePGNHandler(AutoSavePGN);
                }
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public AutoSaveOperationsManager()
        {
            autoSaveBackgroundWorker = new BackgroundWorker();

            autoSaveBackgroundWorker.DoWork += autoSaveBackgroundWorker_DoWork;
            autoSaveBackgroundWorker.RunWorkerCompleted += autoSaveBackgroundWorker_RunWorkerCompleted;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="container">The container which will contain this component.</param>
        public AutoSaveOperationsManager(IContainer container)
            : this()
        {
            container.Add(this);
        }

        /// <summary>
        /// Loads the last played game.
        /// Does nothing if the proxy is null.
        /// </summary>
        internal void LoadLastGame()
        {
            if (proxy == null) { return; }

            // get the isolated store for this user
            IsolatedStorageFile isoStore =
                ApplicationDeployment.IsNetworkDeployed ?
                IsolatedStorageFile.GetUserStoreForApplication() :
                IsolatedStorageFile.GetUserStoreForApplication();

            // if the file does not exists, set a new game
            if (isoStore.GetFileNames(Settings.Default.AutosaveGameRelPath).Length == 0)
            {
                proxy.LoadNewGame();
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(new IsolatedStorageFileStream(Settings.Default.AutosaveGameRelPath, FileMode.Open, FileAccess.Read, FileShare.Read, isoStore)))
                {
                    // initialize the game
                    proxy.LoadGame(sr);
                }
            }
            catch
            {
                //if there is an error, load a new game
                proxy.LoadNewGame();
            }
        }

        /// <summary>
        /// Autosave the game in PGN.
        /// </summary>
        private void AutoSavePGN()
        {
            if (autoSaveBackgroundWorker.IsBusy)
            {
                // the application is still autosaving
                // save the PGN in the buffer
                using (StringWriter sw = new StringWriter())
                {
                    proxy.WritePGNTo(sw);
                    autoSaveStore = sw.ToString();
                }
            }
            else
            {
                // start autosaving
                using (StringWriter sw = new StringWriter())
                {
                    proxy.WritePGNTo(sw);
                    autoSaveBackgroundWorker.RunWorkerAsync(sw.ToString());
                }
            }
        }

        private void autoSaveBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // get the isolated store for this user
            IsolatedStorageFile isoStore =
                ApplicationDeployment.IsNetworkDeployed ?
                IsolatedStorageFile.GetUserStoreForApplication() :
                IsolatedStorageFile.GetUserStoreForApplication();

            try
            {
                // save the PGN
                using (StreamWriter sw = new StreamWriter(new IsolatedStorageFileStream(Settings.Default.AutosaveGameRelPath, FileMode.Create, FileAccess.ReadWrite, FileShare.None, isoStore)))
                {
                    sw.Write(e.Argument as string);
                    sw.Flush();
                }
            }
            catch
            {
            }
        }

        private void autoSaveBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (autoSaveStore != null)
            {
                // start saving what was in the buffer
                autoSaveBackgroundWorker.RunWorkerAsync(autoSaveStore);
                autoSaveStore = null;
            }
        }
    }
}

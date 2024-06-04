using System;
using System.Windows;
using System.Windows.Navigation;
using System.Configuration;
using Valil.Chess.Model;
using Valil.Chess.Opponents;

namespace Valil.Chess.WinFX
{
    public partial class App : Application
    {
        private void AppStartup(object sender, StartupEventArgs args)
        {
            // put all the necessary objects in application properties
            // so they could be available in all windows

            // set the model
            Game model = new Game();
            Properties["Model"] = model;

            // set the opponent info
            OpponentsInfo oppInfo = new OpponentsInfo();
            oppInfo.Model = model;
            Properties["OpponentsInfo"] = oppInfo;

            // set the game description proxy
            GameStringDescriptionProxy desc = new GameStringDescriptionProxy();
            desc.Model = model;
            Properties["GameDescriptionProxy"] = desc;

            // set the autosave manager
            AutoSaveOperationsManager autoSaveManager = new AutoSaveOperationsManager();
            autoSaveManager.Proxy = desc;
            Properties["AutoSaveOperationsManager"] = autoSaveManager;
        }

        private void AppExit(object sender, EventArgs args)
        {
            (Properties["AutoSaveOperationsManager"] as AutoSaveOperationsManager).Dispose();
            (Properties["GameDescriptionProxy"] as GameStringDescriptionProxy).Dispose();
            (Properties["OpponentsInfo"] as OpponentsInfo).Dispose();
            (Properties["Model"] as Game).Dispose();
        }
    }
}
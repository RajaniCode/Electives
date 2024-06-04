using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using Valil.Chess.Model;
using Valil.Chess.Opponents;

namespace Valil.Chess.WinFX
{
    /// <summary>
    /// Implements the 2D chess page.
    /// </summary>
    public partial class Chess2DPage : Page
    {
        private Game model;
        private OpponentsInfo oppInfo;
        private GameStringDescriptionProxy desc;
        private AutoSaveOperationsManager autoSaveManager;

        private void PageLoaded(object sender, EventArgs e)
        {
            // get the needed objects from application properties
            model = Application.Current.Properties["Model"] as Game;
            desc = Application.Current.Properties["GameDescriptionProxy"] as GameStringDescriptionProxy;
            oppInfo = Application.Current.Properties["OpponentsInfo"] as OpponentsInfo;
            autoSaveManager = Application.Current.Properties["AutoSaveOperationsManager"] as AutoSaveOperationsManager;

            // load the last game
            autoSaveManager.LoadLastGame();

            gameBoard.Model = model;

            // set the promotion handler
            model.Promote = new PromotionHandler(GetPromotionPiece);

            // set the data contexts
            gameStatusItem.DataContext = desc;
            sideToMoveItem.DataContext = desc;
            oppInfoItem.DataContext = oppInfo;
            moveHistory.DataContext = desc.MoveHistoryStringDescriptionList;
        }

        /// <summary>
        /// Returns a promotion piece type.
        /// It should ask the user but right now it just simply returns the queen type.
        /// </summary>
        /// <returns></returns>
        private Type GetPromotionPiece()
        {
            return model.CurrentBoard.Status.WhiteTurn ? typeof(WhiteQueen) : typeof(BlackQueen);
        }

        private void NewCommand(object sender, ExecutedRoutedEventArgs e)
        {
            // ask the user if he/she wants to start a new game
            if (MessageBox.Show(Valil.Chess.WinFX.Properties.Resources.AskUserNewMsg, Valil.Chess.WinFX.Properties.Resources.NewGameTitle, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                Cursor = Cursors.AppStarting;

                desc.LoadNewGame();

                Cursor = Cursors.Arrow;
            }
        }

        private void FirstCommand(object sender, ExecutedRoutedEventArgs e)
        {
            Cursor = Cursors.AppStarting;

            model.GoToFirst();

            Cursor = Cursors.Arrow;
        }

        private void PreviousCommand(object sender, ExecutedRoutedEventArgs e)
        {
            Cursor = Cursors.AppStarting;

            model.Previous();

            Cursor = Cursors.Arrow;
        }

        private void NextCommand(object sender, ExecutedRoutedEventArgs e)
        {
            Cursor = Cursors.AppStarting;

            model.Next();

            Cursor = Cursors.Arrow;
        }

        private void LastCommand(object sender, ExecutedRoutedEventArgs e)
        {
            Cursor = Cursors.AppStarting;

            model.GoToLast();

            Cursor = Cursors.Arrow;
        }

        private void MoveCommand(object sender, ExecutedRoutedEventArgs e)
        {
            Cursor = Cursors.AppStarting;

            oppInfo.ForceAIMove();

            Cursor = Cursors.Arrow;
        }

        private void CanMoveCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !OpponentsSettings.Default.TwoPlayersMode;
        }

        private void RotateCommand(object sender, ExecutedRoutedEventArgs e)
        {
            Cursor = Cursors.AppStarting;

            gameBoard.Rotate();

            Cursor = Cursors.Arrow;
        }
    }
}
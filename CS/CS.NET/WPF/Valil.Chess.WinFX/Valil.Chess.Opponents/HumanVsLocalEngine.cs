using System;
using System.ComponentModel;
using Valil.Chess.Model;
using Valil.Chess.Engine;
using Valil.Chess.Opponents.Properties;

namespace Valil.Chess.Opponents
{
    /// <summary>
    /// A human player playing against the local engine.
    /// </summary>
    class HumanVsLocalEngine : HumanVsAI
    {
        /// <summary>
        /// The chess engine.
        /// </summary>
        private ChessEngine engine;

        public HumanVsLocalEngine()
        {
            // initialize the chess engine
            engine = new ChessEngine(true);
        }

        /// <summary>
        /// Abort engine thinking.
        /// </summary>
        protected override void AbortAIMove()
        {
            // if the engine is thinking, abort the engine move
            engine.AbortMove();
            engineWorker.CancelAsync();
        }

        /// <summary>
        /// Starts engine thinking.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void engineWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            EngineInputParameters inputParams = e.Argument as EngineInputParameters;

            // call the engine synchronously
            string canMove = engine.GetNextMove(inputParams.FEN, inputParams.RepetitiveMoveCandidate, inputParams.DepthLevel);
            e.Result = Utils.GetCANMove(model, canMove);
        }

        /// <summary>
        /// Dispose the engine resources.
        /// </summary>
        public override void Dispose()
        {
            // abort engine thinking
            AbortAIMove();

            //dispose the engine
            if (engineWorker != null) { engineWorker.Dispose(); }

            base.Dispose();
        }
    }
}

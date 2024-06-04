//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.SouthridgeVideo.FacilitiesSimulator
// FacilitiesSimulatorForm
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Messaging;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Resources;

namespace Microsoft.Samples.BizTalk.FacilitiesSimulator
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FacilitiesSimulatorForm : System.Windows.Forms.Form
	{
        //---------------------------------------------------------------------
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run( new FacilitiesSimulatorForm() );
        }

        //---------------------------------------------------------------------

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label rateLabel;
        private System.Windows.Forms.Timer messageTimer;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label receiveQueueLabel;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label transmitQueueLabel;
        private System.Windows.Forms.TextBox rateTextBox;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.TextBox receiveQueueTextBox;
        private System.Windows.Forms.TextBox transmitQueueTextBox;
        private System.Windows.Forms.Button closeButton;

        private ResourceManager stringManager;
        //---------------------------------------------------------------------
        // Define delegates to handles marshaling progress updates from
        // the the worker threads to the thread that contains the progress bars.
        private delegate void SubmitUpdateDelegate();

        private Thread               m_processThread;
        private bool                 m_processRunning;
        private SubmitUpdateDelegate m_updateDelegate;
        private EventHandler         m_completeDelegate;
        private ErrorEventHandler    m_errorDelegate;
        private int                  m_processCount;
        private int                  m_totProcessed;
        private string               m_receiveQueueName;
        private string               m_sendQueueName;
        private PerformanceCounter   m_perfCounter;

        private const string PERFCOUNTERCATEGORY     = "Test.FacilitiesSimulator";
        private const string PERFCOUNTERCATEGORYHELP = "MSMQ Test Server Simulator Application";
        private const string PERFCOUNTERNAME          = "Server Simulator Docs/Sec";

        //---------------------------------------------------------------------

        public FacilitiesSimulatorForm()
		{
            this.stringManager = new ResourceManager("Microsoft.Samples.BizTalk.SouthridgeVideo.FacilitiesSimulator.Properties.FacilitiesSimulatorForm", Assembly.GetExecutingAssembly());

            InitializeComponent();

            // Retrieve the applications settings from the last session.
            this.receiveQueueTextBox.Text = Application.UserAppDataRegistry.GetValue("ReceiveQueueName", @".\private$\ToFacilitiesQ") as string;
            this.transmitQueueTextBox.Text = Application.UserAppDataRegistry.GetValue("TransmitQueueName", @".\private$\FromFacilitiesQ") as string;

            m_updateDelegate   = new SubmitUpdateDelegate( OnUpdate );
            m_completeDelegate = new EventHandler( FireComplete );
            m_errorDelegate    = new ErrorEventHandler( OnError );

            // Initialize performance counters.
            if ( !PerformanceCounterCategory.Exists( PERFCOUNTERCATEGORY ) )
            {
                // Create a CounterCreationDataCollection collection .
                CounterCreationDataCollection CounterDatas = new CounterCreationDataCollection();

                // Create the counters and set their properties.
                CounterCreationData counter1 = new CounterCreationData();
                counter1.CounterName = PERFCOUNTERNAME;
                counter1.CounterHelp = this.stringManager.GetString("CounterHelp", CultureInfo.CurrentUICulture);//"The rate at which messages are processed by the simulator.";
                counter1.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;

                // Add counters to the collection.
                CounterDatas.Add( counter1 );

                // Create the category and pass the collection to it.
                PerformanceCounterCategory.Create(PERFCOUNTERCATEGORY, PERFCOUNTERCATEGORYHELP, PerformanceCounterCategoryType.SingleInstance, CounterDatas);
            }

            m_perfCounter = new System.Diagnostics.PerformanceCounter( PERFCOUNTERCATEGORY, PERFCOUNTERNAME, false );
        }

        //---------------------------------------------------------------------

        #region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.receiveQueueLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.transmitQueueLabel = new System.Windows.Forms.Label();
            this.rateTextBox = new System.Windows.Forms.TextBox();
            this.rateLabel = new System.Windows.Forms.Label();
            this.messageTimer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.stopButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.receiveQueueTextBox = new System.Windows.Forms.TextBox();
            this.transmitQueueTextBox = new System.Windows.Forms.TextBox();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // receiveQueueLabel
            // 
            this.receiveQueueLabel.Location = new System.Drawing.Point(8, 8);
            this.receiveQueueLabel.Name = "receiveQueueLabel";
            this.receiveQueueLabel.Size = new System.Drawing.Size(100, 16);
            this.receiveQueueLabel.TabIndex = 0;
            this.receiveQueueLabel.Text = this.stringManager.GetString("receiveQueueLabel", CultureInfo.CurrentUICulture);//"Receive Queue";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(240, 72);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(64, 32);
            this.startButton.TabIndex = 3;
            this.startButton.Text = this.stringManager.GetString("startButton", CultureInfo.CurrentUICulture); //"Start";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // transmitQueueLabel
            // 
            this.transmitQueueLabel.Location = new System.Drawing.Point(8, 40);
            this.transmitQueueLabel.Name = "transmitQueueLabel";
            this.transmitQueueLabel.Size = new System.Drawing.Size(100, 16);
            this.transmitQueueLabel.TabIndex = 4;
            this.transmitQueueLabel.Text = this.stringManager.GetString("transmitQueueLabel", CultureInfo.CurrentUICulture);//"Transmit Queue";
            // 
            // rateTextBox
            // 
            this.rateTextBox.Location = new System.Drawing.Point(128, 72);
            this.rateTextBox.Name = "rateTextBox";
            this.rateTextBox.ReadOnly = true;
            this.rateTextBox.Size = new System.Drawing.Size(96, 20);
            this.rateTextBox.TabIndex = 7;
            // 
            // rateLabel
            // 
            this.rateLabel.Location = new System.Drawing.Point(8, 72);
            this.rateLabel.Name = "rateLabel";
            this.rateLabel.Size = new System.Drawing.Size(112, 16);
            this.rateLabel.TabIndex = 6;
            this.rateLabel.Text = this.stringManager.GetString("rateLabel", CultureInfo.CurrentUICulture);//"Messages Rate";
            // 
            // messageTimer
            // 
            this.messageTimer.Interval = 1000;
            this.messageTimer.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(328, 72);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(64, 32);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = this.stringManager.GetString("stopButton", CultureInfo.CurrentUICulture);//"Stop";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(8, 144);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(152, 16);
            this.statusLabel.TabIndex = 11;
            // 
            // receiveQueueTextBox
            // 
            this.receiveQueueTextBox.Location = new System.Drawing.Point(128, 8);
            this.receiveQueueTextBox.Name = "receiveQueueTextBox";
            this.receiveQueueTextBox.Size = new System.Drawing.Size(280, 20);
            this.receiveQueueTextBox.TabIndex = 12;
            // 
            // transmitQueueTextBox
            // 
            this.transmitQueueTextBox.Location = new System.Drawing.Point(128, 40);
            this.transmitQueueTextBox.Name = "transmitQueueTextBox";
            this.transmitQueueTextBox.Size = new System.Drawing.Size(280, 20);
            this.transmitQueueTextBox.TabIndex = 13;
            // 
            // totalTextBox
            // 
            this.totalTextBox.Location = new System.Drawing.Point(128, 104);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.ReadOnly = true;
            this.totalTextBox.Size = new System.Drawing.Size(96, 20);
            this.totalTextBox.TabIndex = 7;
            // 
            // totalLabel
            // 
            this.totalLabel.Location = new System.Drawing.Point(8, 104);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(112, 16);
            this.totalLabel.TabIndex = 6;
            this.totalLabel.Text = this.stringManager.GetString("totalLabel", CultureInfo.CurrentUICulture);//"Messages Total";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(328, 128);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(72, 32);
            this.closeButton.TabIndex = 14;
            this.closeButton.Text = this.stringManager.GetString("closeButton", CultureInfo.CurrentUICulture);//"Close";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // FacilitiesSimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(416, 173);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.transmitQueueTextBox);
            this.Controls.Add(this.receiveQueueTextBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.rateTextBox);
            this.Controls.Add(this.rateLabel);
            this.Controls.Add(this.transmitQueueLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.receiveQueueLabel);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(this.totalLabel);
            this.Name = "FacilitiesSimulatorForm";
            this.Text = this.stringManager.GetString("FacilitiesSimulatorForm", CultureInfo.CurrentUICulture);//"Facilities Simulator";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OnClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }
		#endregion

        //---------------------------------------------------------------------

        private void startButton_Click( object sender, System.EventArgs e )
        {
            StartProcessThread();
        }

        //---------------------------------------------------------------------

        private void stopButton_Click( object sender, System.EventArgs e )
        {
            StopProcessThread();
        }

        //---------------------------------------------------------------------

        private void OnClosing( object sender, System.ComponentModel.CancelEventArgs e )
        {
            StopProcessThread();

            // Save the application's settings.
            Application.UserAppDataRegistry.SetValue( "ReceiveQueueName",  receiveQueueTextBox.Text );
            Application.UserAppDataRegistry.SetValue( "TransmitQueueName", transmitQueueTextBox.Text );
        }

        //---------------------------------------------------------------------

        #region Process Thread Code
        public void StartProcessThread()
        {
            if ( m_processRunning ) return;

            // Reset data for this run.
            m_processCount      = 0;
            m_totProcessed      = 0;
            rateTextBox.Text    = string.Empty;
            totalTextBox.Text   = string.Empty;
            stopButton.Enabled  = true;
            startButton.Enabled = false;

            m_receiveQueueName = receiveQueueTextBox.Text;
            m_sendQueueName    = transmitQueueTextBox.Text;

            // Start the submit thread.
            m_processThread  = new Thread( new ThreadStart( ProcessThreadProcedure ) );
            m_processThread.Priority = ThreadPriority.Normal;
            m_processRunning = true;
            m_processThread.Start();

            messageTimer.Start();

            statusLabel.Text = this.stringManager.GetString("statusLabel", CultureInfo.CurrentUICulture);//"Running...";
        }

        //---------------------------------------------------------------------

        public void StopProcessThread()
        {
            if ( !m_processRunning ) return;

            // Signal the processing thread to stop.
            m_processRunning = false;

            if ( m_processThread.IsAlive )
            {
                m_processThread.Join();
            }
            messageTimer.Stop();
            m_processThread     = null;
            m_processCount      = 0;
            m_totProcessed      = 0;
            rateTextBox.Text    = string.Empty;
            totalTextBox.Text   = string.Empty;
            stopButton.Enabled  = false;
            startButton.Enabled = true;

            statusLabel.Text = string.Empty;
        }

        //---------------------------------------------------------------------

        private void ProcessThreadProcedure()
        {
            try
            {
                MessageQueue receiveQueue = new MessageQueue( @"FormatName:DIRECT=OS:" + m_receiveQueueName );
                MessageQueue sendQueue = null;
                System.Messaging.Message sendMsg = null;
                if (!string.IsNullOrEmpty(this.m_sendQueueName))
                {
                    sendQueue = new MessageQueue(@"FormatName:DIRECT=OS:" + m_sendQueueName);
                    sendQueue.Formatter = new ActiveXMessageFormatter();

                    sendMsg = new System.Messaging.Message();
                    sendMsg.Formatter = new ActiveXMessageFormatter();
                }
                TimeSpan     timeout      = new TimeSpan( 0, 0, 1 );    // 1 Second.

				receiveQueue.MessageReadPropertyFilter.CorrelationId = true;
				receiveQueue.MessageReadPropertyFilter.AppSpecific = true;

                // Set receive queue formatter.
                receiveQueue.Formatter = new ActiveXMessageFormatter();

                //
				// TODO: Call Initialization of custom message handling component
				//

                while( m_processRunning )
                {
                    try
                    {
                        System.Messaging.Message msg = receiveQueue.Receive( timeout );

                        //
						// TODO: Call custom message handling component
						//

                        // if the send queue is not set then just empty the messages
                        // from the receive queue
                        if (null != sendQueue)
                        {
                            // Create send message object.
                            sendMsg = msg;
                            sendMsg.AppSpecific = msg.AppSpecific;
                            sendMsg.CorrelationId = msg.CorrelationId;

                            MessageQueueTransaction mqt = new MessageQueueTransaction();
                            mqt.Begin();
                            // Send the response.
                            sendQueue.Send(sendMsg, mqt);
                            mqt.Commit();
                        }
                        // Update the process count.
                        BeginInvoke( m_updateDelegate );

                        // Increment the performance counter.
                        if ( m_perfCounter != null ) m_perfCounter.Increment();
                    }
                    catch( MessageQueueException ex )
                    {
                        // Ignore timeout exceptions.
                        if (ex.MessageQueueErrorCode != MessageQueueErrorCode.IOTimeout)
                        {
                            throw;
                        }
                    }
                }
            }
            catch( Exception ex )
            {
                System.Console.WriteLine( ex.Message );
                ErrorEventArgs e = new ErrorEventArgs( ex );
                BeginInvoke( m_errorDelegate, new object[] {this, e } );
            }
            finally
            {
                BeginInvoke( m_completeDelegate, new object[] {this, EventArgs.Empty} );
            }
        }

        //---------------------------------------------------------------------

        public event EventHandler ProcessingComplete;

        //---------------------------------------------------------------------

        private void FireComplete( object sender, EventArgs e )
        {
            m_processRunning = false;
            if ( ProcessingComplete != null )
            {
                ProcessingComplete( sender, e );
            }
        }

        //---------------------------------------------------------------------

        private void OnUpdate()
        {
            System.Threading.Interlocked.Increment( ref m_processCount );
            System.Threading.Interlocked.Increment( ref m_totProcessed );
        }

        //---------------------------------------------------------------------

        private void OnError( object sender, ErrorEventArgs error )
        {
            string submitError = this.stringManager.GetString("submitError", CultureInfo.CurrentUICulture);
            MessageBox.Show( this, 
                error.GetException().Message, 
                submitError, MessageBoxButtons.OK, 
                MessageBoxIcon.Error, 
                MessageBoxDefaultButton.Button1, 
                MessageBoxOptions.RtlReading );
        }
        #endregion

        //---------------------------------------------------------------------

        private void OnTimerTick(object sender, System.EventArgs e)
        {
            // Update the message rate label.
            rateTextBox.Text = string.Format(CultureInfo.InvariantCulture, "{0}", m_processCount);
            totalTextBox.Text = string.Format(CultureInfo.InvariantCulture, "{0}", m_totProcessed );

            // Reset rate counter to zero.
            System.Threading.Interlocked.Exchange( ref m_processCount, 0 );
        }

        //---------------------------------------------------------------------

        private void closeButton_Click(object sender, System.EventArgs e)
        {
            StopProcessThread();

            // Save the application's settings.
            Application.UserAppDataRegistry.SetValue( "ReceiveQueueName",  receiveQueueTextBox.Text );
            Application.UserAppDataRegistry.SetValue( "TransmitQueueName", transmitQueueTextBox.Text );

            Application.Exit();
        }

        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
    }
}

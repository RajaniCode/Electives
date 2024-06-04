//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.SimpleClient
// Simple Client class to exercise the Service Oriented Scenario.
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
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using Microsoft.Samples.BizTalk.WoodgroveBank.SimpleClient.CustomerService ;
using Microsoft.Samples.BizTalk.WoodgroveBank.SchemaClasses;

using IBM.WMQ;

// Make the assembly not visible to com clients...
[assembly: System.Runtime.InteropServices.ComVisible(false)]

// We don't expect this assembly to be called from other languages...
[assembly: CLSCompliant(false)]

namespace Microsoft.Samples.BizTalk.WoodgroveBank.SimpleClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormSimpleClient : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox Response;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtRequestType;
		private System.Windows.Forms.TextBox txtRequestSource;
		private System.Windows.Forms.TextBox txtAccountNumber;
		private System.Windows.Forms.TextBox txtRequestID;
		private System.Windows.Forms.Button btnGetMyBalance;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton choiceSOAPTransport;
		private System.Windows.Forms.RadioButton choiceMQSeriesTransport;
		private System.Windows.Forms.Label lblCreditLimit;
		private System.Windows.Forms.Label lblAccountBalance;
		private System.Windows.Forms.Label lblLastPayment;
		private System.Windows.Forms.Label lblPendingTrans;
		private System.Windows.Forms.Label lblTimeTaken;
		private System.Windows.Forms.Label lblCashAdvance;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox txtAuthName1;
		private System.Windows.Forms.TextBox txtAuthValue1;
		private System.Windows.Forms.TextBox txtAuthValue2;
		private System.Windows.Forms.TextBox txtAuthName2;
		private System.Windows.Forms.TextBox txtAuthValue3;
		private System.Windows.Forms.TextBox txtAuthName3;
		private System.Windows.Forms.TextBox txtAuthValue4;
		private System.Windows.Forms.TextBox txtAuthName4;
		private System.Windows.Forms.TextBox txtAuthValue5;
		private System.Windows.Forms.TextBox txtAuthName5;
		private System.Windows.Forms.GroupBox grpMQSeries;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox txtChannelDefinition;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox txtOutputQueue;
		private System.Windows.Forms.TextBox txtInputQueue;
		private System.Windows.Forms.TextBox txtQueueManager;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtStatus;
		private System.Windows.Forms.GroupBox grpWebServiceParameters;
		private System.Windows.Forms.RadioButton choiceAdapterWS;
		private System.Windows.Forms.RadioButton choiceInlineWS;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox txtSoapUrl;
		private System.Windows.Forms.RadioButton choiceStubWS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormSimpleClient()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			localizationRelatedInitialize();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnGetMyBalance = new System.Windows.Forms.Button();
            this.lblTimeTaken = new System.Windows.Forms.Label();
            this.Response = new System.Windows.Forms.GroupBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblCashAdvance = new System.Windows.Forms.Label();
            this.lblPendingTrans = new System.Windows.Forms.Label();
            this.lblLastPayment = new System.Windows.Forms.Label();
            this.lblAccountBalance = new System.Windows.Forms.Label();
            this.lblCreditLimit = new System.Windows.Forms.Label();
            this.txtRequestType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRequestSource = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAuthValue5 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtAuthName5 = new System.Windows.Forms.TextBox();
            this.txtAuthValue4 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtAuthName4 = new System.Windows.Forms.TextBox();
            this.txtAuthValue3 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAuthName3 = new System.Windows.Forms.TextBox();
            this.txtAuthValue2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAuthName2 = new System.Windows.Forms.TextBox();
            this.txtAuthValue1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpWebServiceParameters = new System.Windows.Forms.GroupBox();
            this.choiceStubWS = new System.Windows.Forms.RadioButton();
            this.label21 = new System.Windows.Forms.Label();
            this.txtSoapUrl = new System.Windows.Forms.TextBox();
            this.choiceInlineWS = new System.Windows.Forms.RadioButton();
            this.choiceAdapterWS = new System.Windows.Forms.RadioButton();
            this.choiceMQSeriesTransport = new System.Windows.Forms.RadioButton();
            this.choiceSOAPTransport = new System.Windows.Forms.RadioButton();
            this.grpMQSeries = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtChannelDefinition = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtOutputQueue = new System.Windows.Forms.TextBox();
            this.txtInputQueue = new System.Windows.Forms.TextBox();
            this.txtQueueManager = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAuthName1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRequestID = new System.Windows.Forms.TextBox();
            this.Response.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpWebServiceParameters.SuspendLayout();
            this.grpMQSeries.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetMyBalance
            // 
            this.btnGetMyBalance.Location = new System.Drawing.Point(208, 272);
            this.btnGetMyBalance.Name = "btnGetMyBalance";
            this.btnGetMyBalance.Size = new System.Drawing.Size(128, 32);
            this.btnGetMyBalance.TabIndex = 20;
            this.btnGetMyBalance.Text = "Get my balance!";
            this.btnGetMyBalance.Click += new System.EventHandler(this.btnGetMyBalance_Click);
            // 
            // lblTimeTaken
            // 
            this.lblTimeTaken.Location = new System.Drawing.Point(448, 56);
            this.lblTimeTaken.Name = "lblTimeTaken";
            this.lblTimeTaken.Size = new System.Drawing.Size(264, 24);
            this.lblTimeTaken.TabIndex = 1;
            // 
            // Response
            // 
            this.Response.Controls.Add(this.txtStatus);
            this.Response.Controls.Add(this.lblCashAdvance);
            this.Response.Controls.Add(this.lblPendingTrans);
            this.Response.Controls.Add(this.lblLastPayment);
            this.Response.Controls.Add(this.lblAccountBalance);
            this.Response.Controls.Add(this.lblCreditLimit);
            this.Response.Controls.Add(this.lblTimeTaken);
            this.Response.Location = new System.Drawing.Point(8, 344);
            this.Response.Name = "Response";
            this.Response.Size = new System.Drawing.Size(832, 256);
            this.Response.TabIndex = 2;
            this.Response.TabStop = false;
            this.Response.Text = "Response";
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtStatus.Location = new System.Drawing.Point(8, 100);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(816, 136);
            this.txtStatus.TabIndex = 10;
            // 
            // lblCashAdvance
            // 
            this.lblCashAdvance.Location = new System.Drawing.Point(224, 56);
            this.lblCashAdvance.Name = "lblCashAdvance";
            this.lblCashAdvance.Size = new System.Drawing.Size(208, 23);
            this.lblCashAdvance.TabIndex = 6;
            // 
            // lblPendingTrans
            // 
            this.lblPendingTrans.Location = new System.Drawing.Point(8, 56);
            this.lblPendingTrans.Name = "lblPendingTrans";
            this.lblPendingTrans.Size = new System.Drawing.Size(208, 23);
            this.lblPendingTrans.TabIndex = 5;
            // 
            // lblLastPayment
            // 
            this.lblLastPayment.Location = new System.Drawing.Point(448, 24);
            this.lblLastPayment.Name = "lblLastPayment";
            this.lblLastPayment.Size = new System.Drawing.Size(208, 23);
            this.lblLastPayment.TabIndex = 4;
            // 
            // lblAccountBalance
            // 
            this.lblAccountBalance.Location = new System.Drawing.Point(224, 24);
            this.lblAccountBalance.Name = "lblAccountBalance";
            this.lblAccountBalance.Size = new System.Drawing.Size(208, 23);
            this.lblAccountBalance.TabIndex = 3;
            // 
            // lblCreditLimit
            // 
            this.lblCreditLimit.Location = new System.Drawing.Point(8, 24);
            this.lblCreditLimit.Name = "lblCreditLimit";
            this.lblCreditLimit.Size = new System.Drawing.Size(208, 23);
            this.lblCreditLimit.TabIndex = 2;
            // 
            // txtRequestType
            // 
            this.txtRequestType.Location = new System.Drawing.Point(104, 24);
            this.txtRequestType.Name = "txtRequestType";
            this.txtRequestType.Size = new System.Drawing.Size(120, 20);
            this.txtRequestType.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Request Type:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRequestSource
            // 
            this.txtRequestSource.Location = new System.Drawing.Point(344, 24);
            this.txtRequestSource.Name = "txtRequestSource";
            this.txtRequestSource.Size = new System.Drawing.Size(120, 20);
            this.txtRequestSource.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(232, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Request Source:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAuthValue5);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtAuthName5);
            this.groupBox1.Controls.Add(this.txtAuthValue4);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtAuthName4);
            this.groupBox1.Controls.Add(this.txtAuthValue3);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtAuthName3);
            this.groupBox1.Controls.Add(this.txtAuthValue2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtAuthName2);
            this.groupBox1.Controls.Add(this.txtAuthValue1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtAuthName1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtAccountNumber);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtRequestID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRequestType);
            this.groupBox1.Controls.Add(this.txtRequestSource);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnGetMyBalance);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(832, 328);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // txtAuthValue5
            // 
            this.txtAuthValue5.Location = new System.Drawing.Point(216, 216);
            this.txtAuthValue5.Name = "txtAuthValue5";
            this.txtAuthValue5.Size = new System.Drawing.Size(96, 20);
            this.txtAuthValue5.TabIndex = 13;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(176, 216);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 16);
            this.label17.TabIndex = 33;
            this.label17.Text = "Value:";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(8, 216);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 16);
            this.label18.TabIndex = 32;
            this.label18.Text = "Name:";
            // 
            // txtAuthName5
            // 
            this.txtAuthName5.Location = new System.Drawing.Point(64, 216);
            this.txtAuthName5.Name = "txtAuthName5";
            this.txtAuthName5.Size = new System.Drawing.Size(96, 20);
            this.txtAuthName5.TabIndex = 12;
            // 
            // txtAuthValue4
            // 
            this.txtAuthValue4.Location = new System.Drawing.Point(216, 192);
            this.txtAuthValue4.Name = "txtAuthValue4";
            this.txtAuthValue4.Size = new System.Drawing.Size(96, 20);
            this.txtAuthValue4.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(176, 192);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 16);
            this.label15.TabIndex = 29;
            this.label15.Text = "Value:";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(8, 192);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 16);
            this.label16.TabIndex = 28;
            this.label16.Text = "Name:";
            // 
            // txtAuthName4
            // 
            this.txtAuthName4.Location = new System.Drawing.Point(64, 192);
            this.txtAuthName4.Name = "txtAuthName4";
            this.txtAuthName4.Size = new System.Drawing.Size(96, 20);
            this.txtAuthName4.TabIndex = 10;
            // 
            // txtAuthValue3
            // 
            this.txtAuthValue3.Location = new System.Drawing.Point(216, 168);
            this.txtAuthValue3.Name = "txtAuthValue3";
            this.txtAuthValue3.Size = new System.Drawing.Size(96, 20);
            this.txtAuthValue3.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(176, 168);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 16);
            this.label13.TabIndex = 25;
            this.label13.Text = "Value:";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 168);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 16);
            this.label14.TabIndex = 24;
            this.label14.Text = "Name:";
            // 
            // txtAuthName3
            // 
            this.txtAuthName3.Location = new System.Drawing.Point(64, 168);
            this.txtAuthName3.Name = "txtAuthName3";
            this.txtAuthName3.Size = new System.Drawing.Size(96, 20);
            this.txtAuthName3.TabIndex = 8;
            // 
            // txtAuthValue2
            // 
            this.txtAuthValue2.Location = new System.Drawing.Point(216, 144);
            this.txtAuthValue2.Name = "txtAuthValue2";
            this.txtAuthValue2.Size = new System.Drawing.Size(96, 20);
            this.txtAuthValue2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(176, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Value:";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 20;
            this.label12.Text = "Name:";
            // 
            // txtAuthName2
            // 
            this.txtAuthName2.Location = new System.Drawing.Point(64, 144);
            this.txtAuthName2.Name = "txtAuthName2";
            this.txtAuthName2.Size = new System.Drawing.Size(96, 20);
            this.txtAuthName2.TabIndex = 6;
            // 
            // txtAuthValue1
            // 
            this.txtAuthValue1.Location = new System.Drawing.Point(216, 120);
            this.txtAuthValue1.Name = "txtAuthValue1";
            this.txtAuthValue1.Size = new System.Drawing.Size(96, 20);
            this.txtAuthValue1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(176, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Value:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grpWebServiceParameters);
            this.groupBox2.Controls.Add(this.choiceMQSeriesTransport);
            this.groupBox2.Controls.Add(this.choiceSOAPTransport);
            this.groupBox2.Controls.Add(this.grpMQSeries);
            this.groupBox2.Location = new System.Drawing.Point(472, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 304);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Transport and Parameters";
            // 
            // grpWebServiceParameters
            // 
            this.grpWebServiceParameters.Controls.Add(this.choiceStubWS);
            this.grpWebServiceParameters.Controls.Add(this.label21);
            this.grpWebServiceParameters.Controls.Add(this.txtSoapUrl);
            this.grpWebServiceParameters.Controls.Add(this.choiceInlineWS);
            this.grpWebServiceParameters.Controls.Add(this.choiceAdapterWS);
            this.grpWebServiceParameters.Location = new System.Drawing.Point(8, 40);
            this.grpWebServiceParameters.Name = "grpWebServiceParameters";
            this.grpWebServiceParameters.Size = new System.Drawing.Size(336, 80);
            this.grpWebServiceParameters.TabIndex = 37;
            this.grpWebServiceParameters.TabStop = false;
            this.grpWebServiceParameters.Text = "Web Service Details";
            // 
            // choiceStubWS
            // 
            this.choiceStubWS.Enabled = false;
            this.choiceStubWS.Location = new System.Drawing.Point(240, 56);
            this.choiceStubWS.Name = "choiceStubWS";
            this.choiceStubWS.Size = new System.Drawing.Size(56, 16);
            this.choiceStubWS.TabIndex = 39;
            this.choiceStubWS.Text = "Stub";
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(8, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 16);
            this.label21.TabIndex = 38;
            this.label21.Text = "URL:";
            // 
            // txtSoapUrl
            // 
            this.txtSoapUrl.Enabled = false;
            this.txtSoapUrl.Location = new System.Drawing.Point(48, 24);
            this.txtSoapUrl.Name = "txtSoapUrl";
            this.txtSoapUrl.Size = new System.Drawing.Size(280, 20);
            this.txtSoapUrl.TabIndex = 37;
            // 
            // choiceInlineWS
            // 
            this.choiceInlineWS.Enabled = false;
            this.choiceInlineWS.Location = new System.Drawing.Point(144, 56);
            this.choiceInlineWS.Name = "choiceInlineWS";
            this.choiceInlineWS.Size = new System.Drawing.Size(70, 16);
            this.choiceInlineWS.TabIndex = 1;
            this.choiceInlineWS.Text = "Inline";
            // 
            // choiceAdapterWS
            // 
            this.choiceAdapterWS.Enabled = false;
            this.choiceAdapterWS.Location = new System.Drawing.Point(32, 56);
            this.choiceAdapterWS.Name = "choiceAdapterWS";
            this.choiceAdapterWS.Size = new System.Drawing.Size(80, 16);
            this.choiceAdapterWS.TabIndex = 0;
            this.choiceAdapterWS.Text = "Adapter";
            // 
            // choiceMQSeriesTransport
            // 
            this.choiceMQSeriesTransport.Location = new System.Drawing.Point(16, 128);
            this.choiceMQSeriesTransport.Name = "choiceMQSeriesTransport";
            this.choiceMQSeriesTransport.Size = new System.Drawing.Size(104, 16);
            this.choiceMQSeriesTransport.TabIndex = 15;
            this.choiceMQSeriesTransport.Text = "MQSeries";
            this.choiceMQSeriesTransport.CheckedChanged += new System.EventHandler(this.choiceMQSeriesTransport_CheckedChanged);
            // 
            // choiceSOAPTransport
            // 
            this.choiceSOAPTransport.Location = new System.Drawing.Point(16, 16);
            this.choiceSOAPTransport.Name = "choiceSOAPTransport";
            this.choiceSOAPTransport.Size = new System.Drawing.Size(120, 16);
            this.choiceSOAPTransport.TabIndex = 14;
            this.choiceSOAPTransport.Text = "SOAP (WS Call)";
            this.choiceSOAPTransport.CheckedChanged += new System.EventHandler(this.choiceSOAPTransport_CheckedChanged);
            // 
            // grpMQSeries
            // 
            this.grpMQSeries.Controls.Add(this.label20);
            this.grpMQSeries.Controls.Add(this.txtChannelDefinition);
            this.grpMQSeries.Controls.Add(this.label19);
            this.grpMQSeries.Controls.Add(this.txtOutputQueue);
            this.grpMQSeries.Controls.Add(this.txtInputQueue);
            this.grpMQSeries.Controls.Add(this.txtQueueManager);
            this.grpMQSeries.Controls.Add(this.label11);
            this.grpMQSeries.Controls.Add(this.label10);
            this.grpMQSeries.Controls.Add(this.label9);
            this.grpMQSeries.Location = new System.Drawing.Point(8, 152);
            this.grpMQSeries.Name = "grpMQSeries";
            this.grpMQSeries.Size = new System.Drawing.Size(336, 144);
            this.grpMQSeries.TabIndex = 34;
            this.grpMQSeries.TabStop = false;
            this.grpMQSeries.Text = "MQSeries Transport Parameters";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(91, 120);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(237, 16);
            this.label20.TabIndex = 37;
            this.label20.Text = "channel-name/transport/hostname(port)";
            // 
            // txtChannelDefinition
            // 
            this.txtChannelDefinition.Enabled = false;
            this.txtChannelDefinition.Location = new System.Drawing.Point(128, 96);
            this.txtChannelDefinition.Name = "txtChannelDefinition";
            this.txtChannelDefinition.Size = new System.Drawing.Size(200, 20);
            this.txtChannelDefinition.TabIndex = 35;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(4, 96);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(116, 16);
            this.label19.TabIndex = 36;
            this.label19.Text = "Channel Definition:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOutputQueue
            // 
            this.txtOutputQueue.Enabled = false;
            this.txtOutputQueue.Location = new System.Drawing.Point(128, 72);
            this.txtOutputQueue.Name = "txtOutputQueue";
            this.txtOutputQueue.Size = new System.Drawing.Size(200, 20);
            this.txtOutputQueue.TabIndex = 34;
            // 
            // txtInputQueue
            // 
            this.txtInputQueue.Enabled = false;
            this.txtInputQueue.Location = new System.Drawing.Point(128, 48);
            this.txtInputQueue.Name = "txtInputQueue";
            this.txtInputQueue.Size = new System.Drawing.Size(200, 20);
            this.txtInputQueue.TabIndex = 33;
            // 
            // txtQueueManager
            // 
            this.txtQueueManager.Enabled = false;
            this.txtQueueManager.Location = new System.Drawing.Point(128, 24);
            this.txtQueueManager.Name = "txtQueueManager";
            this.txtQueueManager.Size = new System.Drawing.Size(200, 20);
            this.txtQueueManager.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 16);
            this.label11.TabIndex = 31;
            this.label11.Text = "Output Queue:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 16);
            this.label10.TabIndex = 30;
            this.label10.Text = "Input Queue:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 16);
            this.label9.TabIndex = 29;
            this.label9.Text = "Queue Manager:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Authentication Elements:";
            // 
            // txtAuthName1
            // 
            this.txtAuthName1.Location = new System.Drawing.Point(64, 120);
            this.txtAuthName1.Name = "txtAuthName1";
            this.txtAuthName1.Size = new System.Drawing.Size(96, 20);
            this.txtAuthName1.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(232, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Account Number:";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(344, 56);
            this.txtAccountNumber.MaxLength = 16;
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(120, 20);
            this.txtAccountNumber.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Request ID:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRequestID
            // 
            this.txtRequestID.Location = new System.Drawing.Point(104, 56);
            this.txtRequestID.Name = "txtRequestID";
            this.txtRequestID.Size = new System.Drawing.Size(120, 20);
            this.txtRequestID.TabIndex = 2;
            // 
            // FormSimpleClient
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(848, 607);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Response);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormSimpleClient";
            this.Text = "Service Oriented Scenario - Simple Client";
            this.Response.ResumeLayout(false);
            this.Response.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.grpWebServiceParameters.ResumeLayout(false);
            this.grpWebServiceParameters.PerformLayout();
            this.grpMQSeries.ResumeLayout(false);
            this.grpMQSeries.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		// All initializations related to localizations. keep this in a separate function
		// so it doesn't interfere with the forms designer generated initialization code...
		private void localizationRelatedInitialize()
		{
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScaleDimensions = new SizeF(6.0F, 13.0F);
 		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormSimpleClient());
		}

		private const string CLIENT_NAME = "SO Scenario Simple Client";
		private const int ACCOUNT_NUM_LENGTH = 16;

		/// <summary>
		/// Event handler for the Get My Balance button click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGetMyBalance_Click(object sender, System.EventArgs e)
		{
			ArrayList authNames = new ArrayList(5);		// Maximum allowed authentication data elements based on schema
			ArrayList authValues = new ArrayList(5);

			if (! validate(authNames, authValues))
			{
				return;
			}

			// Assemble a Customer Service Request based on the info...
			CustomerServiceRequest req = AssembleRequest(txtRequestID.Text,txtRequestSource.Text, txtRequestType.Text, txtAccountNumber.Text, authNames, authValues);

			try
			{
				CustomerServiceResponse resp = null;
				this.Cursor = Cursors.WaitCursor;
				clearDisplay();
				
				DateTime dStart = DateTime.Now ;

				if (choiceSOAPTransport.Checked)
				{
					int whichWebService;
					if (choiceInlineWS.Checked)
						whichWebService = 0;				// Inline
					else if (choiceAdapterWS.Checked)
						whichWebService = 1;				// Adapter
					else
						whichWebService = 2;				// Stub

					resp = doWebServiceRequestResponse(req, txtSoapUrl.Text, whichWebService);
				}
				else if (choiceMQSeriesTransport.Checked)
				{
					resp = doMQSeriesRequestResponse(req, txtChannelDefinition.Text,  txtQueueManager.Text, txtInputQueue.Text, txtOutputQueue.Text);
				}

				DateTime dEnd = DateTime.Now;
				TimeSpan duration = dEnd.Subtract (dStart);
							
				lblAccountBalance.Text = "";
				lblCashAdvance.Text = "";
				lblCreditLimit.Text = "";
				lblLastPayment.Text = "";
				lblPendingTrans.Text = "";
				txtStatus.Text = "";

				lblTimeTaken.Text = "Time taken: " + duration.TotalMilliseconds.ToString(System.Globalization.CultureInfo.CurrentCulture) + " Milliseconds";

				if (resp.ResponseStatus.Result  == "SUCCESS")
				{
					displayResultDetails(resp);
				}
				else
				{
					displayErrorDetails(resp);
				}
			
				this.Cursor = Cursors.Arrow;
			}
			catch (Exception ex)
			{
				this.Cursor = Cursors.Arrow;
				string[] exceptionText = {
						 "Exception Occurred:\n" + ex.ToString() + 
						(null == ex.InnerException ? "" : ("Inner Exception:\n" + ex.InnerException.ToString()))
				};

				txtStatus.Lines = exceptionText;
				MessageBox.Show("Request Failed", CLIENT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
		}

		private bool validate(ArrayList authNames, ArrayList authValues)
		{
			// Length of account #

			if (!isValid(txtAccountNumber.Text))
			{
				MessageBox.Show("Account number should be exactly " + Convert.ToString(ACCOUNT_NUM_LENGTH, System.Globalization.CultureInfo.CurrentCulture) + " digits long and numeric", CLIENT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			if ( (! choiceSOAPTransport.Checked) && (! choiceMQSeriesTransport.Checked))
			{
				MessageBox.Show("One of the transports must be selected", CLIENT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			if (choiceMQSeriesTransport.Checked)
			{
				if (0 == txtQueueManager.Text.Length || 0 == txtInputQueue.Text.Length || 0 == txtOutputQueue.Text.Length)
				{
					MessageBox.Show("Queue parameters - queue manager, input, output queues - required", CLIENT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
			}

			if (choiceSOAPTransport.Checked)
			{
				if (0 == txtSoapUrl.Text.Length)
				{
					MessageBox.Show("URL required when using SOAP transport", CLIENT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}

				if (!choiceAdapterWS.Checked && !choiceInlineWS.Checked && !choiceStubWS.Checked)
				{
					MessageBox.Show("Select Adapter / Inline / Stub Web Service", CLIENT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}

				if (!validateURL())
				{
					return false;
				}
			}
	
			// Get the authentication names and values ...
			if (txtAuthName1.Text.Length != 0)
			{
				authNames.Add(txtAuthName1.Text);
				authValues.Add(txtAuthValue1.Text);
			}
			if (txtAuthName2.Text.Length != 0)
			{
				authNames.Add(txtAuthName2.Text);
				authValues.Add(txtAuthValue2.Text);
			}
			if (txtAuthName3.Text.Length != 0)
			{
				authNames.Add(txtAuthName3.Text);
				authValues.Add(txtAuthValue3.Text);
			}
			if (txtAuthName4.Text.Length != 0)
			{
				authNames.Add(txtAuthName4.Text);
				authValues.Add(txtAuthValue4.Text);
			}
			if (txtAuthName5.Text.Length != 0)
			{
				authNames.Add(txtAuthName5.Text);
				authValues.Add(txtAuthValue5.Text);
			}

			if (0 == authNames.Count)
			{
				MessageBox.Show("At least 1 authentication data name and value is required\nSupported authentication elements are ZipCode and CustomerName", CLIENT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}

		private bool validateURL()
		{
			//       Regex regular = new Regex(@"(?<protocol>http[s]?)://(?<host>([\w-])+(\.[\w-]+)*)(?<port>:\d*)?(?<uri>(/([\w\W]+)+)*)(?<query>\?.*)?");
			Regex regular = new Regex(@"(?<protocol>http[s]?)://(?<host>([\w-])+(\.[\w-]+)*)(?<port>:\d*)?(?<uri>(/([\w\W]+)+)*)");

			if (!regular.IsMatch(txtSoapUrl.Text.ToLower(System.Globalization.CultureInfo.CurrentCulture)))
            {
                MessageBox.Show("URL not in the right format", CLIENT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            MatchCollection mc = regular.Matches(txtSoapUrl.Text.ToLower(System.Globalization.CultureInfo.CurrentCulture));

            //string protocol = "";
            string host = "";
            string port = "";
            string uri = "";
            //string query = "";

            foreach (Match m in mc)
            {
                if (m.Length > 0)
                {
                    //protocol = m.Groups["protocol"].Value;
                    host = m.Groups["host"].Value;
                    port = m.Groups["port"].Value;
                    uri = m.Groups["uri"].Value;
                    //query = m.Groups["query"].Value;
                }
            }

            if ((port.Length > 0 && (0 == port.Substring(1).Length)) || (0 == uri.Length) || (0 == host.Length))
            {
                MessageBox.Show("URL not in the right format");
                return false;
            }
 			return true;
		}

		private void displayResultDetails(CustomerServiceResponse resp)
		{
			lblAccountBalance.Text = "Account Balance: " + resp.Account.CreditAccountBalance.ToString(System.Globalization.CultureInfo.CurrentCulture);
			lblCashAdvance.Text = "Cash Advance Limit: " + resp.Account.CashAdvanceLimitAmount.ToString(System.Globalization.CultureInfo.CurrentCulture);
			lblCreditLimit.Text = "Credit Limit: " + resp.Account.CreditLimit.ToString(System.Globalization.CultureInfo.CurrentCulture);
			lblLastPayment.Text = "Last Payment: " + resp.Account.TotalLastPaymentAmount.ToString(System.Globalization.CultureInfo.CurrentCulture);
			lblPendingTrans.Text = "Pending Trans: " + resp.Account.TotalPendingTransactionAmount.ToString(System.Globalization.CultureInfo.CurrentCulture);

			string[] resultText = { resp.ResponseStatus.Result };

			txtStatus.Lines = resultText;

		}

		private void displayErrorDetails(CustomerServiceResponse resp)
		{
			// Assemble the error information and display...

			string[] errText = {
											"Error Details:",
											"",
											"Error Number = " + resp.ResponseStatus.Error.ErrorNumber,
										    "Error Description = " + resp.ResponseStatus.Error.ErrorDescription,
										    "Error Source = " + resp.ResponseStatus.Error.ErrorSource,
										    "",
 											"From SAP System:",
											"Error Number = " + resp.ResponseStatus.Error.SAPError.ErrorNumber,
										    "Error Description = " + resp.ResponseStatus.Error.SAPError.ErrorDescription,
											"Error Source = " + resp.ResponseStatus.Error.SAPError.ErrorSource,
											"",
										    "From Payment Tracking System:",
										    "Error Number = " + resp.ResponseStatus.Error.PaymentTrackingError.ErrorNumber,
										    "Error Description = " + resp.ResponseStatus.Error.PaymentTrackingError.ErrorDescription,
										    "Error Source = " + resp.ResponseStatus.Error.PaymentTrackingError.ErrorSource,
										    "",
										    "From Pending Transactions System:",
											"Error Number = " + resp.ResponseStatus.Error.PendingTransactionsError.ErrorNumber,
										    "Error Description = " + resp.ResponseStatus.Error.PendingTransactionsError.ErrorDescription,
											"Error Source = " + resp.ResponseStatus.Error.PendingTransactionsError.ErrorSource
									   };

			txtStatus.Lines = errText;
			MessageBox.Show("Request Failed", CLIENT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private static bool isValid (string accountNumber)
		{
			if (accountNumber.Length != ACCOUNT_NUM_LENGTH)
			{
				return false;
			}

			for (int i = 0 ; i < accountNumber.Length; i++)
			{
				if (! Char.IsDigit(accountNumber,i))
				{
					return false;
				}
			}

			return true;
		}

		private void clearDisplay()
		{
			txtStatus.Clear(); 
			lblAccountBalance.Text = "";
			lblCashAdvance.Text = "";
			lblCreditLimit.Text = "";
			lblLastPayment.Text = "";
			lblPendingTrans.Text = "";
			lblTimeTaken.Text = "";
		}

		private void choiceSOAPTransport_CheckedChanged(object sender, System.EventArgs e)
		{
			txtSoapUrl.Enabled = choiceSOAPTransport.Checked;
			choiceAdapterWS.Enabled = choiceSOAPTransport.Checked;
			choiceInlineWS.Enabled = choiceSOAPTransport.Checked;
			choiceStubWS.Enabled = choiceSOAPTransport.Checked;
		}

		
		private void choiceMQSeriesTransport_CheckedChanged(object sender, System.EventArgs e)
		{
			txtChannelDefinition.Enabled = choiceMQSeriesTransport.Checked;
			txtQueueManager.Enabled = choiceMQSeriesTransport.Checked; 
			txtInputQueue.Enabled = choiceMQSeriesTransport.Checked;
			txtOutputQueue.Enabled = choiceMQSeriesTransport.Checked;
		}

		/// <summary>
		/// Assemble an instance of the CustomerRequest from the values supplied.
		/// </summary>
		/// <param name="requestID"></param>
		/// <param name="requestSource"></param>
		/// <param name="requestType"></param>
		/// <param name="accountNumber"></param>
		/// <param name="authNames">
		/// Array list - of Authentication data names
		/// </param>
		/// <param name="authValues">
		/// Array List - of corresponding authentication data values.  Related to the authNames parameter via array index
		/// </param>
		/// <returns></returns>
		/// 
		private static CustomerServiceRequest AssembleRequest(string requestID, string requestSource, string requestType, string accountNumber, ArrayList authNames, ArrayList authValues)
		{
			CustomerServiceRequest req = new CustomerServiceRequest();
			req.RequestID = requestID ;
			req.RequestSource = requestSource ;
			req.RequestType = requestType ;

			CustomerServiceRequestBody body = new CustomerServiceRequestBody ();
	
			body.AccountNumber = accountNumber ;
				
			body.AuthenticationInfo = new CustomerServiceRequestBodyAuthenticationInfo[authNames.Count];

			for (int i = 0 ; i < authNames.Count; i++)
			{
				CustomerServiceRequestBodyAuthenticationInfo authInfo = new CustomerServiceRequestBodyAuthenticationInfo ();
				authInfo.DataElementName  = (string)authNames[i];
				authInfo.DataElementValue = (string)authValues[i] ;
				
				body.AuthenticationInfo [i] = authInfo;
			}
	
			req.Body = body;

			return req;
		}

		/// <summary>
		/// Perform the Customer Service request using web services
		/// </summary>
		/// <param name="req">
		/// Customer service request
		/// </param>
		/// <param name="url" >
		/// url to the web service to call
		/// </param>
		/// <returns>
		/// Customre service response
		/// </returns>
		private static CustomerServiceResponse doWebServiceRequestResponse(CustomerServiceRequest req, string url, int whichWebService)
		{
			if (0 == whichWebService)	// Inline
			{
				CustomerService.Microsoft_Samples_BizTalk_WoodgroveBank_Orchestrations_Inline_CustomerServiceNativeRequestResponse_CustomerServicePort svcInline = new Microsoft_Samples_BizTalk_WoodgroveBank_Orchestrations_Inline_CustomerServiceNativeRequestResponse_CustomerServicePort();
				svcInline.Url = url;
				svcInline.Credentials = System.Net.CredentialCache.DefaultCredentials ;
				return svcInline.GetAccountInfo  (req);
			}
			else if (1 == whichWebService) // Adapter
			{
				CustomerService.Microsoft_Samples_BizTalk_WoodgroveBank_Orchestrations_Adapter_CustomerServiceNativeRequestResponse_CustomerServicePort svcAdapter = new Microsoft_Samples_BizTalk_WoodgroveBank_Orchestrations_Adapter_CustomerServiceNativeRequestResponse_CustomerServicePort();
				svcAdapter.Url = url;
				svcAdapter.Credentials = System.Net.CredentialCache.DefaultCredentials ;
				return svcAdapter.GetAccountInfo  (req);
			}
			else
			{
				CustomerService.Microsoft_Samples_BizTalk_WoodgroveBank_Orchestrations_Stubbed_CustomerServiceNativeRequestResponse_CustomerServicePort svcStub = new Microsoft_Samples_BizTalk_WoodgroveBank_Orchestrations_Stubbed_CustomerServiceNativeRequestResponse_CustomerServicePort();
				svcStub.Url = url;
				svcStub.Credentials = System.Net.CredentialCache.DefaultCredentials;
				return svcStub.GetAccountInfo(req);
			}
		}

		/// <summary>
		/// Perform the customer service request using MQ Series
		/// </summary>
		/// <param name="req">
		/// Customer Service Request
		/// </param>
		/// <param name="channelDefinition">
		/// MQ Series Channel Definition
		/// </param>
		/// <param name="qManager">
		/// MQ Series Queue manager name
		/// </param>
		/// <param name="sendQueue">
		/// MQ Series queue name to send the message - the request messaage is sent in this queue
		/// </param>
		/// <param name="receiveQueue">
		/// MQ Series queue name to receive the message - the response message is received in this queue
		/// </param>
		/// <returns>
		/// Customer Service Response
		/// </returns>
		private static CustomerServiceResponse doMQSeriesRequestResponse(CustomerServiceRequest req, string channelDefinition, string qManager, string sendQueue, string receiveQueue)
		{
			XmlSerializer xsReq = new XmlSerializer(typeof(CustomerServiceRequest),"http://Microsoft.Samples.BizTalk.WoodgroveBank.Schemas.CustomerServiceRequest");
			MemoryStream reqStream = new MemoryStream();
			xsReq.Serialize(reqStream, req);
			string reqMsg = System.Text.Encoding.UTF8.GetString(reqStream.ToArray());
			reqStream.Close();

			byte[] responseMsg = helperMQSendReceive(reqMsg, channelDefinition, qManager, sendQueue, receiveQueue);
		
			XmlSerializer xsResp = new XmlSerializer(typeof(CustomerServiceResponse),"http://Microsoft.Samples.BizTalk.WoodgroveBank.Schemas.CustomerServiceResponse");
			MemoryStream respStream = new MemoryStream(responseMsg);
			CustomerServiceResponse response = (CustomerServiceResponse)(xsResp.Deserialize(new XmlTextReader(respStream)));
			respStream.Close();

			return response;
		}

		/// <summary>
		/// simple helper function to send a message in an MQ Series queue, and receive the response in another queue
		/// </summary>
		/// <param name="msgToSend">
		/// string - input message to send
		/// </param>
		/// <param name="channelDefinition">
		/// string - MQSeries Channel Definition - when using a remote queue manager.  This should be of the form
		/// channel-name/transport/hostname(port) - refer to MQSeries docs for more info.
		/// </param>
		/// <param name="qManager">
		/// string - queue manager name
		/// </param>
		/// <param name="sndQueue">
		/// string - Send queue name
		/// </param>
		/// <param name="rcvQueue">
		/// string - Receive queue name
		/// </param>
		/// <returns>
		/// The received message as a byte array
		/// </returns>
		private static byte[] helperMQSendReceive (string msgToSend, string channelDefinition, string qManager, string sndQueue, string rcvQueue)
		{
			MQQueueManager mqQManager ;
			MQQueue mqSend = null;         // MQQueue instances
			MQQueue mqReceive = null;
			
			try 
			{
				if (0 == channelDefinition.Length)
				{
					mqQManager = new MQQueueManager(qManager);
				}
				else
				{
					string channelName = "";
					string connectionName = "";
					char[] separator = {'/'};
					string[] parts;
					parts = channelDefinition.Split( separator );
					if (parts.Length > 0) channelName = parts[0];
					if (parts.Length > 2) connectionName = parts[2];

					mqQManager = new MQQueueManager(qManager, channelName, connectionName);
				}

				mqSend = mqQManager.AccessQueue(sndQueue, 
									MQC.MQOO_OUTPUT						// open queue for output
									+ MQC.MQOO_FAIL_IF_QUIESCING );     // but not if MQM stopping

				MQMessage sndMessage = new MQMessage();
				byte[] data = convertToBytes(msgToSend);
				sndMessage.Write(data);
				sndMessage.Format = MQC.MQFMT_STRING;
				MQPutMessageOptions putMsgOptions = new MQPutMessageOptions();

				mqSend.Put( sndMessage, putMsgOptions );

				mqReceive = mqQManager.AccessQueue(rcvQueue,
							MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING);

				MQMessage rcvMessage = new MQMessage();
				MQGetMessageOptions getMsgOpts = new MQGetMessageOptions();
				getMsgOpts.Options = MQC.MQGMO_WAIT;
                getMsgOpts.MatchOptions = MQC.MQMO_MATCH_CORREL_ID;
				getMsgOpts.WaitInterval = 60000;

				rcvMessage.CorrelationId = sndMessage.MessageId;

				mqReceive.Get(rcvMessage, getMsgOpts);

				if(rcvMessage.Format.CompareTo(MQC.MQFMT_STRING) == 0)
				{
					rcvMessage.Seek(0);
					return rcvMessage.ReadBytes(rcvMessage.MessageLength);
				}
				else
				{
					throw new NotSupportedException(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Unsupported message format '{0}' read from queue.", rcvMessage.Format));
				}
			}
			//catch (MQException mqe) 
			//{
			//    throw new ApplicationException("Error from MQ Series Transport", mqe);
			//}

			finally
			{	
				if (null != mqSend)
				{
					mqSend.Close();
				}
				if (null != mqReceive)
				{
					mqReceive.Close();
				}
			}
		}

		/// <summary>
		/// Convert a string to byte array
		/// </summary>
		/// <param name="str">
		/// string - to be converted
		/// </param>
		/// <returns>byte array created from the string
		/// </returns>
		private static byte[] convertToBytes(string str)
		{
			byte[] data = null;
			if (str != null)
				data = UTF8Encoding.UTF8.GetBytes(str);

			return data;
		}
	}
}

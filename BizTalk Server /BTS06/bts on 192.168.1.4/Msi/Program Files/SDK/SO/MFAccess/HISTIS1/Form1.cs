//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.HISTIComponent.SimpleTester
// Simple client to test the HIS Pending Transactions component 
// 
//
// Copyright (C) Microsoft Corporation.  All rights reserved.
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
using SOHISTIUsingCOM;

namespace Microsoft.Samples.BizTalk.WoodgroveBank.HISTIComponent.SimpleTester
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormSimpleTester : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtAcctNum;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtNumRecordsReturned;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button cmdExecuteUsingCOM;
		private System.Windows.Forms.TextBox txtTranDate;
		private System.Windows.Forms.TextBox txtTranAmount;
		private System.Windows.Forms.TextBox txtMerchantName;
		private System.Windows.Forms.TextBox txtMerchantCity;
		private System.Windows.Forms.TextBox txtMerchantCountry;
		private System.Windows.Forms.Label lblRecordId;
		private System.ComponentModel.IContainer components;

		public FormSimpleTester()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormSimpleTester));
			this.txtAcctNum = new System.Windows.Forms.TextBox();
			this.txtTranDate = new System.Windows.Forms.TextBox();
			this.txtNumRecordsReturned = new System.Windows.Forms.TextBox();
			this.txtTranAmount = new System.Windows.Forms.TextBox();
			this.cmdExecuteUsingCOM = new System.Windows.Forms.Button();
			this.txtMerchantName = new System.Windows.Forms.TextBox();
			this.txtMerchantCity = new System.Windows.Forms.TextBox();
			this.txtMerchantCountry = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblRecordId = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtAcctNum
			// 
			this.txtAcctNum.AccessibleDescription = resources.GetString("txtAcctNum.AccessibleDescription");
			this.txtAcctNum.AccessibleName = resources.GetString("txtAcctNum.AccessibleName");
			this.txtAcctNum.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtAcctNum.Anchor")));
			this.txtAcctNum.AutoSize = ((bool)(resources.GetObject("txtAcctNum.AutoSize")));
			this.txtAcctNum.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtAcctNum.BackgroundImage")));
			this.txtAcctNum.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtAcctNum.Dock")));
			this.txtAcctNum.Enabled = ((bool)(resources.GetObject("txtAcctNum.Enabled")));
			this.txtAcctNum.Font = ((System.Drawing.Font)(resources.GetObject("txtAcctNum.Font")));
			this.txtAcctNum.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtAcctNum.ImeMode")));
			this.txtAcctNum.Location = ((System.Drawing.Point)(resources.GetObject("txtAcctNum.Location")));
			this.txtAcctNum.MaxLength = ((int)(resources.GetObject("txtAcctNum.MaxLength")));
			this.txtAcctNum.Multiline = ((bool)(resources.GetObject("txtAcctNum.Multiline")));
			this.txtAcctNum.Name = "txtAcctNum";
			this.txtAcctNum.PasswordChar = ((char)(resources.GetObject("txtAcctNum.PasswordChar")));
			this.txtAcctNum.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtAcctNum.RightToLeft")));
			this.txtAcctNum.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtAcctNum.ScrollBars")));
			this.txtAcctNum.Size = ((System.Drawing.Size)(resources.GetObject("txtAcctNum.Size")));
			this.txtAcctNum.TabIndex = ((int)(resources.GetObject("txtAcctNum.TabIndex")));
			this.txtAcctNum.Text = resources.GetString("txtAcctNum.Text");
			this.txtAcctNum.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtAcctNum.TextAlign")));
			this.txtAcctNum.Visible = ((bool)(resources.GetObject("txtAcctNum.Visible")));
			this.txtAcctNum.WordWrap = ((bool)(resources.GetObject("txtAcctNum.WordWrap")));
			// 
			// txtTranDate
			// 
			this.txtTranDate.AccessibleDescription = resources.GetString("txtTranDate.AccessibleDescription");
			this.txtTranDate.AccessibleName = resources.GetString("txtTranDate.AccessibleName");
			this.txtTranDate.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtTranDate.Anchor")));
			this.txtTranDate.AutoSize = ((bool)(resources.GetObject("txtTranDate.AutoSize")));
			this.txtTranDate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtTranDate.BackgroundImage")));
			this.txtTranDate.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtTranDate.Dock")));
			this.txtTranDate.Enabled = ((bool)(resources.GetObject("txtTranDate.Enabled")));
			this.txtTranDate.Font = ((System.Drawing.Font)(resources.GetObject("txtTranDate.Font")));
			this.txtTranDate.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtTranDate.ImeMode")));
			this.txtTranDate.Location = ((System.Drawing.Point)(resources.GetObject("txtTranDate.Location")));
			this.txtTranDate.MaxLength = ((int)(resources.GetObject("txtTranDate.MaxLength")));
			this.txtTranDate.Multiline = ((bool)(resources.GetObject("txtTranDate.Multiline")));
			this.txtTranDate.Name = "txtTranDate";
			this.txtTranDate.PasswordChar = ((char)(resources.GetObject("txtTranDate.PasswordChar")));
			this.txtTranDate.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtTranDate.RightToLeft")));
			this.txtTranDate.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtTranDate.ScrollBars")));
			this.txtTranDate.Size = ((System.Drawing.Size)(resources.GetObject("txtTranDate.Size")));
			this.txtTranDate.TabIndex = ((int)(resources.GetObject("txtTranDate.TabIndex")));
			this.txtTranDate.Text = resources.GetString("txtTranDate.Text");
			this.txtTranDate.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtTranDate.TextAlign")));
			this.txtTranDate.Visible = ((bool)(resources.GetObject("txtTranDate.Visible")));
			this.txtTranDate.WordWrap = ((bool)(resources.GetObject("txtTranDate.WordWrap")));
			// 
			// txtNumRecordsReturned
			// 
			this.txtNumRecordsReturned.AccessibleDescription = resources.GetString("txtNumRecordsReturned.AccessibleDescription");
			this.txtNumRecordsReturned.AccessibleName = resources.GetString("txtNumRecordsReturned.AccessibleName");
			this.txtNumRecordsReturned.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtNumRecordsReturned.Anchor")));
			this.txtNumRecordsReturned.AutoSize = ((bool)(resources.GetObject("txtNumRecordsReturned.AutoSize")));
			this.txtNumRecordsReturned.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtNumRecordsReturned.BackgroundImage")));
			this.txtNumRecordsReturned.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtNumRecordsReturned.Dock")));
			this.txtNumRecordsReturned.Enabled = ((bool)(resources.GetObject("txtNumRecordsReturned.Enabled")));
			this.txtNumRecordsReturned.Font = ((System.Drawing.Font)(resources.GetObject("txtNumRecordsReturned.Font")));
			this.txtNumRecordsReturned.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtNumRecordsReturned.ImeMode")));
			this.txtNumRecordsReturned.Location = ((System.Drawing.Point)(resources.GetObject("txtNumRecordsReturned.Location")));
			this.txtNumRecordsReturned.MaxLength = ((int)(resources.GetObject("txtNumRecordsReturned.MaxLength")));
			this.txtNumRecordsReturned.Multiline = ((bool)(resources.GetObject("txtNumRecordsReturned.Multiline")));
			this.txtNumRecordsReturned.Name = "txtNumRecordsReturned";
			this.txtNumRecordsReturned.PasswordChar = ((char)(resources.GetObject("txtNumRecordsReturned.PasswordChar")));
			this.txtNumRecordsReturned.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtNumRecordsReturned.RightToLeft")));
			this.txtNumRecordsReturned.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtNumRecordsReturned.ScrollBars")));
			this.txtNumRecordsReturned.Size = ((System.Drawing.Size)(resources.GetObject("txtNumRecordsReturned.Size")));
			this.txtNumRecordsReturned.TabIndex = ((int)(resources.GetObject("txtNumRecordsReturned.TabIndex")));
			this.txtNumRecordsReturned.Text = resources.GetString("txtNumRecordsReturned.Text");
			this.txtNumRecordsReturned.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtNumRecordsReturned.TextAlign")));
			this.txtNumRecordsReturned.Visible = ((bool)(resources.GetObject("txtNumRecordsReturned.Visible")));
			this.txtNumRecordsReturned.WordWrap = ((bool)(resources.GetObject("txtNumRecordsReturned.WordWrap")));
			// 
			// txtTranAmount
			// 
			this.txtTranAmount.AccessibleDescription = resources.GetString("txtTranAmount.AccessibleDescription");
			this.txtTranAmount.AccessibleName = resources.GetString("txtTranAmount.AccessibleName");
			this.txtTranAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtTranAmount.Anchor")));
			this.txtTranAmount.AutoSize = ((bool)(resources.GetObject("txtTranAmount.AutoSize")));
			this.txtTranAmount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtTranAmount.BackgroundImage")));
			this.txtTranAmount.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtTranAmount.Dock")));
			this.txtTranAmount.Enabled = ((bool)(resources.GetObject("txtTranAmount.Enabled")));
			this.txtTranAmount.Font = ((System.Drawing.Font)(resources.GetObject("txtTranAmount.Font")));
			this.txtTranAmount.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtTranAmount.ImeMode")));
			this.txtTranAmount.Location = ((System.Drawing.Point)(resources.GetObject("txtTranAmount.Location")));
			this.txtTranAmount.MaxLength = ((int)(resources.GetObject("txtTranAmount.MaxLength")));
			this.txtTranAmount.Multiline = ((bool)(resources.GetObject("txtTranAmount.Multiline")));
			this.txtTranAmount.Name = "txtTranAmount";
			this.txtTranAmount.PasswordChar = ((char)(resources.GetObject("txtTranAmount.PasswordChar")));
			this.txtTranAmount.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtTranAmount.RightToLeft")));
			this.txtTranAmount.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtTranAmount.ScrollBars")));
			this.txtTranAmount.Size = ((System.Drawing.Size)(resources.GetObject("txtTranAmount.Size")));
			this.txtTranAmount.TabIndex = ((int)(resources.GetObject("txtTranAmount.TabIndex")));
			this.txtTranAmount.Text = resources.GetString("txtTranAmount.Text");
			this.txtTranAmount.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtTranAmount.TextAlign")));
			this.txtTranAmount.Visible = ((bool)(resources.GetObject("txtTranAmount.Visible")));
			this.txtTranAmount.WordWrap = ((bool)(resources.GetObject("txtTranAmount.WordWrap")));
			// 
			// cmdExecuteUsingCOM
			// 
			this.cmdExecuteUsingCOM.AccessibleDescription = resources.GetString("cmdExecuteUsingCOM.AccessibleDescription");
			this.cmdExecuteUsingCOM.AccessibleName = resources.GetString("cmdExecuteUsingCOM.AccessibleName");
			this.cmdExecuteUsingCOM.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdExecuteUsingCOM.Anchor")));
			this.cmdExecuteUsingCOM.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdExecuteUsingCOM.BackgroundImage")));
			this.cmdExecuteUsingCOM.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdExecuteUsingCOM.Dock")));
			this.cmdExecuteUsingCOM.Enabled = ((bool)(resources.GetObject("cmdExecuteUsingCOM.Enabled")));
			this.cmdExecuteUsingCOM.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdExecuteUsingCOM.FlatStyle")));
			this.cmdExecuteUsingCOM.Font = ((System.Drawing.Font)(resources.GetObject("cmdExecuteUsingCOM.Font")));
			this.cmdExecuteUsingCOM.Image = ((System.Drawing.Image)(resources.GetObject("cmdExecuteUsingCOM.Image")));
			this.cmdExecuteUsingCOM.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdExecuteUsingCOM.ImageAlign")));
			this.cmdExecuteUsingCOM.ImageIndex = ((int)(resources.GetObject("cmdExecuteUsingCOM.ImageIndex")));
			this.cmdExecuteUsingCOM.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdExecuteUsingCOM.ImeMode")));
			this.cmdExecuteUsingCOM.Location = ((System.Drawing.Point)(resources.GetObject("cmdExecuteUsingCOM.Location")));
			this.cmdExecuteUsingCOM.Name = "cmdExecuteUsingCOM";
			this.cmdExecuteUsingCOM.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdExecuteUsingCOM.RightToLeft")));
			this.cmdExecuteUsingCOM.Size = ((System.Drawing.Size)(resources.GetObject("cmdExecuteUsingCOM.Size")));
			this.cmdExecuteUsingCOM.TabIndex = ((int)(resources.GetObject("cmdExecuteUsingCOM.TabIndex")));
			this.cmdExecuteUsingCOM.Text = resources.GetString("cmdExecuteUsingCOM.Text");
			this.cmdExecuteUsingCOM.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdExecuteUsingCOM.TextAlign")));
			this.cmdExecuteUsingCOM.Visible = ((bool)(resources.GetObject("cmdExecuteUsingCOM.Visible")));
			this.cmdExecuteUsingCOM.Click += new System.EventHandler(this.cmdExecuteUsingCOM_Click);
			// 
			// txtMerchantName
			// 
			this.txtMerchantName.AccessibleDescription = resources.GetString("txtMerchantName.AccessibleDescription");
			this.txtMerchantName.AccessibleName = resources.GetString("txtMerchantName.AccessibleName");
			this.txtMerchantName.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtMerchantName.Anchor")));
			this.txtMerchantName.AutoSize = ((bool)(resources.GetObject("txtMerchantName.AutoSize")));
			this.txtMerchantName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtMerchantName.BackgroundImage")));
			this.txtMerchantName.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtMerchantName.Dock")));
			this.txtMerchantName.Enabled = ((bool)(resources.GetObject("txtMerchantName.Enabled")));
			this.txtMerchantName.Font = ((System.Drawing.Font)(resources.GetObject("txtMerchantName.Font")));
			this.txtMerchantName.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtMerchantName.ImeMode")));
			this.txtMerchantName.Location = ((System.Drawing.Point)(resources.GetObject("txtMerchantName.Location")));
			this.txtMerchantName.MaxLength = ((int)(resources.GetObject("txtMerchantName.MaxLength")));
			this.txtMerchantName.Multiline = ((bool)(resources.GetObject("txtMerchantName.Multiline")));
			this.txtMerchantName.Name = "txtMerchantName";
			this.txtMerchantName.PasswordChar = ((char)(resources.GetObject("txtMerchantName.PasswordChar")));
			this.txtMerchantName.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtMerchantName.RightToLeft")));
			this.txtMerchantName.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtMerchantName.ScrollBars")));
			this.txtMerchantName.Size = ((System.Drawing.Size)(resources.GetObject("txtMerchantName.Size")));
			this.txtMerchantName.TabIndex = ((int)(resources.GetObject("txtMerchantName.TabIndex")));
			this.txtMerchantName.Text = resources.GetString("txtMerchantName.Text");
			this.txtMerchantName.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtMerchantName.TextAlign")));
			this.txtMerchantName.Visible = ((bool)(resources.GetObject("txtMerchantName.Visible")));
			this.txtMerchantName.WordWrap = ((bool)(resources.GetObject("txtMerchantName.WordWrap")));
			// 
			// txtMerchantCity
			// 
			this.txtMerchantCity.AccessibleDescription = resources.GetString("txtMerchantCity.AccessibleDescription");
			this.txtMerchantCity.AccessibleName = resources.GetString("txtMerchantCity.AccessibleName");
			this.txtMerchantCity.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtMerchantCity.Anchor")));
			this.txtMerchantCity.AutoSize = ((bool)(resources.GetObject("txtMerchantCity.AutoSize")));
			this.txtMerchantCity.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtMerchantCity.BackgroundImage")));
			this.txtMerchantCity.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtMerchantCity.Dock")));
			this.txtMerchantCity.Enabled = ((bool)(resources.GetObject("txtMerchantCity.Enabled")));
			this.txtMerchantCity.Font = ((System.Drawing.Font)(resources.GetObject("txtMerchantCity.Font")));
			this.txtMerchantCity.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtMerchantCity.ImeMode")));
			this.txtMerchantCity.Location = ((System.Drawing.Point)(resources.GetObject("txtMerchantCity.Location")));
			this.txtMerchantCity.MaxLength = ((int)(resources.GetObject("txtMerchantCity.MaxLength")));
			this.txtMerchantCity.Multiline = ((bool)(resources.GetObject("txtMerchantCity.Multiline")));
			this.txtMerchantCity.Name = "txtMerchantCity";
			this.txtMerchantCity.PasswordChar = ((char)(resources.GetObject("txtMerchantCity.PasswordChar")));
			this.txtMerchantCity.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtMerchantCity.RightToLeft")));
			this.txtMerchantCity.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtMerchantCity.ScrollBars")));
			this.txtMerchantCity.Size = ((System.Drawing.Size)(resources.GetObject("txtMerchantCity.Size")));
			this.txtMerchantCity.TabIndex = ((int)(resources.GetObject("txtMerchantCity.TabIndex")));
			this.txtMerchantCity.Text = resources.GetString("txtMerchantCity.Text");
			this.txtMerchantCity.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtMerchantCity.TextAlign")));
			this.txtMerchantCity.Visible = ((bool)(resources.GetObject("txtMerchantCity.Visible")));
			this.txtMerchantCity.WordWrap = ((bool)(resources.GetObject("txtMerchantCity.WordWrap")));
			// 
			// txtMerchantCountry
			// 
			this.txtMerchantCountry.AccessibleDescription = resources.GetString("txtMerchantCountry.AccessibleDescription");
			this.txtMerchantCountry.AccessibleName = resources.GetString("txtMerchantCountry.AccessibleName");
			this.txtMerchantCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtMerchantCountry.Anchor")));
			this.txtMerchantCountry.AutoSize = ((bool)(resources.GetObject("txtMerchantCountry.AutoSize")));
			this.txtMerchantCountry.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtMerchantCountry.BackgroundImage")));
			this.txtMerchantCountry.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtMerchantCountry.Dock")));
			this.txtMerchantCountry.Enabled = ((bool)(resources.GetObject("txtMerchantCountry.Enabled")));
			this.txtMerchantCountry.Font = ((System.Drawing.Font)(resources.GetObject("txtMerchantCountry.Font")));
			this.txtMerchantCountry.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtMerchantCountry.ImeMode")));
			this.txtMerchantCountry.Location = ((System.Drawing.Point)(resources.GetObject("txtMerchantCountry.Location")));
			this.txtMerchantCountry.MaxLength = ((int)(resources.GetObject("txtMerchantCountry.MaxLength")));
			this.txtMerchantCountry.Multiline = ((bool)(resources.GetObject("txtMerchantCountry.Multiline")));
			this.txtMerchantCountry.Name = "txtMerchantCountry";
			this.txtMerchantCountry.PasswordChar = ((char)(resources.GetObject("txtMerchantCountry.PasswordChar")));
			this.txtMerchantCountry.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtMerchantCountry.RightToLeft")));
			this.txtMerchantCountry.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtMerchantCountry.ScrollBars")));
			this.txtMerchantCountry.Size = ((System.Drawing.Size)(resources.GetObject("txtMerchantCountry.Size")));
			this.txtMerchantCountry.TabIndex = ((int)(resources.GetObject("txtMerchantCountry.TabIndex")));
			this.txtMerchantCountry.Text = resources.GetString("txtMerchantCountry.Text");
			this.txtMerchantCountry.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtMerchantCountry.TextAlign")));
			this.txtMerchantCountry.Visible = ((bool)(resources.GetObject("txtMerchantCountry.Visible")));
			this.txtMerchantCountry.WordWrap = ((bool)(resources.GetObject("txtMerchantCountry.WordWrap")));
			// 
			// label1
			// 
			this.label1.AccessibleDescription = resources.GetString("label1.AccessibleDescription");
			this.label1.AccessibleName = resources.GetString("label1.AccessibleName");
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label1.Anchor")));
			this.label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
			this.label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock")));
			this.label1.Enabled = ((bool)(resources.GetObject("label1.Enabled")));
			this.label1.Font = ((System.Drawing.Font)(resources.GetObject("label1.Font")));
			this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
			this.label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.ImageAlign")));
			this.label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
			this.label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label1.ImeMode")));
			this.label1.Location = ((System.Drawing.Point)(resources.GetObject("label1.Location")));
			this.label1.Name = "label1";
			this.label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label1.RightToLeft")));
			this.label1.Size = ((System.Drawing.Size)(resources.GetObject("label1.Size")));
			this.label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
			this.label1.Text = resources.GetString("label1.Text");
			this.label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.TextAlign")));
			this.label1.Visible = ((bool)(resources.GetObject("label1.Visible")));
			// 
			// label2
			// 
			this.label2.AccessibleDescription = resources.GetString("label2.AccessibleDescription");
			this.label2.AccessibleName = resources.GetString("label2.AccessibleName");
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label2.Anchor")));
			this.label2.AutoSize = ((bool)(resources.GetObject("label2.AutoSize")));
			this.label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label2.Dock")));
			this.label2.Enabled = ((bool)(resources.GetObject("label2.Enabled")));
			this.label2.Font = ((System.Drawing.Font)(resources.GetObject("label2.Font")));
			this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
			this.label2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.ImageAlign")));
			this.label2.ImageIndex = ((int)(resources.GetObject("label2.ImageIndex")));
			this.label2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label2.ImeMode")));
			this.label2.Location = ((System.Drawing.Point)(resources.GetObject("label2.Location")));
			this.label2.Name = "label2";
			this.label2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label2.RightToLeft")));
			this.label2.Size = ((System.Drawing.Size)(resources.GetObject("label2.Size")));
			this.label2.TabIndex = ((int)(resources.GetObject("label2.TabIndex")));
			this.label2.Text = resources.GetString("label2.Text");
			this.label2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.TextAlign")));
			this.label2.Visible = ((bool)(resources.GetObject("label2.Visible")));
			// 
			// label3
			// 
			this.label3.AccessibleDescription = resources.GetString("label3.AccessibleDescription");
			this.label3.AccessibleName = resources.GetString("label3.AccessibleName");
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label3.Anchor")));
			this.label3.AutoSize = ((bool)(resources.GetObject("label3.AutoSize")));
			this.label3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label3.Dock")));
			this.label3.Enabled = ((bool)(resources.GetObject("label3.Enabled")));
			this.label3.Font = ((System.Drawing.Font)(resources.GetObject("label3.Font")));
			this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
			this.label3.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.ImageAlign")));
			this.label3.ImageIndex = ((int)(resources.GetObject("label3.ImageIndex")));
			this.label3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label3.ImeMode")));
			this.label3.Location = ((System.Drawing.Point)(resources.GetObject("label3.Location")));
			this.label3.Name = "label3";
			this.label3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label3.RightToLeft")));
			this.label3.Size = ((System.Drawing.Size)(resources.GetObject("label3.Size")));
			this.label3.TabIndex = ((int)(resources.GetObject("label3.TabIndex")));
			this.label3.Text = resources.GetString("label3.Text");
			this.label3.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.TextAlign")));
			this.label3.Visible = ((bool)(resources.GetObject("label3.Visible")));
			// 
			// label4
			// 
			this.label4.AccessibleDescription = resources.GetString("label4.AccessibleDescription");
			this.label4.AccessibleName = resources.GetString("label4.AccessibleName");
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label4.Anchor")));
			this.label4.AutoSize = ((bool)(resources.GetObject("label4.AutoSize")));
			this.label4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label4.Dock")));
			this.label4.Enabled = ((bool)(resources.GetObject("label4.Enabled")));
			this.label4.Font = ((System.Drawing.Font)(resources.GetObject("label4.Font")));
			this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
			this.label4.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label4.ImageAlign")));
			this.label4.ImageIndex = ((int)(resources.GetObject("label4.ImageIndex")));
			this.label4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label4.ImeMode")));
			this.label4.Location = ((System.Drawing.Point)(resources.GetObject("label4.Location")));
			this.label4.Name = "label4";
			this.label4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label4.RightToLeft")));
			this.label4.Size = ((System.Drawing.Size)(resources.GetObject("label4.Size")));
			this.label4.TabIndex = ((int)(resources.GetObject("label4.TabIndex")));
			this.label4.Text = resources.GetString("label4.Text");
			this.label4.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label4.TextAlign")));
			this.label4.Visible = ((bool)(resources.GetObject("label4.Visible")));
			// 
			// label5
			// 
			this.label5.AccessibleDescription = resources.GetString("label5.AccessibleDescription");
			this.label5.AccessibleName = resources.GetString("label5.AccessibleName");
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label5.Anchor")));
			this.label5.AutoSize = ((bool)(resources.GetObject("label5.AutoSize")));
			this.label5.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label5.Dock")));
			this.label5.Enabled = ((bool)(resources.GetObject("label5.Enabled")));
			this.label5.Font = ((System.Drawing.Font)(resources.GetObject("label5.Font")));
			this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
			this.label5.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label5.ImageAlign")));
			this.label5.ImageIndex = ((int)(resources.GetObject("label5.ImageIndex")));
			this.label5.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label5.ImeMode")));
			this.label5.Location = ((System.Drawing.Point)(resources.GetObject("label5.Location")));
			this.label5.Name = "label5";
			this.label5.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label5.RightToLeft")));
			this.label5.Size = ((System.Drawing.Size)(resources.GetObject("label5.Size")));
			this.label5.TabIndex = ((int)(resources.GetObject("label5.TabIndex")));
			this.label5.Text = resources.GetString("label5.Text");
			this.label5.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label5.TextAlign")));
			this.label5.Visible = ((bool)(resources.GetObject("label5.Visible")));
			// 
			// label6
			// 
			this.label6.AccessibleDescription = resources.GetString("label6.AccessibleDescription");
			this.label6.AccessibleName = resources.GetString("label6.AccessibleName");
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label6.Anchor")));
			this.label6.AutoSize = ((bool)(resources.GetObject("label6.AutoSize")));
			this.label6.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label6.Dock")));
			this.label6.Enabled = ((bool)(resources.GetObject("label6.Enabled")));
			this.label6.Font = ((System.Drawing.Font)(resources.GetObject("label6.Font")));
			this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
			this.label6.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label6.ImageAlign")));
			this.label6.ImageIndex = ((int)(resources.GetObject("label6.ImageIndex")));
			this.label6.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label6.ImeMode")));
			this.label6.Location = ((System.Drawing.Point)(resources.GetObject("label6.Location")));
			this.label6.Name = "label6";
			this.label6.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label6.RightToLeft")));
			this.label6.Size = ((System.Drawing.Size)(resources.GetObject("label6.Size")));
			this.label6.TabIndex = ((int)(resources.GetObject("label6.TabIndex")));
			this.label6.Text = resources.GetString("label6.Text");
			this.label6.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label6.TextAlign")));
			this.label6.Visible = ((bool)(resources.GetObject("label6.Visible")));
			// 
			// label7
			// 
			this.label7.AccessibleDescription = resources.GetString("label7.AccessibleDescription");
			this.label7.AccessibleName = resources.GetString("label7.AccessibleName");
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label7.Anchor")));
			this.label7.AutoSize = ((bool)(resources.GetObject("label7.AutoSize")));
			this.label7.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label7.Dock")));
			this.label7.Enabled = ((bool)(resources.GetObject("label7.Enabled")));
			this.label7.Font = ((System.Drawing.Font)(resources.GetObject("label7.Font")));
			this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
			this.label7.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label7.ImageAlign")));
			this.label7.ImageIndex = ((int)(resources.GetObject("label7.ImageIndex")));
			this.label7.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label7.ImeMode")));
			this.label7.Location = ((System.Drawing.Point)(resources.GetObject("label7.Location")));
			this.label7.Name = "label7";
			this.label7.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label7.RightToLeft")));
			this.label7.Size = ((System.Drawing.Size)(resources.GetObject("label7.Size")));
			this.label7.TabIndex = ((int)(resources.GetObject("label7.TabIndex")));
			this.label7.Text = resources.GetString("label7.Text");
			this.label7.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label7.TextAlign")));
			this.label7.Visible = ((bool)(resources.GetObject("label7.Visible")));
			// 
			// label8
			// 
			this.label8.AccessibleDescription = resources.GetString("label8.AccessibleDescription");
			this.label8.AccessibleName = resources.GetString("label8.AccessibleName");
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label8.Anchor")));
			this.label8.AutoSize = ((bool)(resources.GetObject("label8.AutoSize")));
			this.label8.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label8.Dock")));
			this.label8.Enabled = ((bool)(resources.GetObject("label8.Enabled")));
			this.label8.Font = ((System.Drawing.Font)(resources.GetObject("label8.Font")));
			this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
			this.label8.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label8.ImageAlign")));
			this.label8.ImageIndex = ((int)(resources.GetObject("label8.ImageIndex")));
			this.label8.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label8.ImeMode")));
			this.label8.Location = ((System.Drawing.Point)(resources.GetObject("label8.Location")));
			this.label8.Name = "label8";
			this.label8.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label8.RightToLeft")));
			this.label8.Size = ((System.Drawing.Size)(resources.GetObject("label8.Size")));
			this.label8.TabIndex = ((int)(resources.GetObject("label8.TabIndex")));
			this.label8.Text = resources.GetString("label8.Text");
			this.label8.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label8.TextAlign")));
			this.label8.Visible = ((bool)(resources.GetObject("label8.Visible")));
			// 
			// lblRecordId
			// 
			this.lblRecordId.AccessibleDescription = resources.GetString("lblRecordId.AccessibleDescription");
			this.lblRecordId.AccessibleName = resources.GetString("lblRecordId.AccessibleName");
			this.lblRecordId.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblRecordId.Anchor")));
			this.lblRecordId.AutoSize = ((bool)(resources.GetObject("lblRecordId.AutoSize")));
			this.lblRecordId.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblRecordId.Dock")));
			this.lblRecordId.Enabled = ((bool)(resources.GetObject("lblRecordId.Enabled")));
			this.lblRecordId.Font = ((System.Drawing.Font)(resources.GetObject("lblRecordId.Font")));
			this.lblRecordId.Image = ((System.Drawing.Image)(resources.GetObject("lblRecordId.Image")));
			this.lblRecordId.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblRecordId.ImageAlign")));
			this.lblRecordId.ImageIndex = ((int)(resources.GetObject("lblRecordId.ImageIndex")));
			this.lblRecordId.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblRecordId.ImeMode")));
			this.lblRecordId.Location = ((System.Drawing.Point)(resources.GetObject("lblRecordId.Location")));
			this.lblRecordId.Name = "lblRecordId";
			this.lblRecordId.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblRecordId.RightToLeft")));
			this.lblRecordId.Size = ((System.Drawing.Size)(resources.GetObject("lblRecordId.Size")));
			this.lblRecordId.TabIndex = ((int)(resources.GetObject("lblRecordId.TabIndex")));
			this.lblRecordId.Text = resources.GetString("lblRecordId.Text");
			this.lblRecordId.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblRecordId.TextAlign")));
			this.lblRecordId.Visible = ((bool)(resources.GetObject("lblRecordId.Visible")));
			// 
			// FormSimpleTester
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.lblRecordId);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtMerchantCountry);
			this.Controls.Add(this.txtMerchantCity);
			this.Controls.Add(this.txtMerchantName);
			this.Controls.Add(this.txtTranAmount);
			this.Controls.Add(this.txtNumRecordsReturned);
			this.Controls.Add(this.txtTranDate);
			this.Controls.Add(this.txtAcctNum);
			this.Controls.Add(this.cmdExecuteUsingCOM);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximizeBox = false;
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "FormSimpleTester";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormSimpleTester());
		}

		private const string CLIENT_NAME = "SO Scenario Simple Tester for the mainframe connection";
		private const int ACCOUNT_NUM_LENGTH = 16;

		private void clearTransactionsDisplay()
		{
			txtTranDate.Text = "";
			txtTranAmount.Text = "";
			txtMerchantName.Text = "";
			txtMerchantCity.Text = "";
			txtMerchantCountry.Text = "";
		}

		private void displayNumRecords(long numRecords)
		{
			txtNumRecordsReturned.Text = numRecords.ToString(System.Globalization.CultureInfo.CurrentCulture);
		}

		private void displayAccountNumber(string acctNum)
		{
			txtAcctNum.Text = acctNum;
		}

		private void displayTransactionRecord(long recordNum, string tranDate, decimal tranAmount, string merchantName, string metchantCity, string MerchantCountry)
		{
			lblRecordId.Text = "Record #" + recordNum.ToString(System.Globalization.CultureInfo.CurrentCulture) ;
			txtTranDate.Text = tranDate;
			txtTranAmount.Text = tranAmount.ToString(System.Globalization.CultureInfo.CurrentCulture);
			txtMerchantName.Text = merchantName;
			txtMerchantCity.Text = metchantCity;
			txtMerchantCountry.Text = MerchantCountry;
		}


		private bool isValid (string accountNumber)
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


		private void cmdExecuteUsingCOM_Click(object sender, System.EventArgs e)
		{

			if (! isValid(txtAcctNum.Text))
			{
				MessageBox.Show("Account number should be exactly " + Convert.ToString(ACCOUNT_NUM_LENGTH, System.Globalization.CultureInfo.CurrentCulture) + " digits long and numeric", CLIENT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				SOHISTIUsingCOM.PendingTransInCICS ptObj = new SOHISTIUsingCOM.PendingTransInCICS();
				string AcctNum = txtAcctNum.Text;
				short ErrNum;
				string ErrDesc, ErrSrc;
			
				SOHISTIUsingCOM.TRAN_TBL tranTbl;
			
				ptObj.GetPendingTransactions(ref AcctNum, out ErrDesc, out ErrNum, out ErrSrc, out tranTbl );

				displayNumRecords(tranTbl.COUNT);
	
				displayAccountNumber(AcctNum);

				clearTransactionsDisplay();

				for (int iRec = 1 ; iRec  <= tranTbl.COUNT ; iRec++)
				{
					SOHISTIUsingCOM.TRANS_REC transactionRec = (SOHISTIUsingCOM.TRANS_REC)tranTbl.MEMBER1.GetValue(iRec - 1);

					displayTransactionRecord (iRec, transactionRec.TRAN_DATE, transactionRec.TRAN_AMOUNT, transactionRec.MERCHANT_NAME, transactionRec.MERCHANT_CITY, transactionRec.MERCHANT_COUNTRY);
				
					if (iRec < tranTbl.COUNT)
					{
						DialogResult continueFlag;
						continueFlag = MessageBox.Show("Record #" + (iRec).ToString(System.Globalization.CultureInfo.CurrentCulture) + " of " + tranTbl.COUNT.ToString(System.Globalization.CultureInfo.CurrentCulture) + " Displayed, Continue?", CLIENT_NAME,
							MessageBoxButtons.YesNo, MessageBoxIcon.Question);

						if (continueFlag ==  DialogResult.No)
						{
							break;
						}
						clearTransactionsDisplay();
					}
				}
			}
			catch (System.Exception ex)
			{
				string errMsg = ex.ToString();
				string innerMsg = null != ex.InnerException ? ex.InnerException.ToString() : "" ;
				MessageBox.Show("Exception:\n" + errMsg + "\n" + "Inner Exception:\n" + innerMsg, CLIENT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}

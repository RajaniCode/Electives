using System;
using System.IO;
using System.Xml;
using Microsoft.Win32;

namespace Microsoft.Samples.BizTalk.CheckPartyName
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	/// 
	[Serializable()]
	public class Class1
	{
		public Class1()
		{
			// Get the install path for the BTS PartyResolution sample
			samplePath = Path.Combine(Registry.LocalMachine.OpenSubKey(
				@"SOFTWARE\Microsoft\BizTalk Server\3.0").GetValue("InstallPath").ToString(),
				@"SDK\Samples\Orchestrations\PartyResolution");
		}

		/// <summary>
		/// This method is invoked by Supplier Orchestration.
		/// GetPartName Method intakes the Party Object passed by Orchestration.
		/// This method extract the party name and updates Buyer.xml for File polling.exe to Alert the User
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public string GetPartName(Microsoft.XLANGs.BaseTypes.Party p)
		{
			XmlTextWriter xmlWriter = new XmlTextWriter(Path.Combine(samplePath, @"FileDrop\BuyerInformation\Buyer.xml"), null);
			xmlWriter.WriteElementString("Buyer", p.Name);
			xmlWriter.Close();
			return p.Name;
		}

		private string samplePath;
	}
}

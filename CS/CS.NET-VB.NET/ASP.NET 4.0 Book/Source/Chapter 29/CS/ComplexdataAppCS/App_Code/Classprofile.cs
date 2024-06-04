using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

/// <summary>
/// Summary description for Classprofile
/// </summary>
public class Classprofile
{
	
		private string Dy;
	private string Mnth;
	private string Yr;
	public string Day
	{
		get { return Dy; }
		set { Dy = value; }
	}
	public string Month
	{
		get { return Mnth; }
		set
		{
			Mnth = value;
		}
	}
	public string Year
	{
		get { return Yr; }
		set
		{
			Yr = value;
		}
	}

	
}
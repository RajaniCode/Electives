using System;
using PagingConsoleTest.Collections;
using Microsoft.ApplicationBlocks.Data;

namespace PagingConsoleTest
{
	/// <summary>
	/// Summary description for Paging.
	/// </summary>
	public class Paging
	{
		public static void Main(string[] args)
		{
			//Connection string
			string conStr = "server=localhost;Trusted_Connection=true;database=PagingTest";

			//This stored procedure name is read from the command arguments
			string spName = "";
			if (args.Length>0)
			{
				spName = args[0];
			}

			//Parameters for the stored procedure call
			string Tables = "LargeTable";
			string PK = "LargeTable.PK";
			string Sort = "LargeTable.PK";
			int PageNumber = 1;
			int PageSize = 10;
			string Fields = "*";
			string Filter = "";
			string Group = "";

			//Testing variables
			DateTime startTime;
			DateTime endTime;
			Random rand = new Random();

			//The collection of results for each page
			PageResponseTestCollection PageResponseTests = new PageResponseTestCollection();

			try
			{
				//The goal is to see how the response time of paging stored procedures behaves depending on how far the fecthed page is from the begining of the sorted set of data
				//Procedure is executed n times to flatten deviations caused by caching, the end result will be the average execution time
				for(int i=0;i<15000;i++)
				{
					//Get the random page from the set of 2^N pages
					PageNumber = (int)Math.Pow(2, rand.Next(0, 14));

					startTime = DateTime.Now;
					//Start timing
					SqlHelper.ExecuteNonQuery(conStr, spName, new object[]{Tables, PK, Sort, PageNumber, PageSize, Fields, Filter, Group});
					//Stop timing
					endTime = DateTime.Now;
					//If page doesn't exist in the collection, then add it
					if (PageResponseTests.IndexOfKey(PageNumber)==-1)
					{
						PageResponseTests.Add(PageNumber, new PageResponseTest(0, TimeSpan.Zero));
					}
					//Join the current result with other results from this page
					PageResponseTests[PageNumber].NumberOfRepeats++;
					PageResponseTests[PageNumber].ElapsedTime = PageResponseTests[PageNumber].ElapsedTime.Add(endTime-startTime);
					//Dummy progress bar indicator
					if (i%1500==0)
					{
						Console.Write(".");
					}
				}

				//Write results for every page
				Console.WriteLine("\nStored Procedure - {0}, Sorted by - {1}", spName, Sort);

				Console.WriteLine ("{0}\t{1}\t{2}", "Page", "AvgTime(ms)", "Repeated");	

				System.Collections.IEnumerator enumerator = PageResponseTests.Keys.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Console.WriteLine ("{0}\t{1}\t{2}", (int)enumerator.Current, PageResponseTests[(int)enumerator.Current].GetAverageResponseTimeInMs().ToString("f6"), PageResponseTests[(int)enumerator.Current].NumberOfRepeats);
				}
			}
			catch (Exception ex)
			{
				string message = (ex.InnerException==null ? ex.Message : ex.InnerException.Message);
				Console.WriteLine ("{0}: Failed ({1})", spName, message);
			}
		}
	}

}

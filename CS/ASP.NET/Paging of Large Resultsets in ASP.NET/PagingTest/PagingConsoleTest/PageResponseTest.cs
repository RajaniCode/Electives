using System;

namespace PagingConsoleTest
{
	/// <summary>
	/// This class serves as a helper and represents the overall testing results for one page
	/// </summary>
	public class PageResponseTest
	{
		public PageResponseTest(int numberOfRepeats, TimeSpan elapsedTime)
		{
			_NumberOfRepeats = numberOfRepeats;
			_ElapsedTime = elapsedTime;
		}

		private int _NumberOfRepeats;
		/// <summary>
		/// The total number of repeated calls to the page represented by an instance of this class
		/// </summary>
		public int NumberOfRepeats
		{
			get
			{
				return _NumberOfRepeats;
			}
			set
			{
				_NumberOfRepeats = value;
			}
		}

		private TimeSpan _ElapsedTime;
		/// <summary>
		/// Total elapsed time (the sum of all response times for the page represented by an instance of this class)
		/// </summary>
		public TimeSpan ElapsedTime
		{
			get
			{
				return _ElapsedTime;
			}
			set
			{
				_ElapsedTime = value;
			}
		}

		/// <summary>
		/// Returns the average execution time in miliseconds
		/// </summary>
		public double GetAverageResponseTimeInMs()
		{
			//Elapsed time in miliseconds
			double Result = ((double)_ElapsedTime.Ticks)/10000;
			//Average execution time
			Result /= _NumberOfRepeats;
			return Result;
		}

	}

}

///
/// Ported to BenchMarkDotNet from the Udemy course C# Performance Tricks by Mark Farragher 
///

#define BENCHMARK

using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace For_vs_foreach
{
	public class MainClass
	{
		// constants
		private const int numElements = 10000000;

		// fields
		private static ArrayList arrayList = new ArrayList (numElements);
		private static List<int> genericList = new List<int> (numElements);
		private static int[] array = new int[numElements];


		public static void PrepareList ()
		{
			Random random = new Random ();
			for (int i = 0; i < numElements; i++)
			{
				int number = random.Next (256);
				arrayList.Add (number);
				genericList.Add (number);
				array [i] = number;
			}

		}

		public static long MeasureA1 ()
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			for (int i = 0; i < numElements; i++)
			{
				int result = (int)arrayList [i];
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

		public static long MeasureA2 ()
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			foreach (int i in arrayList)
			{
				int result = i;
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

		public static long MeasureB1 ()
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			for (int i = 0; i < numElements; i++)
			{
				int result = genericList [i];
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

		public static long MeasureB2 ()
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			foreach (int i in genericList)
			{
				int result = i;
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

		public static long MeasureC1 ()
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			for (int i = 0; i < numElements; i++)
			{
				int result = array [i];
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

		public static long MeasureC2 ()
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			foreach (int i in array)
			{
				int result = i;
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

		public static void Main (string[] args)
		{


        #if BENCHMARK

            var summary = BenchmarkRunner.Run<BenchMarkClass>();
        #else

			// prepare lists
			PrepareList ();

			// measurement run
			long durationA1 = MeasureA1 ();
			long durationA2 = MeasureA2 ();
			long durationB1 = MeasureB1 ();
			long durationB2 = MeasureB2 ();
			long durationC1 = MeasureC1 ();
			long durationC2 = MeasureC2 ();

			Console.WriteLine ("ArrayList for: {0}", durationA1);
			Console.WriteLine ("ArrayList foreach: {0}", durationA2);
			Console.WriteLine ("List<int> for: {0}", durationB1);
			Console.WriteLine ("List<int> foreach: {0}", durationB2);
			Console.WriteLine ("int[] for: {0}", durationC1);
			Console.WriteLine ("int[] foreach: {0}", durationC2);
		
        #endif
        
        }
	}



    [SimpleJob(launchCount: 10, warmupCount: 0, iterationCount: 4)]
    public class BenchMarkClass
    {
        private const int numElements = 10000000;
		private static ArrayList arrayList = new ArrayList (numElements);
        private int[] array = new int[numElements];
		private List<int> genericList = new List<int> (numElements);
   


        [GlobalSetup]
		public void PrepareList ()
		{
			Random random = new Random ();
			for (int i = 0; i < numElements; i++)
			{
				int number = random.Next (256);
				arrayList.Add (number);
				genericList.Add (number);
				array [i] = number;
			}

		}

        [Benchmark]
		public void MeasureA1 ()
		{
			for (int i = 0; i < numElements; i++)
			{
				int result = (int)arrayList [i];
			}
		}

        [Benchmark]
		public void MeasureA2 ()
		{
			foreach (int i in arrayList)
			{
				int result = i;
			}
		}

        [Benchmark]
		public void MeasureB1 ()
		{
			for (int i = 0; i < numElements; i++)
			{
				int result = genericList [i];
			}
		}


        [Benchmark]
		public void MeasureB2 ()
		{
			foreach (int i in genericList)
			{
				int result = i;
			}
		}

        [Benchmark]
		public void MeasureC1 ()
		{
			for (int i = 0; i < numElements; i++)
			{
				int result = array [i];
			}
		}

        [Benchmark]
		public void MeasureC2 ()
		{
			foreach (int i in array)
			{
				int result = i;
			}
		}

    }
}

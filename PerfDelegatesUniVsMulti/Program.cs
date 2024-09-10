using System;
using System.Diagnostics;

namespace Delegates
{
	class MainClass
	{
		// benchmarking constants
		public const int REPETITIONS = 100000;
		public const int EXPERIMENTS = 100;

		// declare delegate
		public delegate void AddDelegate (int a, int b, out int result);

		// set up first addition method
		private static void Add1 (int a, int b, out int result)
		{
			result = a + b;
		}

		// set up second addition method
		private static void Add2 (int a, int b, out int result)
		{
			result = a + b;
		}

		// Measure1: call Add1 and Add2 manually
		private static long Measure1 ()
		{
			int result = 0;
			Stopwatch sw = new Stopwatch ();
			sw.Start ();
			for (int i = 0; i < REPETITIONS; i++)
			{
				Add1 (1234, 2345, out result);
				Add2 (1234, 2345, out result);
			}
			sw.Stop ();
			return sw.ElapsedMilliseconds;
		}

		// Measure2: call Add1 and Add2 using 2 unicast delegates
		private static long Measure2 ()
		{
			int result = 0;
			AddDelegate add1 = Add1;
			AddDelegate add2 = Add2;
			Stopwatch sw = new Stopwatch ();
			sw.Start ();
			for (int i = 0; i < REPETITIONS; i++)
			{
				add1 (1234, 2345, out result);
				add2 (1234, 2345, out result);
			}
			sw.Stop ();
			return sw.ElapsedMilliseconds;
		}

		// Measure3: call Add1 and Add2 using 1 multicast delegate
		private static long Measure3 ()
		{
			int result = 0;
			AddDelegate multiAdd = Add1;
			multiAdd += Add2;
			Stopwatch sw = new Stopwatch ();
			sw.Start ();
			for (int i = 0; i < REPETITIONS; i++)
			{
				multiAdd (1234, 2345, out result);
			}
			sw.Stop ();
			return sw.ElapsedMilliseconds;
		}

		public static void Main (string[] args)
		{
			long manual = 0;
			long unicast = 0;
			long multicast = 0;
			for (int i = 0; i < EXPERIMENTS; i++)
			{
				manual += Measure1 ();
				unicast += Measure2 ();
				multicast += Measure3 ();
			}
			Console.WriteLine ("Manual calls: {0} ms", manual);
			Console.WriteLine ("Unicast delegates: {0} ms", unicast);
			Console.WriteLine ("Multicast delegate: {0} ms", multicast);
		}
	}
}

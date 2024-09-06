namespace Generics
{
    //add constraints to generics.. some things you can't compare.

    //where T : IComparable
    //where T : <class>
    //where T : struct <-- where key is a ValueType 
    //where T : class <-- reference type 
    //where t : new() <-- class with constructor  

    public class Utilities<T> where T : IComparable
    {

        public T Max(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;

        }


        // you can also apply the generic to a funciton 
        // public T Max<T>(T a, T b) where T : IComparable
        // {
        //     return a.CompareTo(b) > 0 ? a : b;

        // }

    }

    public class Product
    {
        public int ScanCode;

    }

    public class Book : Product
    {
        public int ISBN;
    }

    // with the class constraint we constrain the base class 
    public class PremiumProduct<T> where T : Product
    {

    }

}
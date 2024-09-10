using System;
using System.Text;

namespace Coding.Exercise
{

    //Replace the numbers with words and add 0's between the numbers where necessary 
    //do not insert a trailing zero. 


    // Try doing this without string modifications because they will create copies

    // String builder is great for appending, inserting, and removing, but it won't allow the 
    // the fine editing operation reequired to split the 6571

    class Program {
        
        static void Main(string[] args){

            var result = Exercise.ReplaceDigits("4 score and 7 years ago, 8 men had the same PIN code: 6571");

            Console.WriteLine(result);
        }
    }

    public class Exercise
    {
        
        public static string ReplaceDigits(string sentence)
        {
            string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            char[] numbers = {  '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; 

            var sb = new StringBuilder();
            for(int i = 0; i < sentence.Length; i++)
            {
                var index = Array.IndexOf(numbers, sentence[i]);  //have to be careful because an index from a string is a char
                Console.WriteLine(sentence[i]);
                if(index >= 0)
                {
                    sb.Append(words[index]);
                    
                    if( ((i + 1) < sentence.Length) && (Array.IndexOf(numbers, sentence[i + 1]) >= 0) ) 
                    {
                        sb.Append(' ');
                    }
                }
                else
                {
                    sb.Append(sentence[i]);
                }
            }
            return sb.ToString();
        }
    }
}



// | Method    | Mean       | Error     | StdDev     | Median     |
// |---------- |-----------:|----------:|-----------:|-----------:|
// | MeasureA1 |  52.033 ms | 5.5942 ms |  9.9436 ms |  52.979 ms |
// | MeasureA2 | 124.778 ms | 7.4461 ms | 12.8442 ms | 130.452 ms |
// | MeasureB1 |  13.010 ms | 1.3581 ms |  2.3061 ms |  13.425 ms |
// | MeasureB2 |   8.220 ms | 0.9020 ms |  1.5797 ms |   7.768 ms |
// | MeasureC1 |   4.130 ms | 0.5224 ms |  0.9010 ms |   3.868 ms |
// | MeasureC2 |   4.899 ms | 0.7402 ms |  1.3156 ms |   4.748 ms |
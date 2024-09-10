#define BENCHMARK

using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;




namespace TestPokerHand
{

    //Hand Pattern   <Rank><Suit>,<Rank><Suit>
    //Ranks are 2, 3, 4, 5, 6, 7, 8, 9, T, J, Q, K, A
    //Suints are H, C, S, D 
    //


    class Program
    {

        static void Main(string[] args)
        {
#if BENCHMARK

            var summary = BenchmarkRunner.Run<BenchMarkClass>();
#else
        
            var parser = new InputParser();
            Console.WriteLine("enter your cards: ");
            var input = Console.ReadLine();

            if(string.IsNullOrEmpty(input)) return;
            
            try
            {
                var cards = parser.ProcessInput(input);

                var pokerHand = new PokerHand();

                
                foreach(var card in cards)
                {
                    pokerHand.AddItem(card);
                }

                var hand = pokerHand.GetHand();
                

                var isFlush = hand.All(d => d.Suit == hand.First().Suit);
                if(isFlush)
                {
                    Console.WriteLine("Flush");
                }              

      
                var rankedGroups =
                                from card in hand 
                                group card by card.Rank into groups
                                orderby groups.Count() descending
                                select groups;
                                

                var length = rankedGroups.First().Count();
                if(length == 2)
                {
                    Console.WriteLine("Two of Kind");
                }
                else if(length == 3)
                {
                    Console.WriteLine("Three of a Kind");
                }
                else if(length == 4)
                {
                    Console.WriteLine("Four of a Kind");
                }                                                                
            }
            catch(Exception e)
            {
                Console.WriteLine("errror: " + e.Message);
            }
#endif 


         }//end of main 
    }

    public enum Suit
    {
        Hearts = 0,
        Clubs,
        Spades,
        Diamonds,
    }

    public class PokerHand
    {
        private readonly int _maxHand = 100;

        public PokerHand()
        {
            _hand = new List<Card>(_maxHand);
        }

        public void AddItem(string input)
        {
            var temp = input.Trim().ToCharArray();
            _hand.Add(new Card(ConvertSuit(temp[1]), ConvertRank(temp[0]), temp[0]));
        }

        public List<Card> GetHand()
        {
            return _hand;
        }

        private int ConvertRank(char rank)
        {
            if(rank == 'A') return 14;
            if(rank >= '2' && rank <= '9' ) return rank - 48;
            if(rank == 'T') return 10;
            if(rank == 'J') return 11;
            if(rank == 'Q') return 12;
            if(rank == 'K') return;
        
            throw new ArgumentOutOfRangeException("unknown Rank specified:" + rank);
        }

        private Suit ConvertSuit(char suit)
        {
            if(suit == 'H') return Suit.Hearts;
            if(suit == 'C') return Suit.Clubs;
            if(suit == 'D') return Suit.Diamonds;
            if(suit == 'S') return Suit.Spades;

            //fatal error that ends program 
            throw new ArgumentOutOfRangeException("unknown Suit Specified: " + suit);
        }

        private readonly List<Card> _hand;

    }

    public struct Card
    {
        public Card(Suit suit, int rank, char rank_c)
        {
            _suit = suit;
            _rank = rank;
            _rank_c = rank_c;
        }

        private Suit _suit;
        private int _rank;
        private char _rank_c;

        public Suit Suit { get => _suit; }
        public int Rank { get => _rank; }
        public char Rank_str {get => _rank_c; }
        public override string ToString()
        {
            return _rank_c.ToString() + " of " + Enum.GetName(typeof(Suit), _suit);
        }
    }
    public class InputParser
    {
        public InputParser()
        {
            _delimiterChars = new char[] { ' ' };
        }

        public InputParser(char[] delimitersChars)
        {
            _delimiterChars = delimitersChars;
        }

        public IEnumerable<string> ProcessInput(string input)
        {
            return input.Split(',');
        }

        private readonly char[] _delimiterChars;
    }


    [SimpleJob(launchCount: 10, warmupCount: 0, iterationCount: 4)]
    public class BenchMarkClass
    {
        [Benchmark]
        public void Foo()
        {
            var pokerHand = new PokerHand();
            var input =  "2H,3H,4H,6H,7H,8H,9J,TC,8C,9C,6C,2C,8D,8S,KD,KH,HS,KC";

            var parser = new InputParser();

            var hand = parser.ProcessInput(input);

        }



        [Benchmark]
        public void Bar()
        {
            var pokerHand = new PokerHand();
            var input =  new List<string> () {"2H","3H","4H","6H","7H","8H","9S","TC","8C","9C","6C","2C","8D","8S","KD","KH","JS","KC"};

            foreach(var i in input)
            {
                pokerHand.AddItem(i);
            }
        
        }
    }



// Declaring PokerHand List Capacity as 100  
// | Method | Mean     | Error    | StdDev    |
// |------- |---------:|---------:|----------:|
// | Foo    | 557.3 ns | 46.36 ns |  81.20 ns |
// | Bar    | 812.8 ns | 89.34 ns | 158.80 ns |

// Declaring Pokerhand no List Capacity 
// | Method | Mean     | Error     | StdDev    |
// |------- |---------:|----------:|----------:|
// | Foo    | 455.3 ns |  41.41 ns |  72.53 ns |
// | Bar    | 888.7 ns | 116.63 ns | 198.05 ns |
}

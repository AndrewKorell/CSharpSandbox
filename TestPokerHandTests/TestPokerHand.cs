using TestPokerHand;
using System.Text;

namespace TestPokerHandTests;



public class Tests
{

    private PokerHand _pokerhand; 
    private InputParser _inputParser;
    private IEnumerable<string> _parsedInput;
    private string _testInput;
     
    [SetUp]
    public void Setup()
    {
        _pokerhand = new PokerHand();
        _inputParser = new InputParser();

        _testInput = "";

        var suits = new char[] { 'H', 'S', 'C', 'D'};
        var ranks = new char[] { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
        var strBuilder = new StringBuilder();

        foreach(var rank in ranks)
        {
            foreach(var suit in suits)
            {
                strBuilder.Append(new char[] { rank, suit, ',' });
            }
        }

        strBuilder.Remove(strBuilder.Length -1, 1); //remove trailing ',' 
        _testInput = strBuilder.ToString();

        _parsedInput = _inputParser.ProcessInput(_testInput);
        
        TestContext.Out.WriteLine(_testInput);
    }

    [Test]
    public void InputParser_CallProcessInput_ReturnListSize52()
    {
        var result = _inputParser.ProcessInput(_testInput);

        Assert.That(result.Count(), Is.EqualTo(52));       
    }

    [Test]
    public void CallPokerHandAddItem_EveryValidCardInput_NoExceptionsThrown()
    {

        Assert.DoesNotThrow(() =>  {

            foreach(var item in _parsedInput)
            {
                _pokerhand.AddItem(item);
            }

        });
    }

    [Test]
    public void CallPokerHandAddItem_InputBadRank_ThrowArgumentOutOfRangeException()
    {

        Assert.Throws<ArgumentOutOfRangeException>(() =>  {

                _pokerhand.AddItem("1H");
        });
    }

    [Test]
    public void CardStructFor2H_CallToSTring_Return2_Of_Hearts()
    {
        var card = new Card(Suit.Hearts, 2, '2');

        Assert.That(card.ToString(), Is.EqualTo("2 of Hearts"));
    }


}
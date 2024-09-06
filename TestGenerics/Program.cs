

namespace Generics {

    class Program {
        
        static void main(string args[]){

            var Books = new GenericList<int>();

            var Pages = new GenericList<string>();

            var Dict = new GenerticDictionary<int, string>();

            Dict.add(0, "zero");

            var Lego = new PremiumProduct<Product>();

            var Book = new PremiumProduct<Book>();

        }
    }
}


using CollectionHierarchy.Core;
using CollectionHierarchy.Models;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            Engine engine = new Engine(addCollection, addRemoveCollection, myList);

            engine.Run();
        }
    }
}

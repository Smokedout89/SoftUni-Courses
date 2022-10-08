namespace AuthorProblem
{
    public class StartUp
    {
        [Author("George")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }

        [Author("Victor")]
        public void Test()
        {
            
        }

        [Author("Pavel")]
        [Author("Victor")]
        public void OshteTest()
        {

        }
    }
}

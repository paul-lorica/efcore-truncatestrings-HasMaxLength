using System;

namespace EfCoreTruncateStringsBasedOnMaxLength
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new TutorialContext();

            var log = new NonImportantLog()
            {
                LongMessage1 = "This product works certainly well. It perfectly improves my tennis by a lot.",
                LongMessage2 = "I saw one of these in Saint Pierre and Miquelon and I bought one."
            };

            var truncatedLog = db.TruncateStringsBasedOnMaxLength(log);

        }
    }
}

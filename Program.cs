using System.Text;

namespace BeetrootHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strFemale = "My favourite female pet names are {10}, {7}, {3} and {5}.";

            string invalidStr = "Nothing will be replaced - {-3}, {3+2}, {112}, {abc}";

            string[] femalePetNames = { "Maggie", "Penny", "Saya", "Princess",
                           "Abby", "Laila", "Sadie", "Olivia",
                           "Starlight", "Talla", "Talula" };

            //Console.WriteLine(AdvancedFormat(strFemale, femalePetNames));

            //Console.WriteLine(AdvancedFormat(invalidStr, femalePetNames));

            string testStr = @"~!@#$%^&*()_snfktJAQ352880+-=`|][{};:'?/>.<,\""";
            foreach (var ctr in testStr)
            {
                Console.WriteLine($"[{ctr}] is symbol: {char.IsSymbol(ctr)}");
            }
            Analyze(testStr, out int numLetters, out int numDigits, out int numSymbols);
            
            Console.WriteLine($"There are {numLetters} letters, {numDigits} digits and" +
                $" {numSymbols} symbols in the input string.");


            Console.ReadKey();
        }

        public static void Analyze(string inputStr, 
            out int numLetters, 
            out int numDigits, 
            out int numSymbols)
        {
            numLetters = 0;
            numDigits = 0;
            numSymbols = 0;

            foreach (var ctr in inputStr)
            {
                if (char.IsDigit(ctr)) numDigits++;
                if (char.IsLetter(ctr)) numLetters++;
                if (char.IsSymbol(ctr)) numSymbols++;
            }
        }


        private static string AdvancedFormat(string sourceStr, string[] possibleSubstitutions)
        {
            var sBuilder = new StringBuilder(sourceStr);

            int iOpening = sourceStr.IndexOf('{');
            int iClosing = sourceStr.IndexOf('}');

            int lenghtToSubs;
            int numToParse;
            int num;
            int iStart = iOpening + 1;
            string toSubs;

            while (iOpening != -1 && iClosing < sourceStr.Length)
            {
                num = 0;
                lenghtToSubs = 2;
                while (iStart < iClosing)
                {
                    if (char.IsNumber(sourceStr[iStart]))
                    {
                        numToParse = (int)char.GetNumericValue(sourceStr[iStart]);
                        num = num * 10 + numToParse;
                        lenghtToSubs++;
                    }
                    else
                    {
                        num = -1;
                        break;
                    }


                    iStart++;
                }

                toSubs = sourceStr.Substring(iOpening, lenghtToSubs);
                if (num != -1)
                {
                    if (num < possibleSubstitutions.Length && lenghtToSubs > 2)
                    {
                        sBuilder.Replace(toSubs, possibleSubstitutions[num]);
                    }
                }

                iOpening = sourceStr.IndexOf('{', iClosing);
                iStart = iOpening + 1;
                iClosing = sourceStr.IndexOf('}', iStart);
            }

            return sBuilder.ToString();
        }
    }
}
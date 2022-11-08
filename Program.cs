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
           
            //Analyze(testStr, out int numLetters, out int numDigits, out int numSymbols);
            
            //Console.WriteLine($"There are {numLetters} letters, {numDigits} digits and" +
               // $" {numSymbols} symbols in the input string.");

            string test1 = "Hellomylovevndjkfghks";
            string test2 = "qwerty";
            //Console.WriteLine(Compare(test1, test2));
            var duplicates = Duplicate(test1);
            foreach (var item in duplicates) Console.WriteLine(item);
            



            Console.ReadKey();
        }

        public static bool Compare(string str1, string str2)
        {
            if (str1.Length == str2.Length)
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    if (str1[i] != str2[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static char[] Duplicate(string str)
        {
            string strLower = str.ToLower();
            var results = new List<char>();
            int index;
            int count;

            for (int i = 0; i < strLower.Length; i++)
            {
                index = strLower.IndexOf(strLower[i]);
                count = 0;
                while (index != -1)
                {
                    index = strLower.IndexOf(strLower[i], index + 1);
                    count++;   
                }
            
                if (count > 1 && !IsCharInList(strLower[i], results))
                {
                    results.Add(strLower[i]);
                }
            }

            return results.ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctr"></param>
        /// <param name="list"></param>
        /// <returns>Returns True if char is in list</returns>
        public static bool IsCharInList(char ctr, List<char> list)
        {
            foreach(char c in list)
            {
                if (ctr == c) return true;
            }
            return false;
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
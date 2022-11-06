using System.Text;

namespace BeetrootHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strFemale = "My favourite female pet names are {10}, {7}, {3} and {5}.";
            string strMale = "My favourite male pet names are {8}, {4}, {10} and {2}.";
            string invalidStr = "Nothing will be replaced - {-3}, {3+2}, {112}, {abc}";

            string[] femalePetNames = { "Maggie", "Penny", "Saya", "Princess",
                           "Abby", "Laila", "Sadie", "Olivia",
                           "Starlight", "Talla", "Talula" };

            string[] malePetNames = { "Rufus", "Bear", "Dakota", "Fido",
                         "Vinny", "Samuel", "Koani", "Charly",
                         "Prince", "Gizmo", "Soho" };

            Console.WriteLine(AdvancedFormat(strFemale, femalePetNames));
            Console.WriteLine(AdvancedFormat(strMale, malePetNames));
            Console.WriteLine(AdvancedFormat(invalidStr, femalePetNames));

            Console.ReadKey();
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
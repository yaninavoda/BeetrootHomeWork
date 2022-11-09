using RandomNameGeneratorLibrary;
using PNLibrary;

namespace Text
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Choose operation (-g) - genarate, (-c) - create, (-out) - exit, (-p) - print all, (-e) - edit:");

                string input = Console.ReadLine();

                PhonesStorage storage;

                try
                {
                    storage = new PhonesStorage();
                }
                catch(DbFileNotFoundException ex)
                {
                    // create db file.
                    Console.ReadKey();
                    return;
                }
                
                switch (input)
                {
                    case "-g":
                        RunRandomGeneration();
                        break;
                    case "-c":
                        storage.Save(new PhoneRecord());
                        break;
                    case "-p":
                        storage.PrintAll();
                        break;
                    case "-e":
                        storage.Edit(int.Parse(Console.ReadLine()));
                        break;
                    case "-out":
                        goto Exit;
                    default:
                        continue;
                }
            } while (true);

            Exit:;

            Console.ReadKey();
        }

        private static void RunRandomGeneration()
        {
            var placeGenerator = new PersonNameGenerator();
            var randomNumberGenerator = new Random();
            var storage = new PhonesStorage();

            for (var i = 0; i < 50; i++)
            {
                var newRecord = new PhoneRecord(placeGenerator.GenerateRandomFirstName(),
                    placeGenerator.GenerateRandomLastName(),
                    $"{randomNumberGenerator.Next(38010, 38099)}" +
                        $"{randomNumberGenerator.Next(1111111, 9999999)}");

                storage.Save(newRecord);
            }
        }
    }
}
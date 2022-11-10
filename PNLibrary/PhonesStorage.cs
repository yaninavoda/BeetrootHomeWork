namespace PNLibrary
{
    public class PhonesStorage
    {
        private readonly string DbFilePath = @"D:\beetroot\PhoneBook\phonedb.csv";
        private readonly char ColumnSeparator = ';';

        public PhonesStorage()
        {
            EnshureDbFile();
        }
        public void Search()
        {
            string choice;
            Console.WriteLine("What do you want to find: Type (f) for first name, (l) for last name, (n) for phone number:");
            choice = Console.ReadLine();
            string? input;
            string[]? records;

            switch (choice)
            {
                case "l":
                    Console.WriteLine("Enter the last name:");
                    input = Console.ReadLine();
                    records = GetAllRecord();

                    for (int i = 0; i < records.Length; i++)
                    {
                        var recordObj = DeserializeRecord(records[i]);
                        if (recordObj.LastName == input)
                        {
                            Print(recordObj, i + 1);
                        }
                    }
                    break;

                case "f":
                    Console.WriteLine("Enter the first name:");
                    input = Console.ReadLine();
                    records = GetAllRecord();

                    for (int i = 0; i < records.Length; i++)
                    {
                        var recordObj = DeserializeRecord(records[i]);
                        if (recordObj.FirstName == input)
                        {
                            Print(recordObj, i + 1);
                        }
                    }
                    break;

                case "n":
                    Console.WriteLine("Enter the phone number you want to find:");
                    input = Console.ReadLine();
                    records = GetAllRecord();

                    for (int i = 0; i < records.Length; i++)
                    {
                        var recordObj = DeserializeRecord(records[i]);
                        if (recordObj.PhoneNumber == input)
                        {
                            Print(recordObj, i + 1);
                        }
                    }
                    break;

                default:
                    break;
            }
        }
        public void Edit(int orderNumber)
        {
            var records = GetAllRecord();
            var index = orderNumber - 1;

            // Print error order number;
            if (index < 0 || index > records.Length - 1)
            {
                var redBuffer = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong order number.");
                Console.ForegroundColor = redBuffer;
            }

            var recordObj = DeserializeRecord(records[index]);

            var yellowBuffer = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You are going to edit:");
            Print(recordObj);
            Console.ForegroundColor = yellowBuffer;

            var updatedRecord = new PhoneRecord();

            records[index] = SerializeRecord(updatedRecord);

            File.WriteAllLines(DbFilePath, records.Select(x => x.Trim()));
        }

        public void PrintAll()
        {
            var records = GetAllRecord();

            for (int i = 0; i < records.Length; i++)
            {
                string? record = records[i];
                var desirializedRecord = DeserializeRecord(record);

                Print(desirializedRecord, i + 1);
            }
        }

        public void Print(PhoneRecord phoneRecord)
        {
            Console.WriteLine($"+{phoneRecord.PhoneNumber} - {phoneRecord.FirstName} {phoneRecord.LastName}");
        }

        public void Print(PhoneRecord phoneRecord, int orderNumber)
        {
            Console.WriteLine($"[{orderNumber}]: +{phoneRecord.PhoneNumber} - {phoneRecord.FirstName} {phoneRecord.LastName}");
        }

        public void Save(PhoneRecord phoneRecord)
        {
            File.AppendAllLines(DbFilePath, new[] { SerializeRecord(phoneRecord) });
        }

        private string[] GetAllRecord()
        {
            return File.ReadAllText(DbFilePath).Split('\n', StringSplitOptions.RemoveEmptyEntries);
        }

        private string SerializeRecord(PhoneRecord phoneRecord)
        {
            return $"{phoneRecord.FirstName}{ColumnSeparator}" +
                $"{phoneRecord.LastName}{ColumnSeparator}" +
                $"{phoneRecord.PhoneNumber}{ColumnSeparator}";
        }

        private PhoneRecord DeserializeRecord(string record)
        {
            string[] cellValues = record.Split(ColumnSeparator);

            var parsedRecord = new PhoneRecord(cellValues[0], cellValues[1], cellValues[2]);

            return parsedRecord;
        }

        private void EnshureDbFile()
        {
            if (!File.Exists(DbFilePath))
            {
                throw new DbFileNotFoundException();
            }
        }
    }
}
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
            Console.WriteLine("What do you want to find: Type (f) for first name, (l) for last name, (n) for phone number:");
            string? choice = Console.ReadLine();
            string? input;
            string[]? records;
            PhoneRecord? recordObj;
            switch (choice)
            {
                case "l":
                    Console.WriteLine("Enter the last name:");
                    input = Console.ReadLine();
                    
                    records = GetAllRecord();

                    //var index = Array.BinarySearch(records, input);
                    //recordObj = DeserializeRecord(records[index]);
                    //Print(recordObj, index + 1);
                    for (int i = 1; i < records.Length; i++)
                    {
                        recordObj = DeserializeRecord(records[i]);
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

                    for (int i = 1; i < records.Length; i++)
                    {
                        recordObj = DeserializeRecord(records[i]);
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

                    for (int i = 1; i < records.Length; i++)
                    {
                        recordObj = DeserializeRecord(records[i]);
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
            
            // Print error order number;
            if (orderNumber < 0 || orderNumber > records.Length - 1)
            {
                var redBuffer = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong order number.");
                Console.ForegroundColor = redBuffer;
            }

            var recordObj = DeserializeRecord(records[orderNumber]);

            var yellowBuffer = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You are going to edit:");
            Print(recordObj);
            Console.ForegroundColor = yellowBuffer;

            var updatedRecord = new PhoneRecord();

            records[orderNumber] = SerializeRecord(updatedRecord);

            File.WriteAllLines(DbFilePath, records.Select(x => x.Trim()));
        }

        public void PrintAll()
        {
            string[] records = GetAllRecord();
            
            for (int i = 1; i < records.Length; i++)
            {
                string? record = records[i];
                var deserializedRecord = DeserializeRecord(record);

                Print(deserializedRecord, i);
            }
        }

        public void Print(PhoneRecord phoneRecord)
        {
            Console.WriteLine($"+{phoneRecord.PhoneNumber} - {phoneRecord.FirstName} {phoneRecord.LastName}");
        }

        public void Print(PhoneRecord phoneRecord, int orderNumber)
        {
            Console.WriteLine($"[{orderNumber}]: +{phoneRecord.PhoneNumber} - {phoneRecord.LastName} {phoneRecord.FirstName}");
        }

        public void Save(PhoneRecord phoneRecord)
        {
            File.AppendAllLines(DbFilePath, new[] { SerializeRecord(phoneRecord) });
        }
        public void Save(string[] records)
        {
            File.AppendAllLines(DbFilePath, records);
        }

        private string[] GetAllRecord()
        {   
            var list = new List<string>();
            string[] recordStrings = File.ReadAllText(DbFilePath).Split('\n', StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < recordStrings.Length; i++)
            {    
                if (recordStrings[i].Length > 13)
                    list.Add(recordStrings[i]);
            }
            
            recordStrings = list.ToArray();
            Array.Sort(recordStrings);

            return recordStrings;
        }

        public string SerializeRecord(PhoneRecord phoneRecord)
        {
            return $"{phoneRecord.LastName}{ColumnSeparator}" +
                $"{phoneRecord.FirstName}{ColumnSeparator}" +
                $"{phoneRecord.PhoneNumber}{ColumnSeparator}";
        }

        public PhoneRecord DeserializeRecord(string record)
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
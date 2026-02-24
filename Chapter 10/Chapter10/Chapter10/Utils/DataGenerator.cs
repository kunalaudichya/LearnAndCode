namespace Chapter10.Utils
{
    public class DataGenerator
    {
        public static void GenerateSampleData(string filePath, int recordCount)
        {
            var lines = new List<string>();
            Random random = new Random();

            for (int i = 1; i <= recordCount; i++)
            {
                string id = $"ID{i:D4}";
                string name = $"Item{i}";
                double value = random.Next(10, 1000);
                DateTime date = DateTime.Now.AddDays(-random.Next(0, 365));

                lines.Add($"{id},{name},{value},{date:yyyy-MM-dd}");
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}

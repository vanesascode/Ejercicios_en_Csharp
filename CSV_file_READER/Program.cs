//const string path = "C:\\Users\\Vanesa\\Downloads\\sampleData.csv";
const string path = @"C:\Users\Vanesa\Downloads\sampleData.csv";


CsvData data = new CsvReader().Read(path);

Console.WriteLine("Press any key to close");
Console.ReadKey();



public class CsvReader
{
    public CsvData Read(string path)
    {
        using var streamReader = new StreamReader(path);

        const string separator = ",";
        var columns = streamReader.ReadLine().Split(separator);

        var rows = new List<string[]>();

        while (!streamReader.EndOfStream)
        {
            var row = streamReader.ReadLine().Split(separator);
            rows.Add(row);
        }

        return new CsvData(columns, rows);
    }

}





public class CsvData
{
    public string[] Columns { get; }
    public IEnumerable<string[]> Rows { get; }

    public CsvData(string[] columns, IEnumerable<string[]> rows)
    {
        Columns = columns; 
        Rows = rows;
    }

}

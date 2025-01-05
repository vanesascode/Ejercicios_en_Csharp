const string filePath = "text.txt";
//('using' is synthetic sugar)
//The using statement ensures that the file is properly closed and disposed of AFTER WRITING, regardless of whether an exception is thrown or not.
//the Dispose method is called at the end of the USING BLOCK, i.e., when the code execution exits the block.
using (var writer = new FileWriter(filePath))
{
    writer.Write("Hi, I'm a Geek");
}

// the using method applies the dispose method AFTER USE 
//the Dispose method is called at the end of the SCOPE, which is typically the end of the method, not just the end of a specific block.
using var reader = new SpecificLineReaderFromTextFile(filePath);
var thirdLine = reader.ReadLineNumber(2);
var forthLine = reader.ReadLineNumber(3);
Console.WriteLine(thirdLine);
Console.WriteLine(forthLine);



using var allReader = new AllLinesFromTextFileReader(filePath);
var document = allReader.ReadAllLines();
foreach (var line in document)
{
    Console.WriteLine(line);
}



Console.WriteLine("Press any key to close");
Console.ReadKey();

public class FileWriter : IDisposable

{
    private readonly StreamWriter _streamWriter;

    public FileWriter(string filePath)
    {
        //true indicates that the StreamWriter should append to the file instead of overwriting it.
        _streamWriter = new StreamWriter(filePath, true);
    }

    public void Write(string text)
    {
        _streamWriter.WriteLine(text);
        //The Flush method forces the StreamWriter to write the contents of the buffer to the underlying file immediately.
        _streamWriter.Flush();
    }

    public void Dispose()
    {
        _streamWriter.Dispose();
    }

}

public class SpecificLineReaderFromTextFile : IDisposable
{
    private readonly StreamReader _streamReader;

    public SpecificLineReaderFromTextFile(string filePath)
    {
        _streamReader = new StreamReader(filePath);
    }

    public string ReadLineNumber(int lineNumer)
    {
        _streamReader.DiscardBufferedData();
        _streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
        for (int i = 0; i < lineNumer - 1; i++)
        {
            _streamReader.ReadLine();
        }
        return _streamReader.ReadLine();

    }

    public void Dispose()
    {
        _streamReader.Dispose();
    }
}

public class AllLinesFromTextFileReader : IDisposable
{
    private readonly StreamReader _streamReader;

    public AllLinesFromTextFileReader(string filePath)
    {
        _streamReader = new StreamReader(filePath);
    }

    public List<string> ReadAllLines()
    {
        var result = new List<string>();
        while (!_streamReader.EndOfStream)
        {
            result.Add(_streamReader.ReadLine());
        }

        return result;
    }

    public void Dispose()
    {
        _streamReader.Dispose();
    }
}

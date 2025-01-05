using System.Collections.Generic;
using System.Text.Json;

var app = new GameDataParserApp();
var logger = new Logger("log.txt");

try
{
    app.Run();
}
catch(Exception ex)
{
    Console.WriteLine("Sorry, app failed and will have to close");
    logger.Log(ex);
}

Console.ReadKey();
Console.WriteLine();
Console.WriteLine("Press any key to close.");



public class GameDataParserApp
{
    public void Run()
    {
        try
        {

            string fileName = GetValidFileName();

            //File refers to the System.IO.File class in .NET. It provides static methods
            //for creating, copying, deleting, and opening files, as well as reading and writing to files.
            var fileContents = File.ReadAllText(fileName);

            //var videoGames = new List<VideoGame>(); OR:
            List<VideoGame> videoGames = default;

            try
            {
                videoGames = JsonSerializer.Deserialize<List<VideoGame>>(fileContents);

            }
            catch (JsonException ex)
            {
                var originalColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"JSON in {fileName} file was not in a valid format. JSON body:");
                Console.WriteLine(fileContents);
                Console.ForegroundColor = originalColor;

                //This way will have access to the origin of the exception. And it will stop the app: 
                throw new JsonException($"{ex.Message} The file is {fileName}", ex);
                logger.Log(ex);
            }

            if (videoGames.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Loaded games are:");
                foreach (var videoGame in videoGames)
                {
                    Console.WriteLine(videoGame);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Sorry! The application has experienced an unexpected error and will have to be closed.");
        }
    }

   private string GetValidFileName()
    {
        while (true)
        {
            Console.Write("Enter the name of the file you want to read: ");
            string fileName = Console.ReadLine();

            if (fileName == null)
            {
                Console.WriteLine("File name cannot be null.");
                continue;
            }

            if (fileName == "")
            {
                Console.WriteLine("File name cannot be empty.");
                continue;
            }

            if (!File.Exists(fileName))
            {
                Console.WriteLine("File not found.");
                continue;
            }

            return fileName;
        }
    }
}



public class VideoGame
{
    //'init' allows you to set a property's value only during object initialization,
    //and makes the property immutable after that.
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public decimal Rating { get; init; }

    public override string ToString()
    {
        return $"{Title}, released in: {ReleaseYear}, and rated as: {Rating}";
    }
}

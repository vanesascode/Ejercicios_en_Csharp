var words = new List<string>
{
    "one",
    "two",
};

Console.WriteLine(words.Count);



words[0] = "uno";
words[1] = "dos";
words.Add("tres");
words.Add("cuatro");

words.Remove(words[2]);

words.RemoveAt(0);

var moreWords = new[] { "cinco", "seis", "siete" };
words.AddRange(moreWords);

foreach (var word in words)
{
    Console.WriteLine(word);
}

Console.WriteLine(words.IndexOf("dos")); // 0 
Console.WriteLine(words.IndexOf("noexiste")); // -1 (-1 means it doesn't exist)


Console.WriteLine(words.Contains("cinco")); //True
Console.WriteLine(words.Contains("noexiste")); //False

words.Clear();
Console.WriteLine(words.Count); // 0

//

List<string> result = new List<string>();

var palabras = new List<string>
{
    "one",
    "ONE",
    "two",
};

foreach (var word in palabras)
{
    if (result.Contains(word))
    {
        continue;
    }

    bool isWordUpper = true;

    foreach (char letter in word)
    {
        if (!char.IsUpper(letter))
        {
            isWordUpper = false;
        }
    }
    if (isWordUpper)
    {
        result.Add(word);
    }
}

Console.WriteLine("result count " + result.Count);

//

Console.ReadKey();
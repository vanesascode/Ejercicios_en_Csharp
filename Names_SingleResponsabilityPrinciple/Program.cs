// using directive (not folders, especify the namespace)
using Names_SingleResponsabilityPrinciple.DataAccess;

var names = new Names();
var path = new NamesFilePathBuilder().BuildFilePath();
var repository = new StringsTextualRepository();
if (File.Exists(path))
{
    Console.WriteLine("Names file already exists. Loading names");
    var stringsFromFile = repository.Read(path);
    names.AddNames(stringsFromFile);
}
else
{
    Console.WriteLine("Names file does not yet exist.");

    names.AddName("Walter");
    names.AddName("not valid name");
    names.AddName("Dante");

    Console.WriteLine("Saving names to a file");
    repository.Write(path, names.All);
}
Console.WriteLine(new NamesFormatter().Format(names.All));
Console.ReadKey();



//El principio DRY no es: "no repitas ningún código; extrae métodos y reutilízalos en su lugar."

//El principio DRY es: "no tengas múltiples lugares en el código donde se definan las mismas decisiones de negocio."


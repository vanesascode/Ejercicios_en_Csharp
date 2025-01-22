// Ejercicio con Patrón Factory: Sistema de Gestión de Documentos

DocumentsManager manager = new DocumentsManager();
manager.ProcessDocument("mi_archivo.txt");
manager.ProcessDocument("mi_documento.pdf");
manager.ProcessDocument("datos.xml");

/// <summary>
/// The client class
/// </summary>
class DocumentsManager
{
    public void ProcessDocument(string filePath)
    {
        DocumentFactory factory = GetFactory(filePath);
        IDocument document = factory.CreateDocument(filePath);
        document.Process();
    }
    private DocumentFactory GetFactory(string filePath)
    {
        return (Path.GetExtension(filePath).ToLower()) switch
        {
            ".txt" => new TextDocumentFactory(),
            ".pdf" => new PdfDocumentFactory(),
            ".xml" => new XMLDocumentFactory(),
            _ => throw new ArgumentException("Unknown file type.")
        };
    }
}

#region Documents hierarchy

interface IDocument
{
    void Process();
}

class TextDocument : IDocument
{
    public void Process()
    {
        Console.WriteLine("Processing a text document.");
    }
}

class PdfDocument : IDocument
{
    public void Process()
    {
        Console.WriteLine("Processing a PDF document.");
    }
}

public class XMLDocument : IDocument
{
    public void Process()
    {
        Console.WriteLine("Processing an XML document.");
    }
}

#endregion

#region Factory hierarchy

abstract class DocumentFactory
{
    // Deferring the instantiation process
    // to the subclasses.
    public abstract IDocument CreateDocument(string filePath);
}

class TextDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument(string filePath)
    {
        return new TextDocument();
    }
}

class PdfDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument(string filePath)
    {
        return new PdfDocument();
    }
}

class XMLDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument(string filePath)
    {
        return new XMLDocument();
    }
}


#endregion
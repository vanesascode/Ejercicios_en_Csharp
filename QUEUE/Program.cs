List<int> items = [2, -4, 1, 8, 5];

Queue<int> queue = new();

//Para cada elemento, llama al método queue.Enqueue() y le pasa el elemento actual como argumento.
//Enqueue() añade ese elemento al final de la cola queue.
items.ForEach(queue.Enqueue);

while (queue.Count > 0)
{
    // Removes and prints the element at the front of the 'queue'.
    Console.WriteLine(queue.Dequeue());
}


////////////////////////////////////////////////////////////////////////////////////////////////////////
/// CALL CENTER

Random random = new();

CallCenter center = new();

center.Call(1234);
center.Call(5678);
center.Call(1468);
center.Call(9641);

ConsultantsTeam team = new(["Vanesa", "Walter", "Liz"]);

while (center.AreWaitingCalls()) // Calls.Count > 0;
{
    Consultant consultant = team.GetConsultant();
    IncomingCall call = center.Answer(consultant.Name)!;
    DateTime answerTime = DateTime.Now;
    Log($"Call #{call.Id} from client #{call.ClientId} answered by {call.Consultant}.");

    // Task.Delay: Este es un método estático de la clase Task. Crea un nuevo
    // Task que se completará después de un retardo especificado.
    await Task.Delay(random.Next(1000, 10000));

    center.End(call);
    DateTime endTime = DateTime.Now;

    //The @ symbol at the beginning of the string makes it a verbatim string literal.
    //This means that any backslashes (\) within the string are treated literally, not as escape characters.
    string waitTimeFormatted = (answerTime - call.CallTime).ToString(@"mm\:ss");
    string callDurationFormatted = (endTime - answerTime).ToString(@"mm\:ss");

    Log($"Call #{call.Id} from client #{call.ClientId} ended by {call.Consultant}. Customer waited {waitTimeFormatted}, and call lasted {callDurationFormatted}");
}


void Log(string text) => Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {text}");

public class ConsultantsTeam
{
    public Queue<Consultant> Consultants { get; set; }
    public ConsultantsTeam(string[] names)
    {
        Consultants = new Queue<Consultant>(names.Select(name => new Consultant { Name = name }));

    }

    public Consultant GetConsultant()
    {
        Consultant consultant = Consultants.Dequeue();
        Consultants.Enqueue(consultant);
        return consultant;
    }
}


public class CallCenter
{
    private int _counter = 0;
    public Queue<IncomingCall> Calls { get; private set; }

    //Constructor: sin parametros, tan solo se crea un objeto de tipo
    //Queue<IncomingCall> al que le llamas 'center' y se asigna a la propiedad 'Calls'.
    public CallCenter() => Calls = new Queue<IncomingCall>();


    public IncomingCall Call(int clientId)
    {
        IncomingCall call = new()
        {
            Id = ++_counter, // esto (++, aumentar antes de asignar) te ahorra una linea antes
                             // teniendo que aumentar el contador
            ClientId = clientId,
            CallTime = DateTime.Now
        };
        Calls.Enqueue(call);
        Console.WriteLine($"New call by customer { call.ClientId }");
        return call;
    }


    //AQUI NO ES IMPORTANTE EL CALL QUE RECOGEMOS PARA MODIFICAR:
    public IncomingCall? Answer(string consultant)
    {
        if (!AreWaitingCalls()) { return null; }

        IncomingCall call = Calls.Dequeue(); // esta call ya estaba en la lista Calls, y ya tenia un
                                             // poco de info. Ahora la completamos. 
        call.Consultant = consultant;
        call.AnswerTime = DateTime.Now;
        return call;
    }

    //AQUI SI ES IMPORTANTE SABER QUE CALL ESPECIFICA LE LLEGA AL PARAMETRO:
    public void End(IncomingCall call) => call.EndTime = DateTime.Now;

    public bool AreWaitingCalls() => Calls.Count > 0;
}


public class IncomingCall
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public DateTime CallTime { get; set; }
    public DateTime? AnswerTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string? Consultant { get; set; }
}

public class Consultant
{
    public string? Name { get; set; }
}
int numberOfMeasurements = 10; // Número de mediciones a generar
List<Measurement?> measurements = RandomMeasurementGenerator.GenerateMeasurements(numberOfMeasurements);

// como es un metodo estatico no se necesita instanciar la clase
List<Measurement?> measurements2 = RandomMeasurementGenerator.GenerateMeasurements(10);

// Puedes trabajar con la lista 'measurements' aquí
Console.WriteLine("\nLista completa de mediciones:");
foreach (var measurement in measurements)
{
    Console.WriteLine(measurement != null ? measurement.ToString() : "null");
}

public record Measurement(DateTime ReadAt, float Value, string Salutation);

public class RandomMeasurementGenerator
{

    //Un miembro estático se comparte entre todas las instancias de una clase.
    //En otras palabras, un miembro estático pertenece a la clase en sí, en lugar
    //de una instancia específica de la clase.
    private static readonly Random random = new Random();

    public static List<Measurement?> GenerateMeasurements(int count)
    {
        List<Measurement?> measurements = new List<Measurement?>();

        for (int i = 0; i < count; i++)
        {
            measurements.Add(CreateRandomMeasurement());
            Console.WriteLine(IsValid(measurements.Last()) ? measurements.Last().ToString() : "-");
            Task.Delay(100).Wait(); // Wait instead of async/await for simplicity
        }

        return measurements;
    }

    private static Measurement? CreateRandomMeasurement()
    {
        return random.Next(3) != 0 ? new Measurement(DateTime.Now, random.Next(1000) / 1000.0f, "hi") : null;
    }

    private static bool IsValid(Measurement? measurement)
    {
        return measurement != null
               && measurement.Value >= 0.0f
               && measurement.Value <= 1.0f;
    }

}

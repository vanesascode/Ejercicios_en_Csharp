
Random random = new();

//Al agregar ? después de Measurement, se indica que la lista puede
//contener elementos de tipo Measurement o el valor null
List<Measurement?> measurements = [];

for (int i = 0; i < 100; i++)
{
    Measurement? measurement = random.Next(3) != 0
    ? new(DateTime.Now, random.Next(1000) / 1000.0f, "hi")
    : null;

    measurements.Add(measurement);

    Console.WriteLine(IsValid(measurement) ? measurement!.ToString(): "-");
    await Task.Delay(100);
}

static bool IsValid(Measurement? measurement)
{
    return measurement != null
    && measurement.Value >= 0.0f
    && measurement.Value <= 1.0f;
}
public record Measurement(DateTime ReadAt, float Value, string Salutation);

//Los registros se crean con propiedades de solo lectura (inmutables)
//por defecto. Esto significa que una vez que se crea una instancia de
//un registro, sus propiedades no se pueden modificar directamente.
//Esto ayuda a prevenir errores y facilita el razonamiento sobre el código,
//especialmente en entornos concurrentes.

//Measurement { ReadAt = 28/12/2024 19:39:50, Value = 0,228, Salutation = hi }
//Measurement { ReadAt = 28/12/2024 19:39:51, Value = 0,767, Salutation = hi }
//Measurement { ReadAt = 28/12/2024 19:39:51, Value = 0,292, Salutation = hi }
//Measurement { ReadAt = 28/12/2024 19:39:51, Value = 0,277, Salutation = hi }
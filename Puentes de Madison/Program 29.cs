using Shered;

// Programa Puentes de Madison
string puente = ConsolExtension.GetString("Ingrese el puente: ") ?? "";
puente = puente.Trim();

bool valido = true;

// The bridge must have at least two characters
if (puente.Length < 2)
{
    valido = false;
}

// Must start and end with *
if (puente[0] != '*' || puente[puente.Length - 1] != '*')
{
    valido = false;
}

// The * symbols can only appear at the ends.
for (int i = 1; i < puente.Length - 1; i++)
{
    if (puente[i] == '*')
    {
        valido = false;
    }
}

// Check if it is symmetric
for (int i = 0; i < puente.Length / 2; i++)
{
    if (puente[i] != puente[puente.Length - 1 - i])
    {
        valido = false;
    }
}

// Review the platform groups
for (int i = 0; i < puente.Length; i++)
{
    if (puente[i] == '=')
    {
        int cantidad = 0;
        int inicio = i;

                // Count consecutive platforms
                while (i < puente.Length && puente[i] == '=')
                {
                    cantidad++;
                    i++;
                }

                // Retroceder un paso porque el for() hará un i++ adicional
                // y queremos continuar desde el carácter siguiente al bloque de '='
                i--;

        // There cannot be more than 3 consecutive platforms.
        if (cantidad > 3)
        {
            valido = false;
        }

        // If there are 3 platforms, they must be in the center
        if (cantidad == 3)
        {
            int centro = puente.Length / 2;

            if (inicio != centro - 1)
            {
                valido = false;
            }
        }

        // If there are 2 or more platforms,
        // there must be a reinforcement (+) next to them
        if (cantidad >= 2)
        {
            bool tieneRefuerzoIzquierda =
                inicio > 0 && puente[inicio - 1] == '+';

            bool tieneRefuerzoDerecha =
                (i + 1) < puente.Length && puente[i + 1] == '+';

            if (!tieneRefuerzoIzquierda && !tieneRefuerzoDerecha)
            {
                valido = false;
            }
        }
    }
}

if (valido)
    Console.WriteLine("VALIDO");
else
    Console.WriteLine("INVALIDO");

// Mantener la consola abierta al depurar (solo cuando el depurador está adjunto)
Console.WriteLine("Presione una tecla para terminar...");
if (System.Diagnostics.Debugger.IsAttached)
{
    Console.ReadKey();
}

using System;
using System.Collections.Generic;

// Leer las posiciones de los frutos
string frutosEntrada = ConsoleExtension.GetString(
    "Ingrese ubicación de los frutos: ") ?? "";

// Guardamos los frutos:
// clave = posición (por ejemplo C4)
// valor = símbolo (+, -, *)
Dictionary<string, char> frutos = new Dictionary<string, char>();

string[] frutosSeparados = frutosEntrada.Split(',');

foreach (string fruto in frutosSeparados)
{
    string dato = fruto.Trim().ToUpper();

    if (dato.Length >= 3)
    {
        string posicion = dato.Substring(0, 2);
        char simbolo = dato[dato.Length - 1];

        frutos[posicion] = simbolo;
    }
}

// Leer posición inicial del caballo
string posicionCaballo = ConsoleExtension.GetString(
    "Ingrese posición inicial del caballo: ") ?? "";

posicionCaballo = posicionCaballo.Trim().ToUpper();

// Leer movimientos
string movimientosEntrada = ConsoleExtension.GetString(
    "Ingrese los movimientos del caballo: ") ?? "";

string[] movimientos = movimientosEntrada
    .ToUpper()
    .Split(',', StringSplitOptions.RemoveEmptyEntries);

// Posición inicial
int columna = posicionCaballo[0] - 'A';
int fila = int.Parse(posicionCaballo[1].ToString()) - 1;

// Movimientos del caballo (dc = cambio de columna, df = cambio de fila)
Dictionary<string, (int dc, int df)> movimientosCaballo =
    new Dictionary<string, (int dc, int df)>()
    {
        // Etiquetas según el enunciado:
        // UL = arriba-izquierda  (col -1, fila +2)
        // UR = arriba-derecha    (col +1, fila +2)
        // LU = izquierda-arriba  (col -2, fila +1)
        // LD = izquierda-abajo   (col -2, fila -1)
        // RU = derecha-arriba    (col +2, fila +1)
        // RD = derecha-abajo     (col +2, fila -1)
        // DL = abajo-izquierda   (col -1, fila -2)
        // DR = abajo-derecha     (col +1, fila -2)
        { "UL", (-1, 2) },
        { "UR", (1, 2) },
        { "LU", (-2, 1) },
        { "LD", (-2, -1) },
        { "RU", (2, 1) },
        { "RD", (2, -1) },
        { "DL", (-1, -2) },
        { "DR", (1, -2) }
    };

// Lista donde guardaremos los frutos recogidos
List<char> frutosRecogidos = new List<char>();

// Realizar cada movimiento
foreach (string movimiento in movimientos)
{
    string mov = movimiento.Trim();

    if (!movimientosCaballo.ContainsKey(mov))
        continue;

    // Obtener desplazamiento
    var desplazamiento = movimientosCaballo[mov];

    // Calcular nueva posición sin aplicar todavía
    int nuevaCol = columna + desplazamiento.dc;
    int nuevaFil = fila + desplazamiento.df;

    // Verificar que el caballo permanezca dentro del tablero
    if (nuevaCol < 0 || nuevaCol >= 8 ||
        nuevaFil < 0 || nuevaFil >= 8)
    {
        // Ignorar movimiento fuera del tablero (no cambiar posición)
        continue;
    }

    // Aplicar movimiento válido
    columna = nuevaCol;
    fila = nuevaFil;

    // Convertir la posición actual a formato ajedrez
    string posicionActual = $"{(char)('A' + columna)}{fila + 1}";

    // ¿Hay un fruto en esta posición?
    if (frutos.ContainsKey(posicionActual))
    {
        frutosRecogidos.Add(frutos[posicionActual]);

        // El fruto desaparece después de recogerlo
        frutos.Remove(posicionActual);
    }
}

// Mostrar resultado
Console.Write("Los frutos recogidos son: ");

for (int i = 0; i < frutosRecogidos.Count; i++)
{
    Console.Write(frutosRecogidos[i]);

    if (i < frutosRecogidos.Count - 1)
        Console.Write(" ");
}

Console.WriteLine();

// Mantener la consola abierta al depurar en Visual Studio
Console.WriteLine("Presione una tecla para terminar...");
Console.ReadKey();

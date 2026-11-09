using System;
using System.Collections.Generic;
using System.Linq;

namespace Shered
{
    // Utilidades de consola — versiones con nombres ConsolExtensions y ConsolExtension
    // para mantener compatibilidad con llamadas existentes en la solución.
    public static class ConsolExtensions
    {
        public static int GetInt(string message)
        {
            Console.Write(message);
            var numberString = Console.ReadLine();
            if (int.TryParse(numberString, out int numberInt))
            {
                return numberInt;
            }

            return 0;
        }

        public static float GetFloat(string message)
        {
            Console.Write(message);
            var numberString = Console.ReadLine();
            if (float.TryParse(numberString, out float numberFloat))
            {
                return numberFloat;
            }

            return 0;
        }

        public static double GetDouble(string message)
        {
            Console.Write(message);
            var numberString = Console.ReadLine();
            if (double.TryParse(numberString, out double numberDouble))
            {
                return numberDouble;
            }

            return 0;
        }

        public static decimal GetDecimal(string message)
        {
            Console.Write(message);
            var numberString = Console.ReadLine();
            if (decimal.TryParse(numberString, out decimal numberDecimal))
            {
                return numberDecimal;
            }

            return 0;
        }

        public static string? GetString(string message)
        {
            Console.Write(message);
            var text = Console.ReadLine();
            return text;
        }

        public static string? GetValidOptions(string message, List<string> options)
        {
            Console.Write(message);
            var answer = Console.ReadLine();
            if (options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)))
            {
                return answer;
            }
            return null;
        }
    }

    // Clase con nombre alternativo para compatibilidad: ConsolExtension (singular)
    public static class ConsolExtension
    {
        public static int GetInt(string message) => ConsolExtensions.GetInt(message);
        public static float GetFloat(string message) => ConsolExtensions.GetFloat(message);
        public static double GetDouble(string message) => ConsolExtensions.GetDouble(message);
        public static decimal GetDecimal(string message) => ConsolExtensions.GetDecimal(message);
        public static string? GetString(string message) => ConsolExtensions.GetString(message);
        public static string? GetValidOptions(string message, List<string> options) => ConsolExtensions.GetValidOptions(message, options);
    }
}

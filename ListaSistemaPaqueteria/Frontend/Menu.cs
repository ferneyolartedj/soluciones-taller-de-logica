using System;
using Backend;
namespace Frontend

{
    public class Menu
    {
        private ListaDoble<string> lista;
        public Menu()
        {
            lista = new ListaDoble<string>();
        }
        public void Mostrar()
        {
            int opcion;
            do
            {
                Console.Clear();

                Console.WriteLine("======================================");
                Console.WriteLine("     TALLER - LISTA DOBLEMENTE");
                Console.WriteLine("     LIGADA- CIUDADES PAQUETERIA");
                Console.WriteLine("======================================");
                Console.WriteLine("1. Adicionar");
                Console.WriteLine("2. Mostrar hacia adelante");
                Console.WriteLine("3. Mostrar hacia atrás");
                Console.WriteLine("4. Ordenar descendentemente");
                Console.WriteLine("5. Mostrar la(s) moda(s)");
                Console.WriteLine("6. Mostrar gráfico");
                Console.WriteLine("7. Existe");
                Console.WriteLine("8. Eliminar una ocurrencia");
                Console.WriteLine("9. Eliminar todas las ocurrencias");
                Console.WriteLine("0. Salir");
                Console.WriteLine("======================================");

                Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(),out opcion))

                {
                    opcion = -1;
                }

                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        Adicionar();
                        break;

                    case 2:
                        lista.MostrarAdelante();
                        Pausar();
                        break;

                    case 3:
                        lista.MostrarAtras();
                        Pausar();
                        break;

                    case 4:
                        OrdenarDescendente();
                        break;

                    case 5:
                        lista.MostrarModas();
                        Pausar();
                        break;

                    case 6:
                        lista.MostrarGrafico();
                        Pausar();
                        break;

                    case 7:
                        Existe();
                        break;

                    case 8:
                        EliminarUna();
                        break;

                    case 9:
                        EliminarTodas();
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        Pausar();
                        break;
                }

            } while (opcion != 0);
        }

        // OPCIÓN 1
        private void Adicionar()
        {
            string dato = LeerDato("Ingrese el elemento: ");
            lista.Adicionar(dato);

            Console.WriteLine(
                "\nElemento agregado correctamente en orden ascendente."
            );

            Pausar();
        }

        // OPCIÓN 4
        private void OrdenarDescendente()
        {
            lista.OrdenarDescendente();

            Console.WriteLine(
                "La lista fue ordenada descendentemente."
            );

            lista.MostrarAdelante();

            Pausar();
        }

        // OPCIÓN 7
        private void Existe()
        {
            string dato = LeerDato("Ingrese el elemento que desea buscar: ");
            if (lista.Existe(dato))
            {
                Console.WriteLine($"\nSí existe el elemento {dato}.");
            }
            else
            {
                Console.WriteLine($"\nNo existe el elemento {dato}.");
            }

            Pausar();
        }

        // OPCIÓN 8
        private void EliminarUna()
        {
            string dato = LeerDato("Ingrese el elemento que desea eliminar: ");
            bool eliminado = lista.EliminarUna(dato);
            if (eliminado)
            {
                Console.WriteLine($"\nSe eliminó una ocurrencia de {dato}.");
            }
            else
            {
                Console.WriteLine($"\nNo se encontró el elemento {dato}.");
            }

            Pausar();
        }

        // OPCIÓN 9
        private void EliminarTodas()
        {
            string dato = LeerDato(
                "Ingrese el elemento que desea eliminar completamente: "
            );
            int cantidad = lista.EliminarTodas(dato);
            if (cantidad > 0)
            {
                Console.WriteLine(
                    $"\nSe eliminaron {cantidad} ocurrencia(s) de {dato}."
                );
            }
            else
            {
                Console.WriteLine($"\nNo se encontró el elemento {dato}.");
            }

            Pausar();
        }

        private void Pausar()
        {
            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();
        }

        private string LeerDato(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string dato = Console.ReadLine()?.Trim() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(dato))
                {
                    return dato;
                }

                Console.WriteLine("\nDebe ingresar un dato no vacío.");
            }
        }
    }
}
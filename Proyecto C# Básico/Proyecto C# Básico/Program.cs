using Proyecto_C__Básico;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Gasto> gastos = new List<Gasto>();
        decimal totalGastos = 0;

        while (true)
        {
            Console.WriteLine("Sistema de Gastos Personales");
            Console.WriteLine("1. Registrar un gasto");
            Console.WriteLine("2. Ver resumen de gastos");
            Console.WriteLine("3. Mostrar lista de gastos");
            Console.WriteLine("4. Eliminar un gasto");
            Console.WriteLine("5. Salir");
            Console.Write("Elija una opción: ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        RegistrarGasto(gastos, ref totalGastos);
                        break;
                    case 2:
                        VerResumenDeGastos(gastos, totalGastos);
                        break;
                    case 3:
                        MostrarListaDeGastos(gastos);
                        break;
                    case 4:
                        EliminarGasto(gastos, ref totalGastos);
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }


    static void RegistrarGasto(List<Gasto> gastos, ref decimal totalGastos)
    {
        Console.Write("Ingrese una descripción del gasto: ");
        string descripcion = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(descripcion))
        {
            Console.WriteLine("La descripción no puede estar en blanco. Intente de nuevo.");
            return;
        }

        Console.Write("Ingrese el monto del gasto: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal monto))
        {
            gastos.Add(new Gasto { Descripción = descripcion, Monto = monto });
            totalGastos += monto;
            Console.WriteLine("Gasto registrado con éxito.");
        }
        else
        {
            Console.WriteLine("Monto no válido. Intente de nuevo.");
        }
    }

    static void VerResumenDeGastos(List<Gasto> gastos, decimal totalGastos)
    {
        Console.WriteLine("Resumen de Gastos:");
        foreach (var gasto in gastos)
        {
            Console.WriteLine($"{gasto.Descripción}: ${gasto.Monto}");
        }
        Console.WriteLine($"Gasto Total: ${totalGastos}");
    }

    static void MostrarListaDeGastos(List<Gasto> gastos)
    {
        Console.WriteLine("Lista de Gastos Registrados:");
        for (int i = 0; i < gastos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {gastos[i].Descripción}: ${gastos[i].Monto}");
        }
    }

    static void EliminarGasto(List<Gasto> gastos, ref decimal totalGastos)
    {
        Console.WriteLine("Gastos Registrados:");
        for (int i = 0; i < gastos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {gastos[i].Descripción}: ${gastos[i].Monto}");
        }

        Console.Write("Seleccione el número del gasto que desea eliminar (0 para cancelar): ");
        if (int.TryParse(Console.ReadLine(), out int seleccion))
        {
            if (seleccion > 0 && seleccion <= gastos.Count)
            {
                decimal montoAEliminar = gastos[seleccion - 1].Monto;
                gastos.RemoveAt(seleccion - 1);
                totalGastos -= montoAEliminar;
                Console.WriteLine("Gasto eliminado con éxito.");
            }
            else if (seleccion == 0)
            {
                Console.WriteLine("Eliminación de gasto cancelada.");
            }
            else
            {
                Console.WriteLine("Número de gasto no válido. Intente de nuevo.");
            }
        }
        else
        {
            Console.WriteLine("Número de gasto no válido. Intente de nuevo.");
        }
    }
}

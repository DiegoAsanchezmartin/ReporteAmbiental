using System;
using System.Collections.Generic;

public class Usuario
{
    public string NombreUsuario { get; set; }
    public string Contraseña { get; set; }
    public List<ReporteAmbiental> Reportes { get; set; }

    public Usuario(string nombreUsuario, string contraseña)
    {
        NombreUsuario = nombreUsuario;
        Contraseña = contraseña;
        Reportes = new List<ReporteAmbiental>();
    }

    public void EliminarReporte(ReporteAmbiental reporte)
    {
        Reportes.Remove(reporte);
    }

    public void CrearReporte(string titulo, string descripcion, string localidad, double latitud, double longitud)
    {
        ReporteAmbiental nuevoReporte = new ReporteAmbiental(titulo, descripcion, localidad, latitud, longitud);
        Reportes.Add(nuevoReporte);
    }

public void VerMisReportes()
{
    Console.WriteLine("Mis Reportes Ambientales:");

    for (int i = 0; i < Reportes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. Título: {Reportes[i].Titulo}");
        Console.WriteLine($"   Descripción: {Reportes[i].Descripcion}");
        Console.WriteLine($"   Fecha: {Reportes[i].Fecha}");
        Console.WriteLine($"   Localidad: {Reportes[i].Localidad}");
        Console.WriteLine($"   Latitud: {Reportes[i].Latitud}, Longitud: {Reportes[i].Longitud}");
        Console.WriteLine();
    }

    Console.Write("Selecciona el número de reporte que deseas gestionar (0 para volver): ");
    int opcion;
    if (int.TryParse(Console.ReadLine(), out opcion))
    {
        if (opcion >= 1 && opcion <= Reportes.Count)
        {
            Console.WriteLine("Selecciona una opción:");
            Console.WriteLine("1. Modificar reporte");
            Console.WriteLine("2. Eliminar reporte");
            Console.WriteLine("3. Volver");
            Console.Write("Opción: ");

            string gestionOption = Console.ReadLine();

            switch (gestionOption)
            {
                case "1":
                    ModificarReporte(Reportes[opcion - 1]);
                    break;
                case "2":
                    EliminarReporte(Reportes[opcion - 1]);
                    Console.WriteLine("Reporte eliminado exitosamente.");
                    break;
                case "3":
                    Console.WriteLine("Regresando al menú principal.");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
        else if (opcion == 0)
        {
            Console.WriteLine("Regresando al menú principal.");
        }
        else
        {
            Console.WriteLine("Número de reporte no válido.");
        }
    }
    else
    {
        Console.WriteLine("Entrada no válida.");
    }
}

private void ModificarReporte(ReporteAmbiental reporte)
{
    Console.WriteLine("Modificar Reporte Ambiental:");
    Console.Write("Nuevo título (Enter para mantener el mismo): ");
    string nuevoTitulo = Console.ReadLine();
    if (!string.IsNullOrEmpty(nuevoTitulo))
    {
        reporte.Titulo = nuevoTitulo;
    }

    Console.Write("Nueva descripción (Enter para mantener la misma): ");
    string nuevaDescripcion = Console.ReadLine();
    if (!string.IsNullOrEmpty(nuevaDescripcion))
    {
        reporte.Descripcion = nuevaDescripcion;
    }

    Console.WriteLine("Reporte modificado exitosamente.");
}


    public void MenuUsuario()
    {
        bool volverMenuPrincipal = false;

        while (!volverMenuPrincipal)
        {
            Console.WriteLine("Bienvenido, " + NombreUsuario);
            Console.WriteLine("1. Crear Reporte Ambiental");
            Console.WriteLine("2. Ver Mis Reportes");
            Console.WriteLine("3. Cerrar Sesión");
            Console.Write("Selecciona una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el título del reporte: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Ingrese la descripción del reporte: ");
                    string descripcion = Console.ReadLine();
                    Console.Write("Ingrese la localidad: ");
                    string localidad = Console.ReadLine();
                    double latitud = GenerarCoordenadaAleatoria(-90, 90);
                    double longitud = GenerarCoordenadaAleatoria(-180, 180);
                    CrearReporte(titulo, descripcion, localidad, latitud, longitud);
                    break;
                case "2":
                    VerMisReportes();
                    break;
                case "3":
                    volverMenuPrincipal = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, selecciona una opción válida.");
                    break;
            }
        }
    }

    private double GenerarCoordenadaAleatoria(double min, double max)
    {
        Random rand = new Random();
        return rand.NextDouble() * (max - min) + min;
    }
}

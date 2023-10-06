using System;

public class ReporteAmbiental
{
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public DateTime Fecha { get; set; }
    public string Localidad { get; set; }
    public double Latitud { get; set; }
    public double Longitud { get; set; }

    public ReporteAmbiental(string titulo, string descripcion, string localidad, double latitud, double longitud)
    {
        Titulo = titulo;
        Descripcion = descripcion;
        Fecha = DateTime.Now;
        Localidad = localidad;
        Latitud = latitud;
        Longitud = longitud;
    }
}


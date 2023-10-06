using System;
using System.Collections.Generic;

class Program
{
    static List<Usuario> usuarios = new List<Usuario>();
    static List<Administrador> administradores = new List<Administrador>();
    static Usuario usuarioActual;

    static void Main(string[] args)
    {
        // Agregar un administrador por defecto
        Administrador administradorPorDefecto = new Administrador("admin", "admin");
        administradores.Add(administradorPorDefecto);

        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Sistema de Reportes Ambientales");
            Console.WriteLine("1. Registrar");
            Console.WriteLine("2. Iniciar Sesión");
            Console.WriteLine("3. Salir");
            Console.Write("Selecciona una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarUsuario();
                    break;
                case "2":
                    IniciarSesion();
                    break;
                case "3":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, selecciona una opción válida.");
                    break;
            }
        }
    }

    static void RegistrarUsuario()
    {
        Console.Write("Nombre de usuario: ");
        string nombreUsuario = Console.ReadLine();
        Console.Write("Contraseña: ");
        string contraseña = Console.ReadLine();

        Usuario nuevoUsuario = new Usuario(nombreUsuario, contraseña);
        usuarios.Add(nuevoUsuario);

        Console.WriteLine("Usuario registrado exitosamente.");
    }

    static void IniciarSesion()
    {
        Console.Write("Nombre de usuario: ");
        string nombreUsuario = Console.ReadLine();
        Console.Write("Contraseña: ");
        string contraseña = Console.ReadLine();


        Administrador administradorEncontrado = administradores.Find(a => a.NombreUsuario == nombreUsuario && a.Contraseña == contraseña);

        if (administradorEncontrado != null)
        {
  
            usuarioActual = null; 
            administradorEncontrado.MenuAdministrador(usuarios);
        }
        else
        {

            Usuario usuarioEncontrado = usuarios.Find(u => u.NombreUsuario == nombreUsuario && u.Contraseña == contraseña);

            if (usuarioEncontrado != null)
            {
                usuarioActual = usuarioEncontrado;
                usuarioActual.MenuUsuario();
            }
            else
            {
                Console.WriteLine("Usuario o contraseña incorrectos.");
            }
        }
    }
}

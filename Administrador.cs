using System;
using System.Collections.Generic;

public class Administrador
{
    public string NombreUsuario { get; set; }
    public string Contraseña { get; set; }

    public Administrador(string nombreUsuario, string contraseña)
    {
        NombreUsuario = nombreUsuario;
        Contraseña = contraseña;
    }

    public void MenuAdministrador(List<Usuario> usuarios)
    {
        bool volverMenuPrincipal = false;

        while (!volverMenuPrincipal)
        {
            Console.WriteLine("Bienvenido, Administrador");
            Console.WriteLine("1. Modificar Usuarios");
            Console.WriteLine("2. Cerrar Sesión (Administrador)");
            Console.Write("Selecciona una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Lista de Usuarios:");
                    MostrarUsuarios(usuarios);
                    ModificarUsuarios(usuarios);
                    break;
                case "2":
                    volverMenuPrincipal = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, selecciona una opción válida.");
                    break;
            }
        }
    }

    public void MostrarUsuarios(List<Usuario> usuarios)
    {
        foreach (Usuario usuario in usuarios)
        {
            Console.WriteLine($"Nombre de usuario: {usuario.NombreUsuario}");
        }
    }

    public void ModificarUsuarios(List<Usuario> usuarios)
    {
        Console.Write("Ingrese el nombre de usuario que desea modificar o eliminar (o 'volver' para regresar al menú principal): ");
        string nombreUsuarioModificar = Console.ReadLine();

        if (nombreUsuarioModificar.ToLower() == "volver")
        {
            Console.WriteLine("Regresando al menú principal.");
            return;
        }

        Usuario usuarioAModificar = usuarios.Find(u => u.NombreUsuario == nombreUsuarioModificar);

        if (usuarioAModificar != null)
        {
            Console.WriteLine($"Nombre de usuario: {usuarioAModificar.NombreUsuario}");
            Console.WriteLine("Selecciona una opción:");
            Console.WriteLine("1. Modificar Usuario");
            Console.WriteLine("2. Eliminar Usuario");
            Console.WriteLine("3. Volver");
            Console.Write("Opción: ");

            string gestionOption = Console.ReadLine();

            switch (gestionOption)
            {
                case "1":
                    ModificarUsuario(usuarioAModificar);
                    break;
                case "2":
                    usuarios.Remove(usuarioAModificar);
                    Console.WriteLine("Usuario eliminado exitosamente.");
                    break;
                case "3":
                    Console.WriteLine("Regresando al menú principal.");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Usuario no encontrado.");
        }
    }

    public void ModificarUsuario(Usuario usuario)
    {
        Console.Write("Ingrese la nueva contraseña para el usuario: ");
        string nuevaContraseña = Console.ReadLine();
        usuario.Contraseña = nuevaContraseña;
        Console.WriteLine("Contraseña modificada exitosamente.");
    }
} 



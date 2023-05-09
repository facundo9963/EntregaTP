namespace Aseguradora.Consola;
using Aseguradora.Repositorios;
using Aseguradora.Aplicacion;

public class TitularesMenu : IMenu
{
    private readonly IRepositorioTitular repo = new RepositorioTitularTXT();
    public void MostrarOpciones()
    {
        Console.WriteLine("1: Agregar Titular");
        Console.WriteLine("2: Modificar Titular");
        Console.WriteLine("3: Eliminar Titular");
        Console.WriteLine("4: Listar Titulares");
        Console.WriteLine("5: Listar Titulares con Vehículos");
    }
    public void EjecutarOpcion(int opc)
    {
        switch (opc)
        {
            case 1:
                Agregar();
                break;
            case 2:
                Modificar();
                break;
            case 3:
                Eliminar();
                break;
            case 4:
                Listar();
                break;
            case 5:
                Listar2();
                break;
        }
    }

    /*
    Agregar y Modificar no necesitan try y catch. De todas formas están porque así
    están escritos los agregar y modificar de las demás entidades, además de que
    aún falta implementar el manejo de la propiedad ListaVehiculos, junto con
    Listar2 o ListarTitularesConSusVehiculosUseCase();
    */

    private void Agregar()
    {
        try
        {
            var agregarTitular = new AgregarTitularUseCase(repo);

            Console.WriteLine("Nuevo Titular:");

            Console.WriteLine($" Id: {ObtenerIdUtility.ObtenerId(repo, false)+1} (generado automaticamente)");

            Console.Write(" Ingrese apellido: ");
            string apellido = Console.ReadLine() ?? "";

            Console.Write(" Ingrese nombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write(" Ingrese DNI: ");
            int dni = int.Parse(Console.ReadLine() ?? "");

            Console.Write(" Ingrese teléfono: ");
            int telefono = int.Parse(Console.ReadLine() ?? "");

            Console.Write(" Ingrese dirección: ");
            string direccion = Console.ReadLine() ?? "";

            Console.Write(" Ingrese email: ");
            string email = Console.ReadLine() ?? "";

            agregarTitular.Ejecutar(new Titular(
                ObtenerIdUtility.ObtenerId(repo, true),
                apellido,
                nombre,
                dni,
                telefono,
                direccion,
                email
            ));

            Console.WriteLine("Nuevo Titular agregado con éxito.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    private void Modificar()
    {
        try
        {
            var modificarTitular = new ModificarTitularUseCase(repo);

            Console.Write(" Ingrese Id de Titular a modificar: ");
            int id = int.Parse(Console.ReadLine() ?? "");

            Console.Write(" Ingrese DNI de Titular a modificar: ");
            int dni = int.Parse(Console.ReadLine() ?? "");

            Console.Write(" Ingrese apellido: ");
            string apellido = Console.ReadLine() ?? "";

            Console.Write(" Ingrese nombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write(" Ingrese teléfono: ");
            int telefono = int.Parse(Console.ReadLine() ?? "");

            Console.Write(" Ingrese dirección: ");
            string direccion = Console.ReadLine() ?? "";

            Console.Write(" Ingrese email: ");
            string email = Console.ReadLine() ?? "";

            modificarTitular.Ejecutar(new Titular(
                id,
                apellido,
                nombre,
                dni,
                telefono,
                direccion,
                email
            ));

            Console.WriteLine("Titular modificado con éxito.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    private void Eliminar()
    {
        var eliminarTitular = new EliminarTitularUseCase(repo);

        Console.Write(" Ingrese Id del Titular a eliminar: ");
        int Id = int.Parse(Console.ReadLine() ?? "");

        eliminarTitular.Ejecutar(Id);

        Console.WriteLine("Titular eliminado con éxito.");
    }
    private void Listar()
    {
        var listarTitulares = new ListarTitularesUseCase(repo);
        var lista = listarTitulares.Ejecutar();

        Console.WriteLine("Listando Titulares:");
        foreach (Titular t in lista)
        {
            Console.WriteLine(t);
        }
    }
    private void Listar2()
    {
        var listarTitularesConSusVehiculos = new ListarTitularesConSusVehiculosUseCase(repo);
        var lista = listarTitularesConSusVehiculos.Ejecutar();
        Console.WriteLine("Listando Titulares:");
        foreach (Titular t in lista)
        {
            Console.WriteLine(t);
            Console.WriteLine("Vehiculos: ");
            foreach (Vehiculo v in t.ListaVehiculos)
            {
                Console.WriteLine("  " + v);
            }
        }
    }
}
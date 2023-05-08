namespace Aseguradora.Consola;
using Aseguradora.Repositorios;
using Aseguradora.Aplicacion;

public class VehiculosMenu : IMenu
{
    private readonly IRepositorioVehiculo repo = new RepositorioVehiculoTXT();
    public void MostrarOpciones()
    {
        Console.WriteLine("1: Agregar Vehículo");
        Console.WriteLine("2: Modificar Vehículo");
        Console.WriteLine("3: Eliminar Vehículo");
        Console.WriteLine("4: Listar Vehículos");
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
        }
    }
    private void Agregar()
    {
        try
        {
            var agregarVehiculo = new AgregarVehiculoUseCase(repo);

            Console.WriteLine("Nuevo Vehículo:");

            Console.WriteLine($" Id: {ObtenerIdUtility.ObtenerId(repo, false)} (generado automaticamente)");

            Console.Write(" Ingrese dominio: ");
            string dominio = Console.ReadLine() ?? "";

            Console.Write(" Ingrese marca: ");
            string marca = Console.ReadLine() ?? "";

            Console.Write(" Ingrese año: ");
            int anio = int.Parse(Console.ReadLine() ?? "");

            Console.Write(" Ingrese Id del titular (1XXX): ");
            int idTitular = int.Parse(Console.ReadLine() ?? "");
            if (!TitularExiste(idTitular)) throw new Exception($"No existe un Titular de Id: {idTitular}");

            agregarVehiculo.Ejecutar(new Vehiculo()
            {
                Id = ObtenerIdUtility.ObtenerId(repo, true),
                Dominio = dominio,
                Marca = marca,
                Anio = anio,
                IdTitular = idTitular,
            });

            Console.WriteLine("Nuevo Vehículo agregado con éxito.");
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
            var modificarVehiculo = new ModificarVehiculoUseCase(repo);

            Console.Write(" Ingrese Id de Vehículo a modificar: ");
            int id = int.Parse(Console.ReadLine() ?? "");

            Console.Write(" Ingrese dominio: ");
            string dominio = Console.ReadLine() ?? "";

            Console.Write(" Ingrese marca: ");
            string marca = Console.ReadLine() ?? "";

            Console.Write(" Ingrese año: ");
            int anio = int.Parse(Console.ReadLine() ?? "");

            Console.Write(" Ingrese Id del titular (1XXX): ");
            int idTitular = int.Parse(Console.ReadLine() ?? "");
            if (!TitularExiste(idTitular)) throw new Exception($"No existe un Titular de Id: {idTitular}");

            modificarVehiculo.Ejecutar(new Vehiculo()
            {
                Id = id,
                Dominio = dominio,
                Marca = marca,
                Anio = anio,
                IdTitular = idTitular,
            });

            Console.WriteLine("Vehículo modificado con éxito.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    private void Eliminar()
    {
        var eliminarVehiculo = new EliminarVehiculoUseCase(repo);

        Console.Write(" Ingrese Id del Vehículo a eliminar: ");
        int Id = int.Parse(Console.ReadLine() ?? "");

        eliminarVehiculo.Ejecutar(Id);

        Console.WriteLine("Vehículo eliminado con éxito.");
    }
    private void Listar()
    {
        var listarVehiculos = new ListarVehiculosUseCase(repo);
        var lista = listarVehiculos.Ejecutar();

        Console.WriteLine("Listando Vehículos:");
        foreach (Vehiculo v in lista)
        {
            Console.WriteLine(v);
        }
    }
    private bool TitularExiste(int IdBuscado)
    {
        bool res = false;
        IRepositorioTitular repo = new RepositorioTitularTXT();
        var listarTitulares = new ListarTitularesUseCase(repo);
        var lista = listarTitulares.Ejecutar();
        foreach(Titular t in lista)
        {
            if (t.Id == IdBuscado) 
            {
                res = true;              
                break;
            }
        }
        return res;
    }      
}
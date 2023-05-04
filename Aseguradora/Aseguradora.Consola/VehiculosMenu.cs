namespace Aseguradora.Consola;
using Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
public class VehiculosMenu : IMenu
{
    public void MostrarOpciones()
    {
        Console.WriteLine("1- Agregar Vehiculo");
        Console.WriteLine("2- Eliminar Vehiculo");
        Console.WriteLine("3- Modificar Vehiculo");
        Console.WriteLine("4- Listar Vehiculos");
    }
    public void EjecutarOpcion(int opc)
    {
        switch (opc)
        {
            case 1:
                Agregar();
                break;
            case 2:
                Eliminar();
                break;
            case 3:
                Modificar();
                break;
            case 4:
                Listar();
                break;
        }
    }
    private void Agregar()
    {
        IRepositorioVehiculo repo = new RepositorioVehiculoTXT();
        var agregarVehiculo = new AgregarVehiculoUseCase(repo);

        Console.Write(" Id (en realidad deberia asignarse automaticamente):");
        int id = int.Parse(Console.ReadLine() ?? "");

        Console.Write(" Ingrese dominio: ");
        string dominio = Console.ReadLine() ?? "";

        Console.Write(" Ingrese marca: ");
        string marca = Console.ReadLine() ?? "";

        Console.Write(" Ingrese año: ");
        int anio = int.Parse(Console.ReadLine() ?? "");

        Console.Write(" Ingrese Id del titular: ");
        int idTitular = int.Parse(Console.ReadLine() ?? "");
        //hacer una verificación de que existe, sino agregar un nuevo titular

        agregarVehiculo.Ejecutar(new Vehiculo()
        {
            Id = id,
            Dominio = dominio,
            Marca = marca,
            Anio = anio,
            IdTitular = idTitular,
        });
    }

    private void Eliminar()
    {

    }
    private void Modificar()
    {

    }
    private void Listar()
    {

    }
}
namespace Aseguradora.Consola;
using Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
public class VehiculosMenu : IMenu
{
    public void MostrarOpciones()
    {
        Console.WriteLine("1- Agregar Vehiculo");
        Console.WriteLine("2- Eliminar Vehiculo");
        Console.WriteLine("2- Modificar Vehiculo");
        Console.WriteLine("2- Listar Vehiculos");
    }
    public void EjecutarOpcion(int opc)
    {
        switch (opc)
        {
            case 1:
                AgregarVehiculo();
                break;
        }
    }
    private void AgregarVehiculo()
    {
        IRepositorioVehiculo repoVehiculos = new RepositorioVehiculoTXT();
        var agregarVehiculo = new AgregarVehiculoUseCase(repoVehiculos);

        Console.WriteLine("Escribi el ID del vehiculo");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Escribi el dominio del vehiculo");
        string dominio = Console.ReadLine() ?? "";

        Console.WriteLine("Escribi la marca del vehiculo");
        string marca = Console.ReadLine() ?? "";

        Console.WriteLine("Escribi el año del vehiculo");
        int anio = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Escribi el ID del titular del vehiculo");
        int idTitular = Convert.ToInt32(Console.ReadLine());

        agregarVehiculo.Ejecutar(new Vehiculo
        {
            Id = id,
            Dominio = dominio,
            Marca = marca,
            Anio = anio,
            IdTitular = idTitular,
        });
    }

}
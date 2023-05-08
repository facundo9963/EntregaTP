namespace Aseguradora.Consola;
using Aseguradora.Repositorios;
using Aseguradora.Aplicacion;

public class PolizasMenu : IMenu
{
    private readonly IRepositorioPoliza repo = new RepositorioPolizaTXT();
    public void MostrarOpciones()
    {
        Console.WriteLine("1: Agregar Póliza");
        Console.WriteLine("2: Modificar Póliza");
        Console.WriteLine("3: Eliminar Póliza");
        Console.WriteLine("4: Listar Pólizas");
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
            var agregarPoliza = new AgregarPolizaUseCase(repo);

            Console.WriteLine("Nueva Póliza:");

            Console.WriteLine($" Id: {ObtenerIdUtility.ObtenerId(repo, false)} (generado automaticamente)"); 

            Console.Write(" Ingrese Id del Vehículo asegurado (2XXX): ");
            int IdVehiculo = int.Parse(Console.ReadLine() ?? "");
            if (!VehiculoExiste(IdVehiculo)) throw new Exception($"No existe un vehículo de Id: {IdVehiculo}");

            Console.Write(" Ingrese valor: ");
            float Valor = float.Parse(Console.ReadLine() ?? "");

            Console.Write(" Ingrese franquicia: ");
            float Franquicia = float.Parse(Console.ReadLine() ?? "");

            Console.Write(" Ingrese tipo de cobertura (0 ResponsabilidadCivil, 1 TodoRiesgo): ");
            Poliza.TipoCob TipoCobertura = (Poliza.TipoCob) Enum.Parse(typeof(Poliza.TipoCob), Console.ReadLine() ?? "");
            
            Console.Write(" Ingrese fecha de inicio de vigencia (dd/MM/yy): ");
            DateTime fechaInicioVigencia = DateTime.Parse(Console.ReadLine() ?? "");

            Console.Write(" Ingrese fecha de fin de vigencia (dd/MM/yy): ");
            DateTime fechaFinVigencia = DateTime.Parse(Console.ReadLine() ?? "");

            agregarPoliza.Ejecutar(new Poliza() 
            {
                Id = ObtenerIdUtility.ObtenerId(repo, true),
                IdVehiculo = IdVehiculo,
                Valor = Valor,
                Franquicia = Franquicia,
                TipoCobertura = TipoCobertura,
                FechaInicioVigencia = fechaInicioVigencia,
                FechaFinVigencia = fechaFinVigencia
            });

            Console.WriteLine("Nueva Póliza agregada con éxito.");
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
            var modificarPoliza = new ModificarPolizaUseCase(repo);
            
            Console.Write(" Ingrese Id de Póliza a modificar: ");
            int Id = int.Parse(Console.ReadLine() ?? "");

            Console.Write(" Ingrese Id del Vehículo asegurado (2XXX): ");
            int IdVehiculo = int.Parse(Console.ReadLine() ?? "");
            if (!VehiculoExiste(IdVehiculo)) throw new Exception($"No existe un Vehículo de Id: {IdVehiculo}");

            Console.Write(" Ingrese valor: ");
            float Valor = float.Parse(Console.ReadLine() ?? "");

            Console.Write(" Ingrese franquicia: ");
            float Franquicia = float.Parse(Console.ReadLine() ?? "");

            Console.Write(" Ingrese tipo de cobertura (0 ResponsabilidadCivil, 1 TodoRiesgo): ");
            Poliza.TipoCob TipoCobertura = (Poliza.TipoCob) Enum.Parse(typeof(Poliza.TipoCob), Console.ReadLine() ?? "");
            
            Console.Write(" Ingrese fecha de inicio de vigencia (dd/MM/yy): ");
            DateTime fechaInicioVigencia = DateTime.Parse(Console.ReadLine() ?? "");

            Console.Write(" Ingrese fecha de fin de vigencia (dd/MM/yy): ");
            DateTime fechaFinVigencia = DateTime.Parse(Console.ReadLine() ?? "");
            
            modificarPoliza.Ejecutar(new Poliza()
            {
                Id = Id,
                IdVehiculo = IdVehiculo,
                Valor = Valor,
                Franquicia = Franquicia,
                TipoCobertura = TipoCobertura,
                FechaInicioVigencia = fechaInicioVigencia,
                FechaFinVigencia = fechaFinVigencia
            });

            Console.WriteLine("Póliza modificada con éxito.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    private void Eliminar()
    {
        var eliminarPoliza = new EliminarPolizaUseCase(repo);

        Console.Write(" Ingrese Id de Póliza a eliminar: ");
        int Id = int.Parse(Console.ReadLine() ?? "");

        eliminarPoliza.Ejecutar(Id);

        Console.WriteLine("Póliza eliminada con éxito.");
    }
    private void Listar()
    {
        var listarPolizas = new ListarPolizasUseCase(repo);
        var lista = listarPolizas.Ejecutar();

        Console.WriteLine("Listando Pólizas:");
        foreach (Poliza p in lista)
        {
            Console.WriteLine(p);
        }
    }

    private bool VehiculoExiste(int IdBuscado)
    {
        bool res = false;
        IRepositorioVehiculo repo = new RepositorioVehiculoTXT();
        var listarVehiculos = new ListarVehiculosUseCase(repo);
        var lista = listarVehiculos.Ejecutar();
        foreach(Vehiculo v in lista)
        {
            if (v.Id == IdBuscado) 
            {
                res = true;              
                break;
            }
        }
        return res;
    }       
}
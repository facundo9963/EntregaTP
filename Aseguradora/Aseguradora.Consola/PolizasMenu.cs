namespace Aseguradora.Consola;
using Aseguradora.Repositorios;
using Aseguradora.Aplicacion;

public class PolizasMenu : IMenu
{
    private readonly IRepositorioPoliza repo = new RepositorioPolizaTXT();
    public void MostrarOpciones()
    {
        Console.WriteLine("1- Agregar Poliza");
        Console.WriteLine("2- Eliminar Poliza");
        Console.WriteLine("3- Modificar Poliza");
        Console.WriteLine("4- Listar Polizas");
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
        var agregarPoliza = new AgregarPolizaUseCase(repo);

        Console.WriteLine("Nueva Poliza:");

        //int id =
        //Console.WriteLine($" Id: {id} (generado automaticamente)"); 

        //verificar que existe, elegir agregar si no existe
        Console.Write(" Ingrese Id del Vehiculo asegurado: ");
        int IdVehiculo = int.Parse(Console.ReadLine() ?? "");

        Console.Write(" Ingrese valor: ");
        float Valor = float.Parse(Console.ReadLine() ?? "");
        Console.Write(" Ingrese franquicia: ");
        float Franquicia = float.Parse(Console.ReadLine() ?? "");

        Console.Write(" Ingrese tipo de cobertura (0 ResponsabilidadCivil, 1 TodoRiesgo): ");
        Poliza.TipoCob TipoCobertura = (Poliza.TipoCob) Enum.Parse(typeof(Poliza.TipoCob), Console.ReadLine() ?? "");
        
        DateTime fechaInicioVigencia = DateTime.Today;
        Console.WriteLine($" Fecha de inicio de vigencia: {fechaInicioVigencia:dd/MM/yy}");

        Console.Write(" Ingrese fecha de fin de vigencia (dd/MM/yy): ");
        DateTime fechaFinVigencia = DateTime.Parse(Console.ReadLine() ?? "");

        agregarPoliza.Ejecutar(new Poliza() 
        {
            //Id = id,
            IdVehiculo = IdVehiculo,
            Valor = Valor,
            Franquicia = Franquicia,
            TipoCobertura = TipoCobertura,
            FechaInicioVigencia = fechaInicioVigencia,
            FechaFinVigencia = fechaFinVigencia
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
        var listarPolizas = new ListarPolizasUseCase(repo);
        var lista = listarPolizas.Ejecutar();
        foreach (Poliza p in lista)
        {
            Console.WriteLine(p);
        }
    }
            
}
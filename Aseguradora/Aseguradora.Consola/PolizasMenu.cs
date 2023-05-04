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
        int id = int.Parse(Console.ReadLine() ?? "");
        int IdVehiculo = int.Parse(Console.ReadLine() ?? "");
        float Valor = float.Parse(Console.ReadLine() ?? "");
        float Franquicia = float.Parse(Console.ReadLine() ?? "");
        Poliza.TipoCob TipoCobertura = (Poliza.TipoCob) Enum.Parse(typeof(Poliza.TipoCob), Console.ReadLine() ?? "");
        agregarPoliza.Ejecutar(new Poliza() 
        {
            Id = id,
            IdVehiculo = IdVehiculo,
            Valor = Valor,
            Franquicia = Franquicia,
            TipoCobertura = TipoCobertura,
            FechaInicioVigencia = DateTime.Now,
            FechaFinVigencia = DateTime.Today
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
namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;

public class RepositorioVehiculoTXT : IRepositorioVehiculo
{
    readonly string _archivo = "vehiculos.txt";
    
    public void AgregarVehiculo(Vehiculo v)
    {
        using var sw = new StreamWriter(_archivo, true);
        sw.WriteLine(v.Id);
        sw.WriteLine(v.Dominio);
        sw.WriteLine(v.Marca);
        sw.WriteLine(v.Anio);
        sw.WriteLine(v.IdTitular);
    }
    public void ModificarVehiculo(Vehiculo v)
    {
        
    }
    public void EliminarVehiculo(int Id)
    {
        
    }

    public List<Vehiculo> ListarVehiculos()
    {
        var resultado = new List<Vehiculo>();
        using var sr = new StreamReader(_archivo);
        while(!sr.EndOfStream)
        {
            var v = new Vehiculo();
            v.Id = int.Parse(sr.ReadLine() ?? "");
            v.Dominio = sr.ReadLine() ?? "";
            v.Marca = sr.ReadLine() ?? "";
            v.Anio = int.Parse(sr.ReadLine() ?? "");
            v.IdTitular = int.Parse(sr.ReadLine() ?? "");
            resultado.Add(v);
        }
        return resultado;
    }
}

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
        Boolean encontre = false;
        try
        {
            using var sw = new StreamWriter(_archivo);
            using var sr = new StreamReader(_archivo);
            var vehiculo_leido = new Vehiculo();
            while (!sr.EndOfStream && !encontre)
            {
                vehiculo_leido.Id = int.Parse(sr.ReadLine() ?? "");
                vehiculo_leido.Dominio = sr.ReadLine() ?? "";
                vehiculo_leido.Marca = sr.ReadLine() ?? "";
                vehiculo_leido.Anio = int.Parse(sr.ReadLine() ?? "");
                vehiculo_leido.IdTitular = int.Parse(sr.ReadLine() ?? "");
                if (vehiculo_leido.Id == v.Id) {
                    vehiculo_leido = v;
                    encontre = true;
                    sw.WriteLine(vehiculo_leido);
                };
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public void EliminarVehiculo(int Id)
    {
        Boolean encontre = false;
        try
        {
            using var sw = new StreamWriter(_archivo);
            using var sr = new StreamReader(_archivo);
            while (!sr.EndOfStream && !encontre)
            {
                var vehiculo_leido = new Vehiculo();
                vehiculo_leido.Id = int.Parse(sr.ReadLine() ?? "");
                vehiculo_leido.Dominio = sr.ReadLine() ?? "";
                vehiculo_leido.Marca = sr.ReadLine() ?? "";
                vehiculo_leido.Anio = int.Parse(sr.ReadLine() ?? "");
                vehiculo_leido.IdTitular = int.Parse(sr.ReadLine() ?? "");
                if (vehiculo_leido.Id != Id)
                    sw.WriteLine(vehiculo_leido);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
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

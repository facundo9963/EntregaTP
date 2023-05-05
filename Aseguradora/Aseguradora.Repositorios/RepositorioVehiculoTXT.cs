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
        var lista = ListarVehiculos();
        bool encontrado = false;
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].Id == v.Id)
            {
                encontrado = true;
                lista[i] = v;
                break;
            }
        }
        try 
        {
            if (!encontrado) throw new Exception($"No existe vehículo de Id: {v.Id}");
            else
            {
                using (var vaciarArchivo = new StreamWriter(_archivo, false))
                {
                    
                };
                foreach (Vehiculo x in lista)
                {
                    AgregarVehiculo(x);
                }
            }
        }  
        catch (Exception e) 
        {
            Console.WriteLine(e.Message);
        }
    }
    public void EliminarVehiculo(int IdBuscado)
    {
        var lista = ListarVehiculos();
        bool encontrado = false;
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].Id == IdBuscado)
            {
                encontrado = true;
                lista.RemoveAt(i);
                break;
            }
        }
        try 
        {
            if (!encontrado) throw new Exception($"No existe vehículo de Id: {IdBuscado}");
            else
            {
                using (var vaciarArchivo = new StreamWriter(_archivo, false))
                {
                    
                };
                foreach (Vehiculo v in lista)
                {
                    AgregarVehiculo(v);
                }
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

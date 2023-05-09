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
            int id = int.Parse(sr.ReadLine() ?? "");
            string dominio = sr.ReadLine() ?? "";
            string marca = sr.ReadLine() ?? "";
            int anio = int.Parse(sr.ReadLine() ?? "");
            int idTitular = int.Parse(sr.ReadLine() ?? "");
            Vehiculo v = new Vehiculo(
                id,
                dominio,
                marca,
                anio,
                idTitular
            );
            resultado.Add(v);
        }
        return resultado;
    }
}

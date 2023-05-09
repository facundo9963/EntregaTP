namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;

public class RepositorioPolizaTXT : IRepositorioPoliza
{
    readonly string _archivo = "polizas.txt";
    public void AgregarPoliza(Poliza p)
    {
        using var sw = new StreamWriter(_archivo, true);
        sw.WriteLine(p.Id);
        sw.WriteLine(p.IdVehiculo);
        sw.WriteLine(p.Valor);
        sw.WriteLine(p.Franquicia);
        sw.WriteLine(p.TipoCobertura);
        sw.WriteLine(p.FechaInicioVigencia);
        sw.WriteLine(p.FechaFinVigencia);
    }
    public void ModificarPoliza(Poliza p)
    {
        var lista = ListarPolizas();
        bool encontrado = false;
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].Id == p.Id)
            {
                encontrado = true;
                lista[i] = p;
                break;
            }
        }
        try 
        {
            if (!encontrado) throw new Exception($"No existe Póliza de Id: {p.Id}");
            else
            {
                using (var vaciarArchivo = new StreamWriter(_archivo, false))
                {
                    
                };
                foreach (Poliza x in lista)
                {
                    AgregarPoliza(x);
                }
            }
        }  
        catch (Exception e) 
        {
            Console.WriteLine(e.Message);
        }
    }
    public void EliminarPoliza(int IdBuscado)
    {
        var lista = ListarPolizas();
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
            if (!encontrado) throw new Exception($"No existe Póliza de Id: {IdBuscado}");
            else
            {
                using (var vaciarArchivo = new StreamWriter(_archivo, false))
                {
                    
                };
                foreach (Poliza p in lista)
                {
                    AgregarPoliza(p);
                }
            }
        }  
        catch (Exception e) 
        {
            Console.WriteLine(e.Message);
        }
    }

    public List<Poliza> ListarPolizas()
    {
        var resultado = new List<Poliza>();
        using var sr = new StreamReader(_archivo);
        while(!sr.EndOfStream)
        {
            int Id = int.Parse(sr.ReadLine() ?? "");
            int IdVehiculo = int.Parse(sr.ReadLine() ?? "");
            float Valor = float.Parse(sr.ReadLine() ?? "");
            float Franquicia = float.Parse(sr.ReadLine() ?? "");
            Poliza.TipoCob TipoCobertura = (Poliza.TipoCob) Enum.Parse(typeof(Poliza.TipoCob), sr.ReadLine() ?? "");
            DateTime FechaInicioVigencia = DateTime.Parse(sr.ReadLine() ?? "");
            DateTime FechaFinVigencia = DateTime.Parse(sr.ReadLine() ?? "");
            Poliza p = new Poliza(
                Id,
                IdVehiculo,
                Valor,
                Franquicia,
                TipoCobertura,
                FechaInicioVigencia,
                FechaFinVigencia
            );
            resultado.Add(p);
        }
        return resultado;
    }
}

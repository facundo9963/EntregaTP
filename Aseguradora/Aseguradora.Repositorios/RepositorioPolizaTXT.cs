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

    }
    public void EliminarPoliza(int Id)
    {

    }

    public List<Poliza> ListarPolizas()
    {
        var resultado = new List<Poliza>();
        using var sr = new StreamReader(_archivo);
        while(!sr.EndOfStream)
        {
            var p = new Poliza();
            p.Id = int.Parse(sr.ReadLine() ?? "");
            p.IdVehiculo = int.Parse(sr.ReadLine() ?? "");
            p.Valor = float.Parse(sr.ReadLine() ?? "");
            p.Franquicia = float.Parse(sr.ReadLine() ?? "");
            p.TipoCobertura = (Poliza.TipoCob) Enum.Parse(typeof(Poliza.TipoCob), sr.ReadLine() ?? "");
            p.FechaInicioVigencia = DateTime.Parse(sr.ReadLine() ?? "");
            p.FechaFinVigencia = DateTime.Parse(sr.ReadLine() ?? "");
            resultado.Add(p);
        }
        return resultado;
    }
}

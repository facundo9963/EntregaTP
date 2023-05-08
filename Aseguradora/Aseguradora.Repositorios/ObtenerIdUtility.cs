namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;

public static class ObtenerIdUtility
{
    public static int ObtenerId(object IRepositorio, bool incrementar)
    {
        int id;
        string archivoId = "";
        if (IRepositorio is IRepositorioTitular) archivoId = "idTitular.txt";
        if (IRepositorio is IRepositorioVehiculo) archivoId = "idVehiculo.txt";
        if (IRepositorio is IRepositorioPoliza) archivoId = "idPoliza.txt";
        if (IRepositorio is IRepositorioSiniestro) archivoId = "idSiniestro.txt";
        if (IRepositorio is IRepositorioTercero) archivoId = "idTercero.txt";
        using (var sr = new StreamReader(archivoId))
        {
            id = int.Parse(sr.ReadLine() ?? "");
        }
        if (incrementar)
        {
            using var sw = new StreamWriter(archivoId, false);
            sw.WriteLine(++id);
        }
        return id;
    }
}
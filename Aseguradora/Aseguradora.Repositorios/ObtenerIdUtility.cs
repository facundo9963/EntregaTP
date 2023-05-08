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
        //ZXXX
        //Z    : código identificador (1 Titular, 2 Vehículo, 3 Póliza, 4 Siniestro, 5 Tercero)
        //XXX  : código único (hasta 7 dígitos disponibles, se usan 3 para mayor simpleza)
    }
}
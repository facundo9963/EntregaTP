namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;

public class RepositorioTitularTXT : IRepositorioTitular
{
    readonly string _archivo = "titulares.txt";
    public void AgregarTitular(Titular t)
    {
        using var sw = new StreamWriter(_archivo, true);
        sw.WriteLine(t.Id);
        sw.WriteLine(t.Apellido);
        sw.WriteLine(t.Nombre);
        sw.WriteLine(t.Dni);
        sw.WriteLine(t.Telefono);
        sw.WriteLine(t.Direccion);
        sw.WriteLine(t.Email);
        sw.WriteLine(t.ListaVehiculos);
    }
    public void ModificarTitular(int dni)
    {
        
    }
    public void EliminarTitular(int id)
    {
        
    }

    public List<Titular> ListarTitulares()
    {
        var resultado = new List<Titular>();
        using var sr = new StreamReader(_archivo);
        while(!sr.EndOfStream)
        {
            var t = new Titular();
            t.Id = int.Parse(sr.ReadLine() ?? "");
            t.Apellido = sr.ReadLine() ?? "";
            t.Nombre = sr.ReadLine() ?? "";
            t.Dni = int.Parse(sr.ReadLine() ?? "");
            t.Telefono = int.Parse(sr.ReadLine() ?? "");
            t.Direccion = sr.ReadLine() ?? "";
            t.Email = sr.ReadLine() ?? "";
            resultado.Add(t);
        }
        return resultado;
    }

    public List<Titular> ListarTitularesConSusVehiculos()
    {
        var resultado = new List<Titular>();
        using var sr = new StreamReader(_archivo);
        while(!sr.EndOfStream)
        {
            var t = new Titular();
            t.Id = int.Parse(sr.ReadLine() ?? "");
            t.Apellido = sr.ReadLine() ?? "";
            t.Nombre = sr.ReadLine() ?? "";
            t.Dni = int.Parse(sr.ReadLine() ?? "");
            t.Telefono = int.Parse(sr.ReadLine() ?? "");
            t.Direccion = sr.ReadLine() ?? "";
            t.Email = sr.ReadLine() ?? "";
            IRepositorioVehiculo repoVehiculo = new RepositorioVehiculoTXT();
            var listaVehiculos = new ListarVehiculosUseCase(repoVehiculo);
            t.ListaVehiculos = listaVehiculos.Ejecutar();
            resultado.Add(t);
        }
        return resultado;
    }
}

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
    }
    public void ModificarTitular(Titular t)
    {
        var lista = ListarTitulares();
        bool encontrado = false;
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].Dni == t.Dni)
            {
                encontrado = true;
                lista[i] = t;
                break;
            }
        }
        try
        {
            if (!encontrado) throw new Exception($"No existe Titular de Dni: {t.Dni}");
            else
            {
                using (var vaciarArchivo = new StreamWriter(_archivo, false))
                {

                };
                foreach (Titular x in lista)
                {
                    AgregarTitular(x);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    public void EliminarTitular(int IdBuscado)
    {
        var lista = ListarTitulares();
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
            if (!encontrado) throw new Exception($"No existe Titular de Id: {IdBuscado}");
            else
            {
                using (var vaciarArchivo = new StreamWriter(_archivo, false))
                {

                };
                foreach (Titular t in lista)
                {
                    AgregarTitular(t);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

    public List<Titular> ListarTitulares()
    {
        List<Titular> resultado = new List<Titular>();
        using var sr = new StreamReader(_archivo);
        while (!sr.EndOfStream)
        {
            int id = int.Parse(sr.ReadLine() ?? "");
            string apellido = sr.ReadLine() ?? "";
            string nombre = sr.ReadLine() ?? "";
            int dni = int.Parse(sr.ReadLine() ?? "");
            int telefono = int.Parse(sr.ReadLine() ?? "");
            string direccion = sr.ReadLine() ?? "";
            string email = sr.ReadLine() ?? "";
            Titular t = new Titular(
                id,
                apellido,
                nombre,
                dni,
                telefono,
                direccion,
                email
            );
            resultado.Add(t);
        }
        return resultado;
    }

    public List<Titular> ListarTitularesConSusVehiculos()
    {
        List<Titular> resultado = new List<Titular>();
        using var sr = new StreamReader(_archivo);
        while (!sr.EndOfStream)
        {
            int id = int.Parse(sr.ReadLine() ?? "");
            string apellido = sr.ReadLine() ?? "";
            string nombre = sr.ReadLine() ?? "";
            int dni = int.Parse(sr.ReadLine() ?? "");
            int telefono = int.Parse(sr.ReadLine() ?? "");
            string direccion = sr.ReadLine() ?? "";
            string email = sr.ReadLine() ?? "";
            IRepositorioVehiculo repoVehiculo = new RepositorioVehiculoTXT();
            ListarVehiculosUseCase listaVehiculos = new ListarVehiculosUseCase(repoVehiculo);
            List<Vehiculo> todosLosVehiculos = listaVehiculos.Ejecutar();
            List<Vehiculo> ListaVehiculos = todosLosVehiculos.Where(Vehiculo => Vehiculo.IdTitular == id).ToList();
            Titular t = new Titular(
                id,
                apellido,
                nombre,
                dni,
                telefono,
                direccion,
                email,
                ListaVehiculos
            );
            resultado.Add(t);
        }
        return resultado;
    }
}

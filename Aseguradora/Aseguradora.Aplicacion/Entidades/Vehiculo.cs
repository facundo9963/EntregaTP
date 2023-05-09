namespace Aseguradora.Aplicacion;
public class Vehiculo
{
    public int Id { get; private set; }
    public string Dominio { get; private set; } = "";
    public string Marca { get; private set; } = "";
    public int Anio { get; private set; }
    public int IdTitular { get; private set; }

    public Vehiculo(int id, string dominio, string marca, int anio, int idTitular)
    {
        this.Id = id;
        this.Dominio = dominio;
        this.Marca = marca;
        this.Anio = anio;
        this.IdTitular = idTitular;
    }
    
    public override string ToString()
    {
        return $"Id: {Id}, Dominio: {Dominio}, Marca: {Marca}, Anio: {Anio}. Id titular: {IdTitular}";
    }
}

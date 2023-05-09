namespace Aseguradora.Aplicacion;
public class Tercero: Persona
{
    //Hereda: Id, Apellido, Nombre, Dni, Telefono
    public string Aseguradora { get; private set; } = "";
    public int IdSiniestro { get; private set; }

    public Tercero(int id, string apellido, string nombre, int dni, int telefono, string aseguradora, int idSiniestro)
    {
        this.Id = id;
        this.Apellido = apellido;
        this.Nombre = nombre;
        this.Dni = dni;
        this.Telefono = telefono;
        this.Aseguradora = aseguradora;
        this.IdSiniestro = idSiniestro;
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Aseguradora: {Aseguradora}, Id siniestro: {IdSiniestro}";
    }
}

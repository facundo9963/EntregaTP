namespace Aseguradora.Aplicacion;
public class Tercero: Persona
{
    //Hereda: Id, Apellido, Nombre, Dni, Telefono
    public string Aseguradora { get; set; } = "";
    public int IdSiniestro { get; set; }
    public override string ToString()
    {
        return base.ToString() + $", Aseguradora {Aseguradora}, Id siniestro {IdSiniestro}";
    }
}

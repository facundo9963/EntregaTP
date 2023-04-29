namespace Aseguradora.Aplicacion;
public class Titular: Persona
{
    //Hereda: Id, Apellido, Nombre, Dni, Telefono
    public string Direccion { get; set; } = "";
    public string Email { get; set; } = "";
    public override string ToString()
    {
        return base.ToString() + $", Email {Email}, Direccion {Direccion}";
    }
}

namespace Aseguradora.Aplicacion;
public abstract class Persona
{
    public int Id { get; set; }
    public int Dni { get; set; }
    public string Apellido { get; set; } = "";
    public string Nombre { get; set; } = "";
    public int Telefono { get; set; }
    
    public override string ToString()
    {
        return $"Id: {Id}, Apellido: {Apellido}, Nombre: {Nombre}, DNI {Dni}, Telefono {Telefono}";
    }
}

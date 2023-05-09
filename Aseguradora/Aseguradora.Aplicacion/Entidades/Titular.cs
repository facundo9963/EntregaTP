namespace Aseguradora.Aplicacion;
public class Titular : Persona
{
    //Hereda: Id, Apellido, Nombre, Dni, Telefono
    public string Direccion { get; private set; } = "";
    public string Email { get; private set; } = "";

    public List<Vehiculo> ListaVehiculos { get; set; } = new List<Vehiculo>();

    public Titular(int id, string apellido, string nombre, int dni, int telefono, string direccion, string email)
    {
        this.Id = id;
        this.Apellido = apellido;
        this.Nombre = nombre;
        this.Dni = dni;
        this.Telefono = telefono;
        this.Direccion = direccion;
        this.Email = email;
    }
    public Titular(int id, string apellido, string nombre, int dni, int telefono, string direccion, string email, List<Vehiculo> listaVehiculos)
    {
        this.Id = id;
        this.Apellido = apellido;
        this.Nombre = nombre;
        this.Dni = dni;
        this.Telefono = telefono;
        this.Direccion = direccion;
        this.Email = email;
        this.ListaVehiculos = listaVehiculos;
    }

    public override string ToString()
    {
        return base.ToString() + $", Email: {Email}, Direccion: {Direccion}";
    }
}

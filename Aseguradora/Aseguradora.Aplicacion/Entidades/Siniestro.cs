namespace Aseguradora.Aplicacion;
public class Siniestro
{
    public int Id { get; private set; }
    public int IdPoliza { get; private set; }
    public DateTime FechaIngreso { get; private set; }
    public DateTime FechaOcurrencia { get; private set; }
    public string Direccion { get; private set; } = "";
    public string Descripcion { get; private set; } = "";

    public Siniestro(int id, int idPoliza, DateTime fechaIngreso, DateTime fechaOcurrencia, string direccion, string descripcion)
    {
        this.Id = id;
        this.IdPoliza = idPoliza;
        this.FechaIngreso = fechaIngreso;
        this.FechaOcurrencia = fechaOcurrencia;
        this.Direccion = direccion;
        this.Descripcion = descripcion;
    }
    
    public override string ToString()
    {
        return $"Id: {Id}, Id Póliza: {IdPoliza}, Fecha ingreso: {FechaIngreso:dd/MM/yy}, Fecha ocurrencia: {FechaOcurrencia:dd/MM/yy}, Direccion: {Direccion} , Descripcion: {Descripcion}";
    }
}

namespace Aseguradora.Aplicacion;
public class Siniestro
{
    public int Id { get; set; }
    public int IdPoliza { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime FechaOcurrencia { get; set; }
    public string Direccion { get; set; } = "";
    public string Descripcion { get; set; } = "";
    
    public override string ToString()
    {
        return $"{Id}: Id Poliza {IdPoliza}, ingreso {FechaIngreso:dd/MM/yyyy}. Descripcion: ({FechaOcurrencia:dd/MM/yyyy}, {Direccion}) {Descripcion}";
    }
}

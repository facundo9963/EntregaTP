namespace Aseguradora.Aplicacion;
public class Poliza
{
    public enum TipoCob
    {
        ResponsabilidadCivil, TodoRiesgo
    }
    public int Id { get; set; }
    public int IdVehiculo { get; set; }
    public float Valor { get; set; }
    public float Franquicia { get; set; }
    public TipoCob TipoCobertura { get; set; }
    public DateTime FechaInicioVigencia { get; set; }
    public DateTime FechaFinVigencia { get; set; }
    
    public override string ToString()
    {
        return $"{Id}: Id vehiculo {IdVehiculo}, valor asegurado de ${Valor} y franquicia de ${Franquicia} (Cobertura de tipo {TipoCobertura}). Vigente desde {FechaInicioVigencia:dd/MM/yy} hasta {FechaFinVigencia:dd/MM/yy}";
    }
}

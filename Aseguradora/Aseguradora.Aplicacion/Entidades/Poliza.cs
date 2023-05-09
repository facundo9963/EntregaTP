namespace Aseguradora.Aplicacion;
public class Poliza
{
    public enum TipoCob
    {
        ResponsabilidadCivil, TodoRiesgo
    }
    public int Id { get; private set; }
    public int IdVehiculo { get; private set; }
    public float Valor { get; private set; }
    public float Franquicia { get; private set; }
    public TipoCob TipoCobertura { get; private set; }
    public DateTime FechaInicioVigencia { get; private set; }
    public DateTime FechaFinVigencia { get; private set; }

    public Poliza(int id, int idVehiculo, float valor, float franquicia, TipoCob tipoCobertura, DateTime fechaIV, DateTime fechaFV)
    {
        this.Id = id;
        this.IdVehiculo = idVehiculo;
        this.Valor = valor;
        this.Franquicia = franquicia;
        this.TipoCobertura = tipoCobertura;
        this.FechaInicioVigencia = fechaIV;
        this.FechaFinVigencia = fechaFV;
    }
    
    public override string ToString()
    {
        return $"Id: {Id}, Id Vehículo: {IdVehiculo}, Valor Asegurado: {Valor}, Valor Franquicia: {Franquicia}, Cobertura de tipo: {TipoCobertura}, Fecha inicio vigencia: {FechaInicioVigencia:dd/MM/yy}, Fecha fin vigencia {FechaFinVigencia:dd/MM/yy}";
    }
}

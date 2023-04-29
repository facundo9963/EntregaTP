namespace Aseguradora.Aplicacion;
public class Vehiculo
{
    public int Id { get; set; }
    public string Dominio { get; set; } = "";
    public string Marca { get; set; } = "";
    public int Anio { get; set; }
    public int IdTitular { get; set; }
    public override string ToString()
    {
        return $"{Id}: Vehiculo {Dominio}, {Marca}({Anio}). Id titular: {IdTitular}";
    }
}

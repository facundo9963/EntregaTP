namespace Aseguradora.Aplicacion;
public interface IRepositorioPoliza
{
    void AgregarPoliza(Poliza p);
    void ModificarPoliza(Poliza p);
    void EliminarPoliza(int Id);
    List<Poliza> ListarPolizas();
}
namespace Aseguradora.Aplicacion;
public interface IRepositorioTitular
{
    void AgregarTitular(Titular t);
    void ModificarTitular(int dni);
    void EliminarTitular(int Id);
    List<Titular> ListarTitulares();
    List<Titular> ListarTitularesConSusVehiculos();
}

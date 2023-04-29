namespace Aseguradora.Aplicacion;
public interface IRepositorioTitular
{
    void AgregarTitular(Titular t);
    void ModificarTitular(Titular t);
    void EliminarTitular(int Id);
    List<Titular> ListarTitulares();
}

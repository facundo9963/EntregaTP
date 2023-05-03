namespace Aseguradora.Aplicacion;
public class EliminarTitularUseCase
{
    private readonly IRepositorioTitular _repo;
    public EliminarTitularUseCase(IRepositorioTitular repo)
    {
        _repo = repo;
    }
    public void Ejecutar(int Id)
    {
        _repo.EliminarTitular(Id);
    }
}
namespace Aseguradora.Aplicacion;
public class AgregarTitularUseCase
{
    private readonly IRepositorioTitular _repo;
    public AgregarTitularUseCase(IRepositorioTitular repo)
    {
        _repo = repo;
    }
    public void Ejecutar(Titular t)
    {
        _repo.AgregarTitular(t);
    }
}
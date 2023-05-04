namespace Aseguradora.Aplicacion;
public class ModificarTitularUseCase
{
    private readonly IRepositorioTitular _repo;
    public ModificarTitularUseCase(IRepositorioTitular repo)
    {
        _repo = repo;
    }
    public void Ejecutar(int dni)
    {
        _repo.ModificarTitular(dni);
    }
}
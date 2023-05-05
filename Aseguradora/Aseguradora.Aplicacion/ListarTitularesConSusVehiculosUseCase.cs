namespace Aseguradora.Aplicacion;
public class ListarTitularesConSusVehiculosUseCase
{
    private readonly IRepositorioTitular _repo;
    public ListarTitularesConSusVehiculosUseCase(IRepositorioTitular repo)
    {
        _repo = repo;
    }
    public List<Titular> Ejecutar()
    {
        return _repo.ListarTitularesConSusVehiculos();
    }
}
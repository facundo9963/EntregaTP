namespace Aseguradora.Aplicacion;
public class EliminarVehiculoUseCase
{
    private readonly IRepositorioVehiculo _repo;
    public EliminarVehiculoUseCase(IRepositorioVehiculo repo)
    {
        _repo = repo;
    }
    public void Ejecutar(int Id)
    {
        _repo.EliminarVehiculo(Id);
    }
}
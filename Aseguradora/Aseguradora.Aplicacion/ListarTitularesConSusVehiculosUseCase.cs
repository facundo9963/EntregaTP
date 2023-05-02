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
    /* Añadir un caso de uso llamado ListarTitularesConSusVehiculosUseCase que
permita listar todos los titulares junto con la información detallada de sus vehículos asegurados. Es
importante tener en cuenta que cada titular puede ser propietario de uno o varios vehículos. Una posible
forma de resolverlo es contar con una propiedad de tipo List<Vehiculo> en la entidad Titular que puede
usarse, cuando sea necesario, para agregar allí la lista de vehículos que posee el titular.*/
}
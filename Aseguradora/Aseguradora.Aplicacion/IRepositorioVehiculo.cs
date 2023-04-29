namespace Aseguradora.Aplicacion;
public interface IRepositorioVehiculo
{
    void AgregarVehiculo(Vehiculo v);
    void ModificarVehiculo(Vehiculo v);
    void EliminarVehiculo(int Id);
    List<Vehiculo> ListarVehiculos();
}

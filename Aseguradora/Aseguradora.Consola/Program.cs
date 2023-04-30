using Aseguradora.Aplicacion;
using Aseguradora.Repositorios;

IRepositorioPoliza repoPoliza = new RepositorioPolizaTXT();

var agregarPoliza = new AgregarPolizaUseCase(repoPoliza);
var listarPolizas = new ListarPolizasUseCase(repoPoliza);

agregarPoliza.Ejecutar(new Poliza() {Id=1,
                                    IdVehiculo=3942,
                                    Valor=65.99f,
                                    Franquicia=33.99f,
                                    TipoCobertura=Poliza.TipoCob.ResponsabilidadCivil,
                                    FechaInicioVigencia=DateTime.Now,
                                    FechaFinVigencia=DateTime.Today
                                    });

var lista = listarPolizas.Ejecutar();
foreach (Poliza p in lista)
{
    Console.WriteLine(p);
}
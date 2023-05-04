using Aseguradora.Aplicacion;
using Aseguradora.Repositorios;
using Aseguradora.Consola;

IRepositorioPoliza repoPoliza = new RepositorioPolizaTXT();

var agregarPoliza = new AgregarPolizaUseCase(repoPoliza);
var listarPolizas = new ListarPolizasUseCase(repoPoliza);

IMenu menuDeVehiculos = new VehiculosMenu();

int input;
do
{
    Console.WriteLine("2-Menu de Vehiculos");
    Console.WriteLine("Escribi tu opcion");
    input = int.Parse(Console.ReadLine() ?? "");
    switch (input)
    {
        case 1:
            int id = int.Parse(Console.ReadLine() ?? "");
            int IdVehiculo = int.Parse(Console.ReadLine() ?? "");
            float Valor = float.Parse(Console.ReadLine() ?? "");
            float Franquicia = float.Parse(Console.ReadLine() ?? "");
            Poliza.TipoCob TipoCobertura = (Poliza.TipoCob) Enum.Parse(typeof(Poliza.TipoCob), Console.ReadLine() ?? "");
            agregarPoliza.Ejecutar(new Poliza() {Id = id,
                                                IdVehiculo = IdVehiculo,
                                                Valor = Valor,
                                                Franquicia = Franquicia,
                                                TipoCobertura = TipoCobertura,
                                                FechaInicioVigencia = DateTime.Now,
                                                FechaFinVigencia = DateTime.Today
                                                });
            break;
        case 2:
            menuDeVehiculos.MostrarOpciones();
            Console.WriteLine("Escribi tu opcion");
            int opc2 = Convert.ToInt32(Console.ReadLine());
            menuDeVehiculos.EjecutarOpcion(opc2);
            break;
        case 3:
            break;
        case 4:
            var lista = listarPolizas.Ejecutar();
            foreach (Poliza p in lista)
            {
                Console.WriteLine(p);
            }
            break;
        case 5:
            break;
        case 0:
            break;
    }
}
while (input != 0);

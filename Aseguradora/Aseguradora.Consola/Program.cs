using Aseguradora.Aplicacion;
using Aseguradora.Repositorios;
using Aseguradora.Consola;

IRepositorioPoliza repoPoliza = new RepositorioPolizaTXT();
IRepositorioTitular repoTitular = new RepositorioTitularTXT();
IRepositorioVehiculo repoVehiculo = new RepositorioVehiculoTXT();

var agregarPoliza = new AgregarPolizaUseCase(repoPoliza);
var listarPolizas = new ListarPolizasUseCase(repoPoliza);

IMenu menuDeVehiculos = new VehiculosMenu();

int input;
do
{   
    Console.WriteLine();
    Console.WriteLine("------- MENU -------");
    Console.WriteLine("1: Menu de Polizas");
    Console.WriteLine("2: Menu de Titulares");
    Console.WriteLine("3: Menu de Vehiculos");
    Console.WriteLine("4: Menu de Siniestros (sin implementar)");
    Console.WriteLine("5: Menu de Terceros (sin implementar)");
    Console.WriteLine("0: Salida");
    Console.Write("Ingrese opcion: ");
    Console.WriteLine();
    input = int.Parse(Console.ReadLine() ?? "");
    switch (input)
    {
        case 1:
            break;
        case 2:
            menuDeVehiculos.MostrarOpciones();
            Console.WriteLine("Escribi tu opcion");
            int opc2 = int.Parse(Console.ReadLine() ?? "");
            menuDeVehiculos.EjecutarOpcion(opc2);
            break;
        case 3:
            break;
        case 4:
            break;
        case 5:
            break;
    }
}
while (input != 0);

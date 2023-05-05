using Aseguradora.Aplicacion;
using Aseguradora.Repositorios;
using Aseguradora.Consola;

IMenu menuEntidad;
int input = -1;
do
{   
    Console.WriteLine("------- MENU -------");
    Console.WriteLine("1: Menu de Titulares");
    Console.WriteLine("2: Menu de Vehículos");
    Console.WriteLine("3: Menu de Pólizas");
    Console.WriteLine("4: Menu de Siniestros (sin implementar)");
    Console.WriteLine("5: Menu de Terceros (sin implementar)");
    Console.WriteLine("0: Salida");
    Console.Write("Ingrese opción: ");
    leerInput();
    Console.WriteLine();
    switch (input)
    {
        case 1:
            menuEntidad = new TitularesMenu();
            menuEntidad.MostrarOpciones();
            Console.Write("Ingrese opción: ");
            leerInput();
            menuEntidad.EjecutarOpcion(input);
            break;
        case 2:
            menuEntidad = new VehiculosMenu();
            menuEntidad.MostrarOpciones();
            Console.Write("Ingrese opción: ");
            leerInput();
            menuEntidad.EjecutarOpcion(input);
            break;
        case 3:
            menuEntidad = new PolizasMenu();
            menuEntidad.MostrarOpciones();
            Console.Write("Ingrese opción: ");
            leerInput();
            menuEntidad.EjecutarOpcion(input);
            break;
        case 4:
            Console.WriteLine("No implementado");
            break;
        case 5:
            Console.WriteLine("No implementado");
            break;
        case 0:
            Console.Write("Fin del programa (Presione enter para salir...)");
            Console.ReadLine();
            break;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
    Console.WriteLine();
}
while (input != 0);

void leerInput()
{
    try {input = int.Parse(Console.ReadLine() ?? "");} catch (Exception e) {Console.WriteLine(e.Message);}
}
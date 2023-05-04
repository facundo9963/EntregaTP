﻿using Aseguradora.Aplicacion;
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
    Console.WriteLine("2-Menu de Vehiculos");
    Console.WriteLine("Escribi tu opcion");
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

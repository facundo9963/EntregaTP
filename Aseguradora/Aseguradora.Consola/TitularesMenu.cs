namespace Aseguradora.Consola;
using Aseguradora.Repositorios;
using Aseguradora.Aplicacion;

public class TitularesMenu : IMenu
{
    public void MostrarOpciones()
    {
        Console.WriteLine("1- Agregar Titular");
        Console.WriteLine("2- Eliminar Titular");
        Console.WriteLine("3- Modificar Titular");
        Console.WriteLine("4- Listar Titulares");
        Console.WriteLine("5- Listar Titulares con Vehiculos");
    }
    public void EjecutarOpcion(int opc)
    {
        switch (opc)
        {
            case 1:
                Agregar();
                break;
            case 2:
                Eliminar();
                break;
            case 3:
                Modificar();
                break;
            case 4:
                Listar();
                break;
            case 5:
                Listar2();
                break;
        }
    }
    private void Agregar()
    {

    }
    private void Eliminar()
    {

    }
    private void Modificar()
    {

    }
    private void Listar()
    {

    }
    private void Listar2()
    {

    }
}
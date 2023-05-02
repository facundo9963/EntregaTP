using Aseguradora.Aplicacion;
using Aseguradora.Repositorios;

IRepositorioPoliza repoPoliza = new RepositorioPolizaTXT();

var agregarPoliza = new AgregarPolizaUseCase(repoPoliza);
var listarPolizas = new ListarPolizasUseCase(repoPoliza);

int input;
input = int.Parse(Console.ReadLine());
while (input != 0)
{
    switch (input)
    {
        case 1:
            int id = int.Parse(Console.ReadLine());
            int IdVehiculo = int.Parse(Console.ReadLine());
            float Valor = float.Parse(Console.ReadLine());
            float Franquicia = float.Parse(Console.ReadLine());
            Poliza.TipoCob TipoCobertura = (Poliza.TipoCob) Enum.Parse(typeof(Poliza.TipoCob), Console.ReadLine());
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
        case 0:
            break;
    }
    input = int.Parse(Console.ReadLine());
}

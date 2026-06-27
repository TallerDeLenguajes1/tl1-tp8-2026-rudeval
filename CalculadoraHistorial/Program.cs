using EspacioCalculadora; 
using EspacioOperacion;
/*
ejemplo:    historial
            0 + 5 = 5 --> clase operacion
            5 * 2 = 10 --> clase operacion
            10 - 3 = 7 --> clase operacion
            7 / 4 = 1,75 --> clase operacion
*/

Calculadora InstCalculadora = new Calculadora();

bool continuar = true;
do
{
    Console.WriteLine($"-> Resultado actual: {InstCalculadora.Resultado}");

    Console.WriteLine("--CALCULADORA--");
    Console.WriteLine(
        "1 - Sumar\n" +
        "2 - Restar\n" +
        "3 - Multiplicar\n" +
        "4 - Dividir\n" +
        "5 - Limpiar\n" +
        "6 - Mostrar historial\n" +
        "0 - Salir del programa"
    );

    Console.WriteLine("Ingrese el numero de operacion: ");
        int eleccion;
        do
        {
            eleccion = PedirNumeroInt();
        } while (eleccion<0 || eleccion>6);
        

    switch (eleccion)
    {
        case 0: 
            continuar = false; 
            Console.WriteLine("Programa finalizado");
            break;

        case 1: 
            Console.Write($"Sumar: {InstCalculadora.Resultado} + ");
                double numSumar = PedirNumeroDouble();
            InstCalculadora.Sumar(numSumar); //suma y agrega operacion al historial
            break;

        case 2: 
            Console.Write($"Restar: {InstCalculadora.Resultado} - ");
                double numRestar = PedirNumeroDouble();
            InstCalculadora.Restar(numRestar);
            break;

        case 3: 
            Console.Write($"Multiplicar: {InstCalculadora.Resultado} * ");
                double numMultiplicar = PedirNumeroDouble();
            InstCalculadora.Multiplicar(numMultiplicar);
            break;

        case 4: 
            Console.Write($"Dividir: {InstCalculadora.Resultado} / ");
                double numDividir = PedirNumeroDouble();
            InstCalculadora.Dividir(numDividir);
            break;

        case 5:
            InstCalculadora.Limpiar();
            Console.WriteLine("Calculadora reiniciada.");
            break;

        case 6:
            Console.WriteLine("--HISTORIAL--");
            //revisar que no este vacio:
            if (InstCalculadora.Historial.Count == 0)
            {
                Console.WriteLine("No hay operaciones en el historial.");
            }else
            {
                foreach (Operacion op in InstCalculadora.Historial)
                {
                    if (op.PropOperacion == TipoOperacion.Limpiar)
                    {
                        Console.WriteLine($"{op.ResultadoAnterior} -> 0 (Limpiar)");
                    }else
                    {
                        Console.WriteLine($"{op.ResultadoAnterior} {op.SimboloOperacion()} {op.NuevoValor} = {op.Resultado}");  
                    }
                }
            }
            
            break;

        default: 
            Console.WriteLine("Opción no válida. Intente de nuevo.");
            break;
    }
        
} while (continuar);    


static double PedirNumeroDouble()
{
    double numero;
    bool valido;

    do
    {
        string entrada = Console.ReadLine();

        valido = double.TryParse(entrada, out numero);

        if (!valido)
        {
            Console.WriteLine("Numero no valido, ingrese otro");
        }

    } while (!valido);

    return numero;
}

static int PedirNumeroInt()
{
    int numero;
    bool valido;

    do
    {
        string entrada = Console.ReadLine();

        valido = int.TryParse(entrada, out numero);

        if (!valido)
        {
            Console.WriteLine("Numero no valido, ingrese otro");
        }

    } while (!valido);

    return numero;
}


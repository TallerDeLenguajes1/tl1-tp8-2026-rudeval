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

int continuar = 1;
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
        "0 - Salir"
    );

    Console.WriteLine("Ingrese el numero de operacion: ");
            int eleccion = PedirNumeroInt();

        switch (eleccion)
        {
            case 0: 
                continuar = 0; 
                Console.WriteLine("Programa finalizado");
                break;

            case 1: 
                Console.Write($"Sumar: {InstCalculadora.Resultado} + ");
                    double numSumar = PedirNumeroDouble();
                InstCalculadora.Sumar(numSumar);
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

            default: 
                Console.WriteLine("Opción no válida. Intente de nuevo.");
                break;
        }
        
} while (continuar == 1);    


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


using EspacioOperacion; 
namespace EspacioCalculadora
{
    public class Calculadora 
    {
        //campos
        private double dato; 

        //agregamos lista de objetos de tipo Operacion
        private List<Operacion> historial; 

        //creamos constructor para inicializar la lista
        public Calculadora()
        {
            dato = 0;
            historial = new List<Operacion>(); //asi, al hacer new Calculadora() se crea la lista vacia
        }

        //propiedad para visualizar el historial
        public List<Operacion> Historial
        {
            get => historial;
        }

        //propiedad GET
        public double Resultado
        {
            get => dato; //cuando se pida "Resultado" devuelve el valor de "dato" 

        }   


        //metodos que agregan al historial:
        public void Sumar(double termino) 
        {
            //Crear objeto y aregar al historial
            Operacion op = new Operacion(dato, termino, TipoOperacion.Suma);
            historial.Add(op);

            //actualizamos dato
            dato += termino;
            
        }

        public void Restar(double termino)
        {
            Operacion op = new Operacion(dato, termino, TipoOperacion.Resta);
            historial.Add(op);

            dato -= termino;
        }

        public void Multiplicar(double termino)
        {
            Operacion op = new Operacion(dato, termino, TipoOperacion.Multiplicacion);
            historial.Add(op);

            dato *= termino;

        }

        public void Dividir(double termino) //termino == nuevoDato
        {
            if (termino != 0)
            {
                //si no es 0, lo agregamos al historial
                Operacion op = new Operacion(dato, termino, TipoOperacion.Division);
                historial.Add(op);

                dato /= termino;
            }
            else
            {
                //no agregamos al historial
                Console.WriteLine("No se puede dividir por cero.");
            }
            
        }

        public void Limpiar()
        {
            Operacion op = new Operacion(dato, 0, TipoOperacion.Limpiar); 
            historial.Add(op);

            dato = 0;
        }


    }
    
}
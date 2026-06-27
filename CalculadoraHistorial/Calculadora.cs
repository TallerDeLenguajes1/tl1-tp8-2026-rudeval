using EspacioOperacion; 
namespace EspacioCalculadora
{
    public class Calculadora 
    {
        private double dato; //campo dato

        //agregamos lista de objetos de tipo Operacion
        //private List<Operacion> historial; 

        //agregamos propiedad para el historial
        /*public List<Operacion> Historial
        {
            get
        }*/

        //propiedad GET
        public double Resultado
        {
            get => dato; //cuando se pida "Resultado" devuelve el valor de "dato"

        }   

        //metodos:
        public void Sumar(double termino) 
        {
            dato += termino;
            
        }

        public void Restar(double termino)
        {
            dato -= termino;
        }

        public void Multiplicar(double termino)
        {
            dato *= termino;
        }

        public void Dividir(double termino)
        {
            if (termino != 0)
            {
                dato /= termino;
            }
            else
            {
                Console.WriteLine("No se puede dividir por cero.");
            }
            
        }

                    /*
            Ej uso:
            Calculadora MiInstancia = new Calculadora();
            MiInstancia.Dividir(10); //divide el dato por 10
            */

        public void Limpiar()
        {
            dato = 0;
        }


    }
    
}
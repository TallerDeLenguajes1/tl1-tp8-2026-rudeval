namespace EspacioOperacion
{
    public enum TipoOperacion //primer elemento = 0 e incrementa. 
                        // cargos Cargo = cargos.Auxiliar 
                        // int valorCargo = (int)Cargo; --> devuelve 0
    { 
        Suma, 
        Resta, 
        Multiplicacion, 
        Division, 
        Limpiar  // Representa la acción de borrar el resultado actual o el historial 
    }

    public class Operacion
    { 
        //campos
        private double resultadoAnterior; // Almacena el resultado previo al cálculo actual 
        private double nuevoValor; //El valor con el que se opera sobre el resultadoAnterior    
        private TipoOperacion operacion;// El tipo de operación realizada 

        //propiedad
        public double Resultado
        {
            /* Lógica para calcular o devolver el resultado */

            get
            {
                switch (operacion)
                {
                    case TipoOperacion.Suma: 
                        return resultadoAnterior + nuevoValor;
                    case TipoOperacion.Resta: 
                        return resultadoAnterior - nuevoValor;
                    case TipoOperacion.Multiplicacion: 
                        return resultadoAnterior * nuevoValor;
                    case TipoOperacion.Division: 
                        return resultadoAnterior / nuevoValor;
                    case TipoOperacion.Limpiar: 
                        return 0;
                    default:
                        return resultadoAnterior;
                }
                
            }
            
        }
        //propiedad
        public double ResultadoAnterior
        {
            get => resultadoAnterior;
        }

        // Propiedad para acceder al nuevo valor utilizado en la operación 
        public double NuevoValor
        { 
                get {return nuevoValor;}
        } 

        //Propiedad para leer la operacion realizada
        public TipoOperacion PropOperacion
        {
            get => operacion;
        }

        // Constructor y otros métodos necesarios para inicializar y gestionar la operación 
        //Constructor para inicializar
        public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operacion)
        {
            this.resultadoAnterior = resultadoAnterior; 
            this.nuevoValor = nuevoValor;
            this.operacion = operacion;
        } 

        //metodos
        public string SimboloOperacion()
        {
            switch (operacion)
            {
                case TipoOperacion.Suma:
                    return "+";
                    
                case TipoOperacion.Resta:
                    return "-";

                case TipoOperacion.Multiplicacion:
                    return "*";

                case TipoOperacion.Division:
                    return "/";

                case TipoOperacion.Limpiar:
                    return "=";

                default:
                    return "?";
            }

        }


    }

}

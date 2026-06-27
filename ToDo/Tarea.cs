namespace EspacioTarea
{
    public class Tarea
    {
        //propiedades automaticas para guardar cada campo
        public int TareaID { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; } //validar que este entre 10 y 100

        //constructor para inicializar
        public Tarea(int id, string descripcion, int duracion)
        {
            TareaID = id;
            Descripcion = descripcion;
            Duracion = duracion;
        }

        //metodo para mostrar campos
        public void Mostrar()
        {
            Console.WriteLine($"ID: {TareaID} | Descripción: {Descripcion} | Duración: {Duracion}");
        }
    }
}
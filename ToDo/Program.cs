using EspacioTarea;
//creamos listas vacias de tipo Tarea
List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();

//generar tareas
Console.WriteLine("Ingrese la cantidad de tareas a crear: ");
    int cantidadTareas = PedirNumeroInt();
CrearTarea(cantidadTareas, tareasPendientes);

//mostrar tareas
Console.WriteLine("--Tareas Pendientes--");
MostrarLista(tareasPendientes);

//Mover elemento por ID


static void MoverPorID(List<Tarea> listaPartida, List<Tarea> listaDestino)
{
    //Controlo que no este vacia la Lista de partida
    if (listaPartida.Count == 0) {return;}

    //inicializo aux y pido datos
    Tarea elementoEncontrado = null;

    Console.WriteLine("-> Ingrese ID de la tarea completada: ");
        int idBuscar = PedirNumeroInt();

    //si encuentra coincidencias, guarda, elimina. Sino mensaje. 
    foreach (Tarea e in listaPartida)
    {
        if (e.TareaID == idBuscar)
        {
            elementoEncontrado = e; //guardo en var aux
        }

        if (elementoEncontrado != null)
        {
            listaPartida.Remove(elementoEncontrado);
            listaDestino.Add(elementoEncontrado);
            Console.WriteLine("La tarea fue marcada como realizada.");
        }
        else
        {
            Console.WriteLine("No se encontró el ID");   
        }

    }
    
}

static void MostrarLista(List<Tarea> lista)
{
    //verifica que no este vacia
    if (lista.Count == 0)
    {
        Console.WriteLine("No hay tareas en esta lista.");
        return;
    }

    //Muestra
    foreach (Tarea elemento in lista)
    {
        elemento.Mostrar();
    }

}

static void CrearTarea(int cantidadTareas, List<Tarea> tareasPendientes)
{
    //descripciones posibles
    string [] descripciones = 
    { 
        "Controlar stock", 
        "Preparar pedidos", 
        "Cargar productos", 
        "Atender proovedores"
    };

    Random random = new Random(); //genera numeros aleatorios: 
                            //random.Next(10,101) genera entre 10 y 100

    for (int i = 0; i < cantidadTareas; i++)
    {
        int id = i+1;
        //elegir aleatoriamente
        string descripcion = descripciones[random.Next(descripciones.Length)];
        int duracion = random.Next(10,101);

        //guardar info en tarea
        Tarea nuevaTarea = new Tarea(id, descripcion ,duracion);
        //agregar tarea a lista de tareas pendientes
        tareasPendientes.Add(nuevaTarea);
    }
    
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

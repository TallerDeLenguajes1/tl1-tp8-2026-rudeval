using EspacioTarea;
//creamos listas vacias de tipo Tarea
List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();

//generar tareas validando numero
int cantidadTareas;
do
{
    Console.WriteLine("Ingrese la cantidad de tareas a crear: ");
    cantidadTareas = PedirNumeroInt();
} while (cantidadTareas <= 0);

CrearTareas(cantidadTareas, tareasPendientes);

//MENU interactivo
int opcion; 
do
{
    Console.WriteLine("\n===== MENÚ TO DO =====");
    Console.WriteLine("1. Mostrar tareas pendientes");
    Console.WriteLine("2. Mostrar tareas realizadas");
    Console.WriteLine("3. Marcar tarea como realizada");
    Console.WriteLine("4. Buscar tarea pendiente por descripción");
    Console.WriteLine("5. Mostrar todas las tareas");
    Console.WriteLine("6. Salir");

    Console.Write("Seleccione una opción: ");
        opcion = PedirNumeroInt();
    
    switch (opcion)
    {
        case 1: 
            //mostrar tareas pendientes
            Console.WriteLine("--Tareas Pendientes--");
            MostrarLista(tareasPendientes);
            break;
        case 2: 
            //mostrar tareas realizadas
            Console.WriteLine("--Tareas Realizadas--");
            MostrarLista(tareasRealizadas);
            break;
        case 3: 
            //Mover elemento por ID | Marcar como realizada
            //mostramos IDs disponibles
            Console.WriteLine("--Tareas Pendientes--");
            MostrarLista(tareasPendientes);
            //movemos
            MoverPorID(tareasPendientes, tareasRealizadas);
            break;
        case 4: 
            //Buscar por descripcion y mostrar 
            Console.WriteLine("--Buscar tarea en Pendientes--");
            BuscarDescripcionYMostrar(tareasPendientes);
            break;
        case 5: 
            //mostrar todas las tareas
            Console.WriteLine("--Tareas Realizadas--");
            MostrarLista(tareasRealizadas);
            Console.WriteLine("--Tareas Pendientes--");
            MostrarLista(tareasPendientes);
            break;
        case 6:
            Console.WriteLine("Programa finalizado");
            break;

        default:
            Console.WriteLine("Opción inválida.");
                break;
    }
    

} while (opcion != 6);

    


static void BuscarDescripcionYMostrar(List<Tarea> listaPartida)
{
    //Controlo que no este vacia la Lista de partida
    if (listaPartida.Count == 0) 
    {
        Console.WriteLine("Lista vacia");
        return;
    }

    //pido datos e inicializo
    Console.Write("Ingrese una palabra o descripción a buscar: ");
        string textoBuscado = Console.ReadLine();
    
    bool encontrada = false;

    //recorro, busco y muestro todas las coincidencias
    foreach (Tarea e in listaPartida)
    {
        if (e.Descripcion.ToLower().Contains(textoBuscado.ToLower())) //fuerzo minusculas
        {
            e.Mostrar();
            encontrada = true;
        }
    }

    //si no encuentra
    if (!encontrada)
    {
        Console.WriteLine("No se encontraron tareas pendientes con esa descripción.");
    }

}


static void MoverPorID(List<Tarea> listaPartida, List<Tarea> listaDestino)
{
    //Controlo que no este vacia la Lista de partida
    if (listaPartida.Count == 0) {return;}

    //inicializo aux y pido datos
    Tarea elementoEncontrado = null;

    Console.WriteLine("-> Ingrese ID de la tarea completada: ");
        int idBuscar = PedirNumeroInt();

    //recorro lista y guardo en var aux lo encontrado
    foreach (Tarea e in listaPartida)
    {
        if (e.TareaID == idBuscar)
        {
            elementoEncontrado = e; 
            break; 
        }

    }

    //si encuentra coincidencias, guarda, elimina. Sino mensaje. 
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

static void CrearTareas(int cantidadTareas, List<Tarea> tareasPendientes)
{
    //descripciones posibles
    string [] descripciones = 
    { 
        "Controlar stock", 
        "Preparar pedidos", 
        "Cargar productos", 
        "Atender proveedores"
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
            Console.WriteLine("Numero no valido, intente nuevamente");
        }

    } while (!valido);

    return numero;
}

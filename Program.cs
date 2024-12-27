List<string> TaskList = new List<string>();

int menuSelected = 0;


/// <summary>
/// Show the options for Task, 1. Nueva tarea
/// </summary>
/// <returns>Returns option selected by user</returns>
int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");
    string optionSelected = Console.ReadLine();
    return Convert.ToInt32(optionSelected);
}


void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string task = Console.ReadLine();
        TaskList.Add(task);
        Console.WriteLine("Tarea registrada");
    }
    catch (Exception)
    {
    }
}


void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        ShowTasks();
        int taskIndex = Convert.ToInt32(Console.ReadLine()) - 1;
        if (taskIndex > -1 && TaskList.Count > 0)
        {
            string task = TaskList[taskIndex];
            TaskList.RemoveAt(taskIndex);
            Console.WriteLine($"Tarea {task} eliminada");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}


void ShowTasks()
{
    if (TaskList?.Count > 0)
    {
        var indexTask = 0;
        Console.WriteLine("----------------------------------------");
        TaskList.ForEach(p => Console.WriteLine($"{++indexTask}. {p}"));
        Console.WriteLine("----------------------------------------");
    } 
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}


do
{
    menuSelected = ShowMainMenu();
    if ((Menu)menuSelected == Menu.Add)
    {
        ShowMenuAdd();
    }
    else if ((Menu)menuSelected == Menu.Remove)
    {
        ShowMenuRemove();
    }
    else if ((Menu)menuSelected == Menu.List)
    {
        ShowTasks();
    }
}
while ((Menu)menuSelected != Menu.Exit);


public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}

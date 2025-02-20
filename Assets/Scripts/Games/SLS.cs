using UnityEngine;

public class SSL : MonoBehaviour, Game
{
    public GameObject initialUI;
    public GameObject systemInit;

    public void OnAwake(){
        // EventSystem.Init();

        // RankSystem.Init();
        // TaskSystem.Init();
        // this will be executed when the user goes through the "create a player" screen, i haven't made that yet
        systemInit.GetComponent<Systems>().InitAllSystems();

        Player.Init("Dhanish");
    }

    public void OnStart()
    {
        Task task1 = new Task(TaskType.tasktype.STRENGTH, "Push-ups", 10, 0, 300);
        Task task2 = new Task(TaskType.tasktype.STAMINA, "Plank hold", 0, 10, 300);
        Task task3 = new Task(TaskType.tasktype.STRENGTH, "Completed", 0, 0, 100);
        Task task4 = new Task(TaskType.tasktype.STRENGTH, "Completed", 0, 0, 100);

        TaskSystem.instance.pushTask(task1);
        TaskSystem.instance.pushTask(task2);
        TaskSystem.instance.pushTask(task3);
        TaskSystem.instance.pushTask(task4);

        // Initialized all the UI components
        UISystem.instance.changeUI(initialUI.GetComponent<View>());
    }
    
    public void OnRunning()
    {
        // 
    }
    
    public void OnPause()
    {
        // as this is a UI based game we can't pause it
    }

    public void OnExit()
    {
        Application.Quit();
    }
}

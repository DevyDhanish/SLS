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
    }

    public void OnStart()
    {
        Player.Init("Dhanish");
        // Task task1 = new Task(TaskType.tasktype.STRENGTH, "Push-ups", 10, 0, 300);
        // Task task2 = new Task(TaskType.tasktype.STAMINA, "Plank hold", 0, 10, 300);

        // TaskSystem.instance.pushTask(task1);
        // TaskSystem.instance.pushTask(task2);

        // Initialized all the UI components

        NotificationSystem.instance.showNotification(
            NotificationSystem.instance.createNotification_typeOK(
            "Hey",
            "This is just a sample",
            () => {
                Debug.Log("Clicked ok");
            }
            )
        );
        
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

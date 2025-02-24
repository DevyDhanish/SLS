using UnityEngine;

public class SSL : MonoBehaviour, Game
{
    public GameObject initialUI;
    public GameObject systemInit;

    public void OnAwake(){
        // EventSystem.Init();

        // RankSystem.Init();
        // TaskSystem.Init();

        // Init all the Systems in Awake cuz they have `instances` so to make them available to everyone
        systemInit.GetComponent<Systems>().InitAllSystems();
    }

    public void OnStart()
    {
        UISystem.instance.changeUI(initialUI.GetComponent<View>());


        
        // Init all the Controllers that control some thing one way or another
        // The reason to do it in `Start` rather than awake is. there might me some controller
        // the depends on the instance of some system or attatches it self to some event.
        // so to make sure that everything is available to the controller it's best to INIT them in Start

        systemInit.GetComponent<Systems>().InitAllControllers();
        // Task task1 = new Task(TaskType.tasktype.STRENGTH, "Push-ups", 10, 0, 300);
        // Task task2 = new Task(TaskType.tasktype.STAMINA, "Plank hold", 0, 10, 300);

        // TaskSystem.instance.pushTask(task1);
        // TaskSystem.instance.pushTask(task2);

        // Initialized all the UI components

        // NotificationSystem.instance.showNotification(
        //     NotificationSystem.instance.createNotification_typeOK(
        //     "Hey",
        //     "This is just a sample",
        //     (GameObject g) => {
        //         Debug.Log("Clicked ok");
        //         Debug.Log(g.transform.name);
        //     }
        //     )
        // );
        
        // This is just a playerholder player creator it will be replaced by the `welcome player` screen and that will create the player.
        Player.Init("Dhanish");

        SaveSystem.instance.loadGameData(); // run it at last so that everything is already created and it will just overwrite with saved information.

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

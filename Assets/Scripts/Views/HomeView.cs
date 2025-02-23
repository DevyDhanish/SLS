using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HomeView : MonoBehaviour, View
{
    private Canvas thisCanvas;

    public TextMeshProUGUI taskText;

    public GameObject taskViewParent;
    public GameObject taskViewObj;

    private Task currentTask;

    public void OnClick()
    {
        UISystem.instance.changeUIbyName("ProfileView");
    }

    public void goTS()
    {
        UISystem.instance.changeUIbyName("TaskSchedule");
    }

    // public void onFinish(GameObject btn)
    // {
    //     TaskSystem.instance.completeTask(7);
    //     refresh();
    // }

    public void refresh(){
        Disable();
        Enable();
    }

    // private string gt()
    // {
    //     string tasktext = "";
    //     currentTask = TaskSystem.instance.getTask();

    //     if (currentTask != null) 
    //     {
    //         tasktext = currentTask.getDescription() + "[" + currentTask.getCount().ToString() + "]";
    //     }

    //     return tasktext;
    // }

    // private void cTaskView(Task t)
    // {
    //     GameObject tv = Instantiate(taskViewObj);
    //     tv.transform.SetParent(taskViewParent.transform);

    //     tv.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(t.description);
    // }

    void Start()
    {
        thisCanvas = gameObject.GetComponent<Canvas>();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        gameObject.SetActive(true);

        // for(int i = 0; i < taskViewParent.transform.childCount; i++)
        // {
        //     Destroy(taskViewParent.transform.GetChild(i).gameObject);
        // }

        // List<Task> at = TaskSystem.instance.getAllTask();

        // foreach(Task t in at)
        // {
        //     cTaskView(t);
        // }
    }
}

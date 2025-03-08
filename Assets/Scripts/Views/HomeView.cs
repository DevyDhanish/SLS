using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HomeView : MonoBehaviour, View
{
    private Canvas thisCanvas;

    public TextMeshProUGUI taskText;

    public GameObject rankSlider;
    public GameObject taskViewParent;
    public GameObject taskViewObj;

    // public void onFinish(GameObject btn)
    // {
    //     TaskSystem.instance.completeTask(7);
    //     refresh();
    // }

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
        rankSlider.GetComponent<View>().Disable();
    }

    public void Enable()
    {
        gameObject.SetActive(true);
        rankSlider.GetComponent<View>().Enable();
    }
}

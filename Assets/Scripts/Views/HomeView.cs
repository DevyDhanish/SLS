using TMPro;
using UnityEngine;

public class HomeView : MonoBehaviour, View
{
    private Canvas thisCanvas;

    public TextMeshProUGUI taskText;

    private Task currentTask;

    public void OnClick()
    {
        UISystem.instance.changeUIbyName("ProfileView");
    }

    public void goNext()
    {
        TaskSystem.instance.completeTask();
        refresh();
    }

    public void refresh(){
        Disable();
        Start();
        Enable();
    }

    private string gt()
    {
        string tasktext = "";
        currentTask = TaskSystem.instance.getTask();

        if (currentTask != null) 
        {
            tasktext = currentTask.getDescription() + "[" + currentTask.getCount().ToString() + "]";
        }

        return tasktext;
    }

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
        taskText.SetText(gt());
    }
}

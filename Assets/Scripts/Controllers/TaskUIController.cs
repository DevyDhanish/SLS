using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskUIController : MonoBehaviour, Controllers
{
    public GameObject taskUiObject;

    public void InitController()
    {
        EventSystem.instance.OnTaskAdded += OnTaskAdd;
        EventSystem.instance.OnTaskComplete += OnTaskCompleted;

        //TaskSystem.instance.loadSavedTasks(); // it will load saved tasks if any other wise it will set a new List of tasks.
    }

    private void OnTaskComBtnClick(int BtnID)
    {
        TaskSystem.instance.completeTask(
            TaskSystem.instance.getTaskById(BtnID)
        );
    }

    private void OnTaskAdd(Task addedTask)
    {
        GameObject taskUI = Instantiate(taskUiObject);

        taskUI.transform.GetComponentInChildren<TextMeshProUGUI>().SetText(
            String.Format(
                "[{0}] {1}",
                addedTask.count.ToString(),
                addedTask.description
            )
            );

        // add the TaskUI component and set the ID to correspond to the Task backend
        taskUI.AddComponent<TaskUI>();
        taskUI.GetComponent<TaskUI>().TaskID = addedTask.TaskId;

        // add the OnTaskComBtnClick as a listener to the Obj
        // taskUI.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => OnTaskComBtnClick(
        //     taskUI.GetComponent<TaskUI>().TaskID
        // ));

        taskUI.transform.GetComponentInChildren<Button>().onClick.AddListener(() => OnTaskComBtnClick(
            taskUI.GetComponent<TaskUI>().TaskID
        ));

        taskUI.transform.SetParent(gameObject.transform);
    }

    private void OnTaskCompleted(Task t)
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform c = gameObject.transform.GetChild(i);

            if(c.GetComponent<TaskUI>().TaskID == t.TaskId)
            {
                Destroy(c.gameObject);
                break;
            }
        }
    }
}

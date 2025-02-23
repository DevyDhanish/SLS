using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TaskUIController : MonoBehaviour
{
    public GameObject taskUiObject;

    void Start()
    {
        EventSystem.instance.OnTaskAdded += OnTaskAdd;
        EventSystem.instance.OnTaskComplete += OnTaskCompleted;

        TaskSystem.instance.loadSavedTasks(); // it will load saved tasks if any other wise it will set a new List of tasks.
    }

    public void OnTaskComBtnClick(int BtnID)
    {
        TaskSystem.instance.completeTask(
            TaskSystem.instance.getTaskById(BtnID)
        );
    }

    private void OnTaskAdd(Task addedTask)
    {
        GameObject taskUI = Instantiate(taskUiObject);

        taskUI.transform.GetComponentInChildren<TextMeshProUGUI>().SetText(addedTask.description);

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

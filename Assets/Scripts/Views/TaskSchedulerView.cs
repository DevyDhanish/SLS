using System;
using TMPro;
using UnityEngine;

public class TaskSchedulerView : MonoBehaviour, View
{
    public TextMeshProUGUI taskDesc;
    public TextMeshProUGUI taskType;
    public TMP_InputField taskSets;

    public void OnClickAdd()
    {
        TaskType.tasktype tt = TaskType.tasktype.STRENGTH;

        if(taskType.text == "Stamina")
        {
            tt = TaskType.tasktype.STAMINA;
        }

        if(taskType.text == "Strength")
        {
            tt = TaskType.tasktype.STRENGTH;
        }

        string setText = taskSets.text.Trim();

        if (int.TryParse(setText, out int setCount))
        {
            // result is your number, do what you need with it
        }
        else
        {
            Debug.Log("Invalid number format in TextMeshPro text. : " + setText);
        }

        // Debug.Log(taskSets.text);
        // Int32.TryParse(taskSets.text, out set);
        // Debug.Log(set);

        Task task = new Task(
            tt,
            TaskSystem.instance.getNewTaskID(),
            taskDesc.text,
            setCount,
            0,
            SLSParameters.instance.getRewardOnTaskComplete()
        );

        TaskSystem.instance.pushTask(task);
    }

    public void OnClick()
    {
        UISystem.instance.changeUIbyName("TaskSchedule");
    }

    public void goBack()
    {
        UISystem.instance.goBack();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }
}

using System;
using TMPro;
using UnityEngine;

public class TaskSchedulerView : MonoBehaviour, View
{
    public TextMeshProUGUI taskDesc;
    public TextMeshProUGUI taskType;
    public TextMeshProUGUI taskSets;

    public void OnClickAdd()
    {
        TaskType.tasktype tt = TaskType.tasktype.STRENGTH;

        if(taskType.text == "Stamina")
        {
            tt = TaskType.tasktype.STAMINA;
        }

        if(taskType.text == "Strenght")
        {
            tt = TaskType.tasktype.STRENGTH;
        }

        int set = 0;

        Int32.TryParse(taskSets.text, out set);

        Task task = new Task(
            tt,
            TaskSystem.instance.getNewTaskID(),
            taskDesc.text,
            set,
            0,
            10
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

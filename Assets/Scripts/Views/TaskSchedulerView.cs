using System;
using System.Linq;
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
            
        }
        else
        {
            NotificationSystem.instance.showNotification(
                NotificationSystem.instance.createNotification_typeOK(
                    "Error",
                    "Invalid Sets x Reps",
                    (GameObject g) => {
                        return;
                    }
                )
            );

            return;
        }

        //Debug.Log(taskDesc.text.Length);
        if (string.IsNullOrWhiteSpace(taskDesc.text) || taskDesc.text.Length == 1)
        {
            NotificationSystem.instance.showNotification(
                NotificationSystem.instance.createNotification_typeOK(
                    "Error",
                    "Invalid exercise name",
                    (GameObject g) => {
                        return;
                    }
                )
            );

            return;
        }

        string taskName = taskDesc.text.Trim();
        if(taskName.Any(char.IsDigit))
        {
            NotificationSystem.instance.showNotification(
                NotificationSystem.instance.createNotification_typeOK(
                    "Error",
                    "Wtf is that exercise name bruh.",
                    (GameObject g) => {
                        return;
                    }
                )
            );

            return;
        }


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

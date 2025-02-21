using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaskSystem : Systems
{
    public static TaskSystem instance;

    public List<Task> allTasks;

    private TaskSystem(){}

    // public static void Init(){
    //     instance = new TaskSystem();
    // }

    public override void Init(){
        if(instance != this && instance != null) Destroy(gameObject);
        
        instance = this;
    }

    public void loadSavedTasks()
    {
        if(SaveSystem.instance.gameData != null)
        {
            Debug.Log("Loading tasks");
            foreach(Task t in SaveSystem.instance.gameData.primaryTask)
            {
                pushTask(t);
            }
        }

        else
        {
            allTasks = new List<Task>();
        }   
    }
    // Don't use this you heard.
    // public Task getNextTask()
    // {
    //     Debug.Log(allTasks.Peek().getDescription());

    //     return allTasks.Dequeue();
    // }

    public int getNewTaskID()
    {
        int id = allTasks.Count;

        if(getTaskById(id) == null) return id;
        else return id + 1;
    }

    // when a task is added fire the task added event
    public void pushTask(Task task)
    {
        allTasks.Add(task);
        Debug.Log(task.description);
        EventSystem.instance.FireOnTaskAdded(task);
    }

    // public Task getTask(){
    //     if(allTasks.Count <= 0) return null;

    //     return allTasks.Peek();
    // }

    public List<Task> getAllTask()
    {
        return allTasks;
    }

    public Task getTaskById(int id)
    {
        foreach(Task t in allTasks)
        {
            if(t.TaskId == id)
            {
                return t;
            }
        }

        return null;
        // if((id) <= allTasks.Count && (id) >= 0) return allTasks[id];
        // else return null;
    }

    public void completeTask(Task task)
    {
        foreach(Task t in allTasks)
        {
            if(task.TaskId == t.TaskId)
            {
                t.OnComplete();
                EventSystem.instance.FireUpdatePlayerRankEvent(Player.instance);        // update the rank of player
        
                //allTasks.Dequeue();

                allTasks.Remove(t);

                SaveSystem.instance.saveGameData(SaveSystem.instance.createGameData(Player.instance,
                new List<Task>(allTasks),
                new List<Task>()));     // save
                break;
            }
        }
        

        // if(allTasks.Count <= 0) return;

        // Task curntTask = allTasks.Peek();

        // EventSystem.instance.FireTaskCompleteEvent(curntTask.getTaskResult());  // task is completed

    }
}

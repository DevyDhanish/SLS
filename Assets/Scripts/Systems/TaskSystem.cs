using System.Collections.Generic;
using UnityEngine;

public class TaskSystem : Systems
{
    public static TaskSystem instance;

    public Queue<Task> allTasks;

    private TaskSystem(){}

    // public static void Init(){
    //     instance = new TaskSystem();
    // }

    public override void Init(){
        if(instance != this && instance != null) Destroy(gameObject);
        
        instance = this;

        if(SaveSystem.instance.gameData != null)
        {
            List<Task> savedTasks = SaveSystem.instance.gameData.primaryTask;

            instance.allTasks = new Queue<Task>(savedTasks);
        }

        else
        {
            allTasks = new Queue<Task>();
        }
    }
    // Don't use this you heard.
    public Task getNextTask()
    {
        Debug.Log(allTasks.Peek().getDescription());

        return allTasks.Dequeue();
    }

    public void pushTask(Task task)
    {
        allTasks.Enqueue(task);
    }

    public Task getTask(){
        if(allTasks.Count <= 0) return null;

        return allTasks.Peek();
    }

    public void completeTask()
    {
        if(allTasks.Count <= 0) return;

        Task curntTask = allTasks.Peek();

        EventSystem.instance.FireTaskCompleteEvent(curntTask.getTaskResult());  // task is completed
        EventSystem.instance.FireUpdatePlayerRankEvent(Player.instance);        // update the rank of player
        
        allTasks.Dequeue();

        SaveSystem.instance.saveGameData(SaveSystem.instance.createGameData(Player.instance,
        new List<Task>(allTasks),
        new List<Task>()));     // save
    }
}

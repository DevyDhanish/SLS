using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaskSystem : Systems, SavableObject<List<TaskSystem.TaskSaveObject>>
{
    public static TaskSystem instance;

    public List<Task> allTasks = new List<Task>();

    [System.Serializable]
    public class TaskSaveObject
    {
        public int TaskId;
        public TaskType.tasktype type;
        public string description;
        public int count;
        //public int duration; // For time-based tasks (e.g., planks in seconds)
        public int reward;
    }

    private TaskSystem(){}

    // public static void Init(){
    //     instance = new TaskSystem();
    // }

    public override void Init(){
        if(instance != this && instance != null) Destroy(gameObject);
        
        instance = this;

        EventSystem.instance.OnGameLoad += loadSavedTasks;
    }

    public void loadSavedTasks(SaveObject so)
    {
        if(so != null)
        {
            allTasks.Clear();
            Debug.Log("Loading saved tasks");

            foreach(TaskSaveObject t in so.pendingTasks)
            {
                Task newTask = new Task(
                    t.type,
                    t.TaskId,
                    t.description,
                    t.count,
                    0,
                    t.reward
                );

                pushTask(newTask);
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
        task.OnComplete();
        allTasks.Remove(task);
        // for(int i = 0; i < allTasks.Count; i++)
        // {
        //     if(task.TaskId == allTasks[i].TaskId)
        //     {
        //         task.OnComplete();

        //         //EventSystem.instance.FireUpdatePlayerRankEvent(PlayerSystem.instance.currentPlayer);        // update the rank of player
        //         //allTasks.Dequeue();

        //         allTasks.Remove(task);
        //     }
        // }
        

        // if(allTasks.Count <= 0) return;

        // Task curntTask = allTasks.Peek();

        // EventSystem.instance.FireTaskCompleteEvent(curntTask.getTaskResult());  // task is completed

    }

    public List<TaskSaveObject> getSavableObject()
    {
        List<TaskSaveObject> Ltso = new List<TaskSaveObject>();

        foreach(Task ta in allTasks)
        {
            TaskSaveObject tso = new TaskSaveObject();
            tso.TaskId = ta.TaskId;
            tso.type =  ta.type;
            tso.description = ta.description;
            tso.count = ta.count;
            tso.reward = ta.reward;

            Ltso.Add(tso);
        }

        return Ltso;
    }
}

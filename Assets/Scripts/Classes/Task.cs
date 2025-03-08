using System;
using System.Data.Common;
using UnityEngine;

public class Task
{

    public int TaskId {get; private set;}
    public TaskType.tasktype type {get; private set;}
    public string description {get; private set;}
    public int count {get; private set;}   // For repetitions (e.g., pushups)
    //public int duration; // For time-based tasks (e.g., planks in seconds)
    public int reward {get; private set;} // the amount of point to add to the stats of the player upon completion.

    public Task(TaskType.tasktype type, int id, string description, int count, int duration, int reward) {
        this.TaskId = id;
        this.type = type;
        this.description = description;
        this.count = count;
        //this.duration = duration;
        this.reward = reward;
    }

    // public TaskType.tasktype getType() {
    //     return type;
    // }

    // public string getDescription() {
    //     return description;
    // }

    // public int getCount() {
    //     return count;
    // }

    // public int getDuration() {
    //     return duration;
    // }

    public TaskResult getTaskResult()
    {
        TaskResult tr = new TaskResult { Type = type, result = reward };

        return tr;
    }

    public void OnComplete()
    {
        EventSystem.instance.FireTaskCompleteEvent(this);
    }
}


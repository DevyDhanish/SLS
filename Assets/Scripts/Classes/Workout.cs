using System;
using UnityEngine;

[Serializable]
public class Workout
{
    public string workoutName;
    public string workoutVariation;
    public int minAge;
    public int maxAge;
    public TaskType.tasktype taskType;

    public Workout(string workoutName, string workoutVariation, int minAge, int maxAge, TaskType.tasktype taskType)
    {
        this.workoutName = workoutName;
        this.workoutVariation = workoutVariation;
        this.minAge = minAge;
        this.maxAge = maxAge;
        this.taskType = taskType;
    }
}

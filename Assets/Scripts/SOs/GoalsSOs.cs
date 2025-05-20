using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Goal")]
public class GoalsSOs : ScriptableObject
{
    public string goalName;
    public int id;

    [Serializable]
    public class GoalTask
    {
        public string taskName;
        public TaskType.tasktype type;
        public int setxreps;
    }

    public List<GoalTask> taskNeeded = new List<GoalTask>();
}

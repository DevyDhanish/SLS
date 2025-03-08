using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveObject
{
    public bool isPlayerRegistered;
    public PlayerSystem.playerSavableObject playerSO;
    public List<TaskSystem.TaskSaveObject> pendingTasks;
}

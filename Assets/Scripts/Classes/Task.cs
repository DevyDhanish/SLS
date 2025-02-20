[System.Serializable]
public class Task {

    public TaskType.tasktype type;
    public string description;
    public int count;    // For repetitions (e.g., pushups)
    public int duration; // For time-based tasks (e.g., planks in seconds)
    public int reward; // the amount of point to add to the stats of the player upon completion.

    public Task(TaskType.tasktype type, string description, int count, int duration, int reward) {
        this.type = type;
        this.description = description;
        this.count = count;
        this.duration = duration;
        this.reward = reward;
    }

    public TaskType.tasktype getType() {
        return type;
    }

    public string getDescription() {
        return description;
    }

    public int getCount() {
        return count;
    }

    public int getDuration() {
        return duration;
    }

    public TaskResult getTaskResult()
    {
        TaskResult tr = new TaskResult { Type = type, result = reward };

        return tr;
    }
}


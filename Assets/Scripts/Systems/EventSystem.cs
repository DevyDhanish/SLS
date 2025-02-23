using UnityEngine;

// all the event this game uses are here
public class EventSystem : Systems
{
    public static EventSystem instance;

    // public static void Init(){
    //     if(instance == null)
    //     {
    //         instance = new EventSystem();
    //     }
    // }

    public override void Init(){
        if(instance != null && instance != this)
            Destroy(gameObject);

        
        instance = this;
    }


    // update rank event
    public delegate void UpdatePlayerRank(Player player);
    public event UpdatePlayerRank OnUpdatePlayerRank;

    public void FireUpdatePlayerRankEvent(Player player)
    {
        OnUpdatePlayerRank?.Invoke(player);
        Debug.Log("Fired {Update player ranks}");
    }

    // player ranked up event
    public delegate void PlayerRankedUp(Player player, Rank rank);
    public event PlayerRankedUp OnPlayerRankUp;

    public void FirePlayerRankedUpEvent(Player player, Rank rank)
    {
        OnPlayerRankUp?.Invoke(player, rank);
        Debug.Log("Fired {Player ranked up} " + rank.rank);
    }

    // task completed event
    public delegate void TaskCompleted(Task t);
    public event TaskCompleted OnTaskComplete;

    public void FireTaskCompleteEvent(Task t){
        OnTaskComplete?.Invoke(t);
        Debug.Log("Fired {Task completed}");
    }

    // when saved
    public delegate void GameSaved();
    public event GameSaved OnGameSaved;

    public void FireOnGameSaved(){
        OnGameSaved?.Invoke();
        Debug.Log("Fired {Game Save}");
    }

    // when a task is added
    public delegate void TaskAdded(Task t);
    public event TaskAdded OnTaskAdded;

    public void FireOnTaskAdded(Task t)
    {
        OnTaskAdded?.Invoke(t);
    }
}

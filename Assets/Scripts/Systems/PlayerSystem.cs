using UnityEditor;
using UnityEngine;

public class PlayerSystem : Systems
{
    public static PlayerSystem instance;

    public Player currentPlayer {get; private set;}

    public override void Init()
    {
        if(instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }

        EventSystem.instance.OnTaskComplete += onTaskCompleted;
    }

    public void createNewPlayer(string name)
    {
        currentPlayer = new Player(
            name,
            Rank.getRank(0),
            0,
            new Stats(),
            ""
        );
    }

    // when a task is completed
    // update stats
    // then update the rank
    // if ranked up then fire ranked up

    private void onTaskCompleted(Task t)
    {
        switch(t.type)
        {
            case TaskType.tasktype.STRENGTH:
                Stats.updateStats(currentPlayer.playerStats, Stats.StatsType.STATS_STRENGTH, t.reward);
                break;
            case TaskType.tasktype.STAMINA:
                Stats.updateStats(currentPlayer.playerStats, Stats.StatsType.STATS_STAMINA, t.reward);
                break;
            default:
                break;
        }

        Rank nextRank = Rank.getRank(currentPlayer.playerStats.Score);

        if (nextRank != null && currentPlayer.Rank != null && nextRank.rankTitle != currentPlayer.Rank.rankTitle)
        {
            // Fire ranked up event
            currentPlayer.setRank(nextRank);
            EventSystem.instance.FirePlayerRankedUpEvent(currentPlayer, nextRank);
        }
    }

    // TODO: attach it to the game loaded event
    public void loadPlayer(GameData playerData)
    {

    }
}

using System;
using UnityEditor;
using UnityEngine;

public class PlayerSystem : Systems, SavableObject<PlayerSystem.playerSavableObject>
{
    public static PlayerSystem instance;

    public Player currentPlayer {get; private set;}

    [Serializable]
    public class playerSavableObject
    {
        public string playerName;
        public Rank.RankSavableObject rankSO;
        public Stats.StatsSavableObject statsSO;
        public string Category;
    }

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
        EventSystem.instance.OnGameLoad += loadPlayer;
    }

    public void createNewPlayer(string name)
    {
        currentPlayer = new Player(
            name,
            Rank.getRank(0),
            new Stats(
                0,
                0,
                0
            ),
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

        if (nextRank != null && currentPlayer.Rank != null && nextRank.RankTitle != currentPlayer.Rank.RankTitle)
        {
            // Fire ranked up event
            currentPlayer.setRank(nextRank);
            EventSystem.instance.FirePlayerRankedUpEvent(currentPlayer, nextRank);
        }
    }

    public playerSavableObject getSavableObject()
    {
        playerSavableObject p = new playerSavableObject();

        p.playerName = currentPlayer.Name;
        p.Category = currentPlayer.Category;
        p.statsSO = currentPlayer.playerStats.getSavableObject();
        p.rankSO = currentPlayer.Rank.getSavableObject();

        return p;
    }

    //TODO: attach it to the game loaded event
    public void loadPlayer(SaveObject gameData)
    {
        Player p = new Player(
            gameData.playerSO.playerName,
            new Rank(
                gameData.playerSO.rankSO.rankTitle,
                gameData.playerSO.rankSO.rankThreshold
            ),
            new Stats(
                gameData.playerSO.statsSO.strength,
                gameData.playerSO.statsSO.stamina,
                gameData.playerSO.statsSO.score
            ),
            ""
        );

        currentPlayer = p;
    }
}

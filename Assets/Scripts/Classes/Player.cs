using System;
using UnityEngine;

[System.Serializable]
public class Player
{
    private Player(){}

    public static Player instance;

    public string Name;
    public Rank Rank;
    public int Score;
    public Stats playerStats;
    //public Sprite profilePhoto {get; private set;}
    public string Category;

    public static void Init(String name)
    {
        instance = new Player();
        instance.Name = name;
        instance.playerStats = new Stats();
        instance.Rank = new Rank{
            rank = "no rank",
            maxscore = 0,
            minscore = 0
        };
        Debug.Log("Created new player");
        // instance.profilePhoto = pfp;
        // instance.Rank = rank;
        // instance.Category = category;

        EventSystem.instance.OnTaskComplete += instance.updateStats;
        EventSystem.instance.OnPlayerRankUp += instance.updateRank;  
        EventSystem.instance.OnGameLoad += instance.loadPlayer;
    }

    // run this method when `taskcompleted even is fired`
    private void updateStats(Task t){
        TaskResult tr = t.getTaskResult();

        if(tr.Type == TaskType.tasktype.STRENGTH)
        {
            playerStats.incStrength(tr.result);
            //playerStats.incStrength(500);
        }

        if(tr.Type == TaskType.tasktype.STAMINA)
        {
            playerStats.incStamina(tr.result);
            //playerStats.incStamina(500);
        }

        Score = (playerStats.Stamina + playerStats.Strength) / 2;
    }

    private void updateRank(Player player, Rank rank)
    {
        if(player.Rank != rank)
            player.Rank = rank;
    }

    // problem:
    // the loading event happens in awake so it's fired way before the player get's to attach to it.
    // that's why this method not getting executing when loading.
    private void loadPlayer(GameData g)
    {
        Debug.Log("Loaded player");
        // point to the loaded player, i hope the new one that get's created get's deleted.
        instance = g.playerInfo;

        EventSystem.instance.OnTaskComplete += instance.updateStats;
        EventSystem.instance.OnPlayerRankUp += instance.updateRank;  
        EventSystem.instance.OnGameLoad += instance.loadPlayer;
    }
}

using System;
using UnityEngine;



public class Player
{
    public string Name {get; private set;}
    public Rank Rank {get; private set;}// public int Score {get; private set;}
    public Stats playerStats {get; private set;}
    public string Category {get; private set;}

    public Player(string name, Rank rank, Stats stats, string category)
    {
        Name = name;
        Rank = rank;
        //Score = score;
        playerStats = stats;
        Category = category;
    }

    public void setName(string name)
    {
        Name = name;
    }

    public void setRank(Rank rank)
    {
        Rank = rank;
    }

    public void setStat(Stats stats)
    {
        playerStats = stats;
    }

    // public static void Init()
    // {
    //     instance = new Player();
    //     // instance.profilePhoto = pfp;
    //     // instance.Rank = rank;
    //     // instance.Category = category;

    //     instance.subscribeToEvents();
    // }

    // public void createNewPlayer(string name)
    // {
    //     // remove the prev instance
    //     // instance.unSubscribeToEvents();
    //     // instance = null;

    //     Player p = new Player();
    //     p.Name = name;
    //     p.playerStats = new Stats();
    //     p.Rank = new Rank{
    //         rank = "no rank",
    //         maxscore = 0,
    //         minscore = 0
    //     };
    //     p.subscribeToEvents();

    // }

    // run this method when `taskcompleted even is fired`
    // private void updateStats(Task t){
    //     TaskResult tr = t.getTaskResult();

    //     if(tr.Type == TaskType.tasktype.STRENGTH)
    //     {
    //         playerStats.incStrength(tr.result);
    //         //playerStats.incStrength(500);
    //     }

    //     if(tr.Type == TaskType.tasktype.STAMINA)
    //     {
    //         playerStats.incStamina(tr.result);
    //         //playerStats.incStamina(500);
    //     }

    //     Score = (playerStats.Stamina + playerStats.Strength) / 2;
    // }

    // private void updateRank(Player player, Rank rank)
    // {
    //     if(player.Rank != rank)
    //         player.Rank = rank;
    // }

    // problem:
    // // the loading event happens in awake so it's fired way before the player get's to attach to it.
    // // that's why this method not getting executing when loading.
    // private void loadPlayer(GameData g)
    // {
    //     // instance.unSubscribeToEvents();
    //     // instance = null;

    //     Debug.Log("Loaded player");
    //     // point to the loaded player, i hope the new one that get's created get's deleted.
    //     Player p = g.playerInfo;

    //     subscribeToEvents();
    // }
}

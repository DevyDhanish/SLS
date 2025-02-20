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
        if(instance == null && SaveSystem.instance.gameData == null)
        {
            instance = new Player();

            instance.Name = name;
            instance.playerStats = new Stats();

            instance.Rank = new Rank{
                rank = "no rank",
                maxscore = 0,
                minscore = 0
            };
            // instance.profilePhoto = pfp;
            // instance.Rank = rank;
            // instance.Category = category;
        }

        if(SaveSystem.instance.gameData != null)
        {
            GameData savedGame = SaveSystem.instance.gameData;
            instance = savedGame.playerInfo;
        }

        EventSystem.instance.OnTaskComplete += instance.updateStats;
        EventSystem.instance.OnPlayerRankUp += instance.updateRank;  
    }

    // run this method when `taskcompleted even is fired`
    private void updateStats(TaskResult t){
        if(t.Type == TaskType.tasktype.STRENGTH)
        {
            playerStats.incStrength(t.result);
            //playerStats.incStrength(500);
        }

        if(t.Type == TaskType.tasktype.STAMINA)
        {
            playerStats.incStamina(t.result);
            //playerStats.incStamina(500);
        }

        Score = (playerStats.Stamina + playerStats.Strength) / 2;
    }

    private void updateRank(Player player, Rank rank)
    {
        if(player.Rank != rank)
            player.Rank = rank;
    }
}

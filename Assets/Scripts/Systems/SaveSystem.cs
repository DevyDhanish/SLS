using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : Systems
{

    public static SaveSystem instance {get; private set;}
    public bool EnableLoading = true;

    private string savePath;

    public override void Init()
    {
        instance = this;
        savePath = Application.persistentDataPath + "/gameData.json";
    }

    /// <summary>
    /// Checks if the player is registered by loading game data from a saved file.
    /// This method verifies if loading is enabled and whether the save file exists.
    /// If the file is found, it reads and deserializes the game data to determine
    /// if the player is registered. If the file does not exist or loading is disabled, 
    /// it returns false.
    /// </summary>
    /// <returns>True if the player is registered, otherwise false.</returns>
    public bool isPlayerRegistered()
    {
        //return false;
        if(!EnableLoading) return false;
        
        if(!File.Exists(savePath)) return false;

        string serData = File.ReadAllText(savePath);
        SaveObject so = JsonUtility.FromJson<SaveObject>(serData);
        return so.isPlayerRegistered;
        //return gameData.isRegistered;
        //EventSystem.instance.FireOnGameLoad(gameData);
    }

    public void loadGameData()
    {
        if(!EnableLoading) return;
        
        if(!File.Exists(savePath)) return;

        string serData = File.ReadAllText(savePath);
        SaveObject so = JsonUtility.FromJson<SaveObject>(serData);
        EventSystem.instance.FireOnGameLoad(so);
    }

    public void saveGameData(SaveObject data)
    {
        if(data == null) return;

        string serData = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, serData);
        EventSystem.instance.FireOnGameSaved();
    }

    public SaveObject createGameData(){

        // the things we would like to save
        // if you would like to save some thing `X` as well
        // 1 - edit the SaveObject class to include X
        // 2 - X should inherit SavableObject<`the class to save`>
        // 3 - X should implement SavableObject.getSavableObject()
        SaveObject so = new SaveObject();

        so.isPlayerRegistered = true;
        so.playerSO = PlayerSystem.instance.getSavableObject();
        so.pendingTasks = TaskSystem.instance.getSavableObject();

        return so;

    //     if(curPlayer == null) return null;

    //     GameData gsd = new GameData(); 


    //     gsd.isRegistered = true;

    //     // make a new player class, don't use the PlayerSystem.createNewPlayer cuz that's for the game. this is just a temp player object to store the info of real player
    //     gsd.player = new Player(
    //         curPlayer.Name,
    //         new Rank(
    //             curPlayer.Rank.rankTitle,
    //             curPlayer.Rank.rankThreshold
    //         ),
    //         new Stats(
    //             curPlayer.playerStats.Strength,
    //             curPlayer.playerStats.Stamina,
    //             curPlayer.playerStats.Score
    //         ),
    //         curPlayer.Category
    //     );

    //     gsd.primaryTask = pri;

    //     gsd.secondaryTask = sec;


    //     return gsd;
    }
}

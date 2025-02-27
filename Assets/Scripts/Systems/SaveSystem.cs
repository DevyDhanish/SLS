using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : Systems
{

    public static SaveSystem instance {get; private set;}

    public GameData gameData {get; private set;}

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
        if(!EnableLoading) return false;
        
        if(File.Exists(savePath))
        {
            string serData = File.ReadAllText(savePath);
            gameData = JsonUtility.FromJson<GameData>(serData);
            return gameData.isRegistered;
            //EventSystem.instance.FireOnGameLoad(gameData);
        }
        else
        {
            return false;
        }
    }

    public void loadGameData()
    {
        if(!EnableLoading) return;
        
        if(File.Exists(savePath))
        {
            string serData = File.ReadAllText(savePath);
            gameData = JsonUtility.FromJson<GameData>(serData);

            EventSystem.instance.FireOnGameLoad(gameData);
        }
        else
        {
            gameData = null;
        }
    }

    public void saveGameData(GameData data)
    {
        if(data == null) return;

        string serData = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, serData);
        EventSystem.instance.FireOnGameSaved();
    }

    public GameData createGameData(Player curPlayer, List<Task> pri, List<Task> sec){
        return new GameData{ isRegistered = true, playerInfo = curPlayer, primaryTask = pri, secondaryTask = sec};
    }
}

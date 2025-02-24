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

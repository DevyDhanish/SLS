using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : Systems
{

    public static SaveSystem instance;

    public GameData gameData;

    private string savePath;

    public override void Init()
    {
        instance = this;
        savePath = Application.persistentDataPath + "/gameData.json";
        loadGameData(); // if there is a saved file load in as soon as game starts
    }

    public void loadGameData()
    {
        if(File.Exists(savePath))
        {
            string serData = File.ReadAllText(savePath);
            gameData = JsonUtility.FromJson<GameData>(serData);
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
        return new GameData{playerInfo = curPlayer, primaryTask = pri, secondaryTask = sec};
    }
}

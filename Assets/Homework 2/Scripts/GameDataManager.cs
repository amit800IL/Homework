using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataManager : MonoBehaviour
{
    string saveFilePath;
    public GameData gameData;
    
    private void Awake()
    {
        gameData = new GameData();
        saveFilePath = Application.persistentDataPath + "/gameData.Json";
    }

    private void Start()
    {
        ReadFromJson();
    }

    public void WriteToJson()
    {
        gameData.savedScore = ScoreSaver.Score;
        gameData.savedCoins = ScoreSaver.Coins;
        gameData.savedCollisions = ScoreSaver.collisionNum;

        string JsonString = JsonUtility.ToJson(gameData);
        File.WriteAllText(saveFilePath, JsonString);

    }

    public void ReadFromJson()
    {
        if (File.Exists(saveFilePath))
        {
            string contentFromSaveFile = File.ReadAllText(saveFilePath);
            gameData = JsonUtility.FromJson<GameData>(contentFromSaveFile);

            ScoreSaver.lastCoins = gameData.savedCoins;
            ScoreSaver.lastScore = gameData.savedScore;
            ScoreSaver.lastCollisionNum = gameData.savedCollisions;
        }
    }

}

[System.Serializable]
public class GameData
{
    public int savedScore;
    public int savedCoins;
    public int savedCollisions;

}

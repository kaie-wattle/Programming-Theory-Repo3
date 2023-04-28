using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; } // ENCAPSULATION
    public string playerName;
    public string highScorePlayerName;
    public int highScore;

    private string path;
    private int score;

    private void Awake()
    {
        Debug.Log("Awake");
        if (instance != null)
        {
            LoadGameData();
            Destroy(gameObject);
            return;
        }
        instance = this;
        path = Application.persistentDataPath + "/save.json";
        DontDestroyOnLoad(gameObject);
        LoadGameData();
    }

    /// <summary>
    /// 名前設定(未指定)
    /// </summary>
    public void SetName()
    {
        playerName = "No Name";
    }

    /// <summary>
    /// 名前設定 // POLYMORPHISM
    /// </summary>
    /// <param name="name"></param>
    public void SetName(string name)
    {
        playerName = name;
    }

    /// <summary>
    /// スコア設定　ハイスコアより上なら保存する
    /// </summary>
    /// <param name="score"></param>
    public void SetScore(int score)
    {
        if(score > highScore)
        {
            highScorePlayerName = playerName;
            highScore = score;
            SaveGameData();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    public void SaveGameData()
    {
        var data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public void LoadGameData()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<SaveData>(json);
            highScorePlayerName = data.playerName;
            highScore = data.highScore;
        }
    }
}

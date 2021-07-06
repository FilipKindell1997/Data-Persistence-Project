using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MenuManager : MonoBehaviour
{

    public static MenuManager instance;

    private string playerName;
    private string bestPlayerName;
    private int bestScore;

    public TMPro.TextMeshProUGUI Title;


    // Start is called before the first frame update
    public void Awake()
    {
        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScoreAndName();

    }

    public void Start()
    {
        if (bestScore > 0)
        {
            Title.text = "Best Score : " + bestPlayerName + " : " + bestScore;
        }
        else
        {
            Title.text = "Best Score";
        }

    }

    public string GetBestPlayerName()
    {

        return bestPlayerName;

    }

    public void SetBestPlayerName(string name)
    {

        bestPlayerName = name;

    }

    public string GetPlayerName()
    {

        return playerName;

    }

    public void SetPlayerName(string name)
    {

        playerName = name;

    }

    public int GetBestScore()
    {

        return bestScore;

    }

    public void SetBestScore(int score)
    {

        bestScore = score;

    }

    [Serializable]
    public class SaveData
    {

        public string bestPlayerName;
        public int bestScore;

    }

    public void SaveBestScoreAndName()
    {

        SaveData save = new SaveData();
        save.bestPlayerName = bestPlayerName;
        save.bestScore = bestScore;

        string json = JsonUtility.ToJson(save);

        File.WriteAllText(Application.dataPath + "/bestScoreAndName.json", json);

    }

    public void LoadBestScoreAndName()
    {
        if (File.Exists(Application.dataPath + "/bestScoreAndName.json")) {

            string json = File.ReadAllText(Application.dataPath + "/bestScoreAndName.json");

            SaveData save = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = save.bestPlayerName;
            bestScore = save.bestScore;
        }
        else
        {

            bestPlayerName = "";
            bestScore = 0;

        }
    }
}

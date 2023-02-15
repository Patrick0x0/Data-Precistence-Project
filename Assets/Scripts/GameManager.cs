using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    /* public string Player; */
    public string Name;

    public string NameHighScore;
    public int ScoreGame;

    public static GameManager Instance;


    void Start()
    {
        GameManager.Instance.LoadNewScore();
    }
    private void Awake()
    {
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
   }
    public class SaveData
    {
        public int ScoreGame;
        public string NameHighScore;
    }

    public void NewScore()
    {
        SaveData data = new SaveData();
        data.ScoreGame = ScoreGame;
        data.NameHighScore = Name;
        string Json= JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath+"/savefile.json", Json);
    }

    public void LoadNewScore()
    {
        string loadPath = Application.persistentDataPath+"/savefile.json";
        if(File.Exists(loadPath))
        {
            string json = File.ReadAllText(loadPath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            ScoreGame = data.ScoreGame;
            NameHighScore = data.NameHighScore;
        }
    }

}
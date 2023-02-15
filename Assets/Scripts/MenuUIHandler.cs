using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{

    public Text BestScore;

    // Start is called before the first frame update
    void Start()
    {
        BestScore.text = $"Best Score: {GameManager.Instance.NameHighScore} : {GameManager.Instance.ScoreGame}";
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    
    public void InputName(string PlayerName)
    {
        GameManager.Instance.Name = PlayerName;
    }
        
}

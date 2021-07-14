using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScreen : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text exitText;
    private GameManager gm = GameManager.gmInstance;

    public void Start()
    {
        if(scoreText)
        {
            if (gm.currentBestScore > gm.lastBestScore)
                scoreText.text = "CONGRATULATIONS "+gm.playerName.ToUpper()+"! YOUR NEW BEST SCORE IS " + gm.currentBestScore;
            else
                scoreText.text = "Your score is " + gm.currentBestScore + ". BestScore is " + gm.lastBestScore;
        }
        exitText.enabled = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gm.UpdateLastHighScore();
            gm.StartGame();
        }
    }
}

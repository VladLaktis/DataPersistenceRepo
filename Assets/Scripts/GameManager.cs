using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR

using UnityEditor;

#endif

public class GameManager : MonoBehaviour
{
    public static GameManager gmInstance;
    public Text startScoreText;
    public int currentBestScore { get; private set; }
    public int lastBestScore { get; private set; }
    public string playerName { get; private set; }
    public string lastScorerName { get; private set; }

    // Start is called before the first frame update

    private void Awake()
    {
        if (gmInstance)
        {
            Destroy(gameObject);
            return;
        }

        gmInstance = this;
        DontDestroyOnLoad(gameObject);

        GetLastBestScore();
    }

   public void GetLastBestScore()
    {
        lastBestScore = ScoreManager.LoadBestScore();
        lastScorerName = ScoreManager.LoadScorerName();
        startScoreText.text = "Last best score: " + lastScorerName + "-" + lastBestScore;
    }

    public void OnNameEdit(Text nameText)
    {
        
        if (nameText.text.Length > 0)
        {
            playerName = nameText.text;
        }
    }

    public void GameEnded(int score)
    {
        currentBestScore = score;
        SceneManager.LoadScene(2);
    }

    public void UpdateLastHighScore()
    {
        if(lastBestScore<currentBestScore)
        {
            lastBestScore = currentBestScore;
            lastScorerName = playerName;
            ScoreManager.SaveBestScore(lastBestScore, lastScorerName);
        }
    }

    public void StartGame()
    {
        if (playerName == null)
        {
            playerName = "Player";
        }
        SceneManager.LoadScene(1);
    }

    public void ClearBestScore()
    {
        ScoreManager.DeleteSavedScore();
        GetLastBestScore();
    }

    public void QuitGame()
    {
        ScoreManager.SaveBestScore(lastBestScore, lastScorerName);
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
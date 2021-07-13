using UnityEngine;
using System.IO;

public class ScoreManager
{
    // Start is called before the first frame update
    public static int LoadBestScore()
    {
        string path = Application.persistentDataPath + "/score.json";
        if(File.Exists(path))
        {
            string scoreJson = File.ReadAllText(path);
            return JsonUtility.FromJson<Score>(scoreJson).bestScore;
        }

        return 0;
    }

    public static string LoadScorerName()
    {
        string path = Application.persistentDataPath + "/score.json";
        if (File.Exists(path))
        {
            string scoreJson = File.ReadAllText(path);
            return JsonUtility.FromJson<Score>(scoreJson).scorer;
        }

        return "None";
    }

    public static void DeleteSavedScore()
    {
        string path = Application.persistentDataPath + "/score.json";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        
        
    }

    // Update is called once per frame
    public static void SaveBestScore(int newBestScore,string newScorer)
    {
        Score score = new Score();
        score.bestScore = newBestScore;
        score.scorer = newScorer;
        string path = Application.persistentDataPath + "/score.json";
        string scoreJson = JsonUtility.ToJson(score);
        File.WriteAllText(path, scoreJson);
    }
}

[System.Serializable]
public class Score
{
    public string scorer;
    public int bestScore;
}
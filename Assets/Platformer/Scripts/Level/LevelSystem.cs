using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    static private int levelNumber;

    void Awake()
    {
        if (FindObjectOfType<LevelFinish>() != null)
            FindObjectOfType<LevelFinish>().OnFinishLevel += FinishLevel;
        else
            Debug.Log("no finish found");
    }

    void FinishLevel()
    {
        levelNumber += 1;
        SceneManager.LoadScene("Platformer" + levelNumber.ToString());
    }
}

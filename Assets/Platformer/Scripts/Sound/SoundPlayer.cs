using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SoundPlayer : MonoBehaviour
{
    public event Action OnSceneChange = delegate { };

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    void ChangedActiveScene(Scene current, Scene next)
    {
        OnSceneChange();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
            Destroy(this.gameObject);
    }



}

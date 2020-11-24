using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuswitch : MonoBehaviour
{
    static private bool isInstantiated = false;

    private void Awake()
    {
        if (!isInstantiated)
        {
            DontDestroyOnLoad(this.gameObject);
            isInstantiated = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Menu")
            Application.Quit();
        else if(Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Menu");
    }
}

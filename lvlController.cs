using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlController : MonoBehaviour
// Controller? I hardly know her?
{

    public void Lvl1()
    {
        SceneManager.LoadScene("lvl1");
    }

    public void Lvl2()
    {
        SceneManager.LoadScene("lvl2");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{

    public void LoadByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Restart()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("LastScene"));
    }

}
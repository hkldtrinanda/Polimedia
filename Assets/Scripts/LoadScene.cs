using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    public void LoadSceneWithName()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}

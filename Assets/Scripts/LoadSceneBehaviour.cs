using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneBehaviour : MonoBehaviour
{
    public static int targetID;
    public string sceneName;
    public void LoadSceneWithName()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void SetID(int id)
    {
        targetID = id;
    }
}

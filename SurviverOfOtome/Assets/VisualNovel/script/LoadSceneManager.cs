using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Load
{
    public string SceneName;
}

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] Load[] load;

    // Update is called once per frame
    public void LoadScenes()
    {
        SceneManager.LoadScene(load[0].SceneName);
    }
}

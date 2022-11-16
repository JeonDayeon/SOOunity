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
    public dialog dialogs;
    public test test;
    public int testnum;
    [SerializeField] Load[] load;
    public DataManager data;
    public static LoadSceneManager instance = null;
    private void Awake()
    {
        dialogs = FindObjectOfType<dialog>();
        test = FindObjectOfType<test>();
        data = FindObjectOfType<DataManager>();
        //if (instance == null)
        //    instance = this;
        //
        //else if (instance != this)
        //    Destroy(gameObject);
        //
        //DontDestroyOnLoad(gameObject);

    }

    private void Update()
    {
        
    }
    // Update is called once per frame
    public void LoadScenes1(int index)
    {
        data.D_LoadIndex++;
        SceneManager.LoadScene(load[index].SceneName, LoadSceneMode.Single);
    }

    public void LoadScenes2(int index)
    {
        SceneManager.LoadScene(load[index].SceneName, LoadSceneMode.Single);
    }
}

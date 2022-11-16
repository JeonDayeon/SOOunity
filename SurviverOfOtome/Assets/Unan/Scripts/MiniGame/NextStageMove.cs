using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStageMove : MonoBehaviour
{
    public List<GameObject> stage_2Act;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += LoadedsceneEvent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        for(int i = 1; i <= stage_2Act.Count; i++)
        {
            stage_2Act[i].SetActive(true);
        }
    }

}

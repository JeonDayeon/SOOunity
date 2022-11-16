using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public GameObject[] tutorialSet;
    public GameObject[] GameStage;
    public GameObject[] Arr = new GameObject [10];
    public GameObject ImageT;

    int index;
    public bool t;

    public ScoreSet scoreset;
    // Start is called before the first frame update
    void Start()
    {
        t = true;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (t && Arr[index] != null && Input.GetMouseButtonUp(0))
        {
            ImageT.SetActive(false);
            picture();
        }

        else if (t && Arr[index] == null && Input.GetMouseButtonUp(0))
        {
            Arr[index - 1].SetActive(false);
            t = false;
            scoreset.isTime = true;
        }
    }

    public void picture()
    {
        t = true;
        ImageT = Arr[index];
        ImageT.SetActive(true);
        index++;
    }

    public void Stage(int stage)
    {
        t = true;
        Arr[0] = GameStage[stage];
        if(stage == 0)
        {
            tutorial();
        }
        if(stage == 1)
        {
            picture();
        }
    }

    public void tutorial()
    {
        for (int i = 0; i < tutorialSet.Length; i++)
        {
            Arr[i + 1] = tutorialSet[i];
        }

        if(index == 0)
        {
            picture();
        }
    }
}

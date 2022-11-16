using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int D_BgmNum;
    public int D_SFXNum;
    public int D_TimeIndex;
    public int D_LoadIndex;

    public int M_Chapter;
    public static DataManager instance = null;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetImage : MonoBehaviour
{
    public GameObject[] Image;
    public GameObject Delete;
    // Start is called before the first frame update
    void Start()
    {
        Delete = Image[0];
    }

    public void GetImage(int i)
    {
        Delete.SetActive(false);
        Image[i].SetActive(true);
        Delete = Image[i];
    }
}

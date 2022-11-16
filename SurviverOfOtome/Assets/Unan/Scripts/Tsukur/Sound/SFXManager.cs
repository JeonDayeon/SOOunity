using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SFX_T
{
    public string name;
    public AudioClip clip;
};

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] public SFX_T[] SFX = null;


    private AudioSource audioSource;

    public string SfxName;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Play(int index)
    {
        audioSource.clip = SFX[index].clip;
        audioSource.Play();
    }

    public void Play(string name)
    {
        for (int i = 0; i < SFX.Length; i++)
        {
            if (name == SFX[i].name)
            {
                audioSource.clip = SFX[i].clip;
                audioSource.Play();
            }
        }
    }

    void Stop()
    {
        audioSource.Stop();
    }
}

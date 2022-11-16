using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreSet : MonoBehaviour
{
    public int Score;
    public int InputScore; //���� ���庯�� <<<---- this!!!!!!!!!!!!!!
    public Text InputScoreResult; //���� ��� ���� 
    public Text scoretext;
    public Text targetscore;
    public GameObject g_Timer;
    private Slider TimerSlider;
    public bool isTime; //���� ����� ����
    public GameObject UI_gameEndImage;
    public List<GameObject> UI_StarList;

    public GameObject yongHo;
    public bool isStart;
    public int stage;
    public StartManager TheStart;

    public DataManager data;
    public LoadSceneManager load;
    void Start()
    {
        data = FindObjectOfType<DataManager>();
        load = FindObjectOfType<LoadSceneManager>();
        isTime = false;  //�������� �̹��� ���� ���ð� ���ǰԿ�!
        isStart = true;
        TimerSlider = g_Timer.GetComponent<Slider>();
        Score = 0;

        if(data.M_Chapter == 1)
        {
            yongHo.SetActive(true);
        }
    }

    void Update()
    {
        InputScore = Score;
        if (TimerSlider.value == 0) 
        {
            isTime = false;//Ÿ�� ������? ���� ������
            UI_gameEndImage.SetActive(true);
            gameResult();

        }

        if (isTime)
        {
            scoretext.text = Score.ToString();
            TimerSlider.value -= Time.deltaTime;
        }

        if(isStart)
        {
            isStart = false;
            TheStart.Stage(data.M_Chapter);
        }
    }

    //gameResult
    void gameResult()
    {
        bool isNext = false;
        InputScoreResult.text = InputScore.ToString();
        if(InputScore >= 50)
        {
            UI_StarList[0].SetActive(true);
            UI_StarList[1].SetActive(true);
            UI_StarList[2].SetActive(true);

            if (data.M_Chapter == 0)
            {
                Debug.Log("wow");
                data.D_TimeIndex = 16;
            }
        }
        else if(InputScore >= 25 && InputScore < 50)
        {
            UI_StarList[0].SetActive(true);
            UI_StarList[1].SetActive(true);
            if(data.M_Chapter == 0)
            {
                data.D_TimeIndex = 17;
            }
        }
        else if(InputScore >= 10 && InputScore < 25)
        {
            UI_StarList[0].SetActive(true);
            if (data.M_Chapter == 0)
            {
                data.D_TimeIndex = 18;
            }
        }
        else
        {
            UI_StarList[0].SetActive(false);
            UI_StarList[1].SetActive(false);
            UI_StarList[2].SetActive(false);
            if (data.M_Chapter == 0)
            {
                data.D_TimeIndex = 18;
            }
        }
        if(data.M_Chapter == 1)
        {
            data.D_TimeIndex = 19;
        }
        isNext = true;
        if (Input.GetMouseButtonDown(0) && isNext == true)
        {
            if(data.M_Chapter == 0)
            {
                data.M_Chapter = 1;
            }
            load.LoadScenes2(0);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreSet : MonoBehaviour
{
    public int Score;
    public int InputScore; //점수 저장변수 <<<---- this!!!!!!!!!!!!!!
    public Text InputScoreResult; //점수 출력 변수 
    public Text scoretext;
    public Text targetscore;
    public GameObject g_Timer;
    private Slider TimerSlider;
    public bool isTime; //게임 멈출까 말까
    public GameObject UI_gameEndImage;
    public List<GameObject> UI_StarList;

    public bool isStart;
    public int stage;
    public StartManager TheStart;
    void Start()
    {
        isTime = false;  //스테이지 이미지 먼저 보시고 가실게요!
        isStart = true;
        stage = 1;
        TimerSlider = g_Timer.GetComponent<Slider>();
        Score = 0;
    }

    void Update()
    {
        InputScore = Score;
        if (TimerSlider.value == 0) 
        {
            isTime = false;//타임 끝났니? 게임 멈추자
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
            TheStart.Stage(stage);
        }
    }

    //gameResult
    void gameResult()
    {
        InputScoreResult.text = InputScore.ToString();
        if(InputScore >= 50)
        {
            UI_StarList[0].SetActive(true);
            UI_StarList[1].SetActive(true);
            UI_StarList[2].SetActive(true);
        }
        else if(InputScore >= 25 && InputScore < 50)
        {
            UI_StarList[0].SetActive(true);
            UI_StarList[1].SetActive(true);
        }
        else if(InputScore >= 10 && InputScore < 25)
        {
            UI_StarList[0].SetActive(true);
        }
        else
        {
            UI_StarList[0].SetActive(false);
            UI_StarList[1].SetActive(false);
            UI_StarList[2].SetActive(false);
        }
    }

}

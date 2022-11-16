using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenCreate : MonoBehaviour    
{
    public List<GameObject> Token;
    public List<GameObject> g_PositionList;
    public GameObject TokenPrefab;

    public List<Sprite> SpriteList; //화면에 표시될 토큰(분리수거될 쓰레기)

    int StartingCountPoint;

    int Count;
    int TokenPoint;
    public GameObject g_ScoreSet;
    ScoreSet scoreset;

    //이미지 바꾸기
    public ImageChange jian_ImgChange;
    public ImageChange yong_ImgChange;
    public ImageChange Vinyl_spriteChage;
    public ImageChange Can_spriteChage;
    public ImageChange Box_spriteChage;


    enum TokenColor
    {
        TrashCan, 
        GarbegeBag,
        Box
    }

    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
        TokenPoint = 1;
        scoreset = g_ScoreSet.GetComponent<ScoreSet>();
        StartTokenInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreset.isTime) //게임 시작할지 말지
        {
            TokenMove();
        }
    }

    // 토큰 생성
    public void Create()
    {
        GameObject token = Instantiate(TokenPrefab, g_PositionList[0].transform.position, Quaternion.identity);
        TokenSet tokenset = token.GetComponent<TokenSet>();
        tokenset.spriterenderer.sprite = SpriteList[(int)tokenset.TokenType];
        if (Count >= 4)
        {
            Token[Count] = token;
            Count = 0;
        }
        else
        {
            Token[Count] = token;
            Count++;
        }

        tokenset.tokenTurn = 0;
        Rigidbody2D rigid = token.GetComponent<Rigidbody2D>();
    }

    // 토큰 이동.  
    void TokenMove()
    {
        TokenSet targettoken = Token[Count].GetComponent<TokenSet>();
        if (Input.GetKeyDown(KeyCode.Space)) { 
            Scorecalculation(targettoken, 0); //Vinyl
            MoveTokenTrain(g_PositionList[6].transform);
            Create();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Scorecalculation(targettoken, 2);   //box
            MoveTokenTrain(g_PositionList[5].transform);
            Create();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Scorecalculation(targettoken, 1);   //can
            MoveTokenTrain(g_PositionList[7].transform);
            Create();
        }

    }


    //점수
    void Scorecalculation(TokenSet Token, int listcount) //토큰 번호, 
    {
        Debug.Log("Token Type : "+Token.TokenType + " || listcount : " +listcount);
        if (listcount == (int)(Token.TokenType))
        {
            //맞았을 때 토큰
            if (listcount == 0) Vinyl_spriteChage.spriteChange(0); //Vinyl
            else if (listcount == 1) Can_spriteChage.spriteChange(0); //box
            else if (listcount == 2) Box_spriteChage.spriteChange(0);//can            
            //맞을 때 스탠딩
            if(yong_ImgChange.isActiveAndEnabled) yong_ImgChange.imgChange(0);
            jian_ImgChange.imgChange(0);
           
            //스코어 업
            scoreset.Score += TokenPoint;
        }
        else
        {
            //틀렸을 때 토큰
            if (listcount == 0) Vinyl_spriteChage.spriteChange(1); //Vinyl
            else if (listcount == 1) Can_spriteChage.spriteChange(1); //box
            else if (listcount == 2) Box_spriteChage.spriteChange(1);//can
            //틀렸을 때 스탠딩
            Debug.Log(int.Parse(scoreset.targetscore.text));
            if(scoreset.Score >= (int.Parse(scoreset.targetscore.text))) //목표 점수이상일 때 틀림  
            {
                jian_ImgChange.imgChange(2);
                if (yong_ImgChange.isActiveAndEnabled) yong_ImgChange.imgChange(2);
            }
            else
            {
                jian_ImgChange.imgChange(1);
                if (yong_ImgChange.isActiveAndEnabled) yong_ImgChange.imgChange(1);
            }
            
            //스코어 0초과일 때만 업
            if (scoreset.Score > 0)
            {
                scoreset.Score -= TokenPoint;
            }
        }
    }

    void MoveTokenTrain(Transform Dir)
    {
        for (int i = 0; i < 5; i++)
        {
            TokenSet tokenset = Token[i].GetComponent<TokenSet>();
            if (tokenset.tokenTurn < 4)
            {
                tokenset.targetTr = g_PositionList[tokenset.tokenTurn + 1].transform;
            }
            else
            {
                tokenset.targetTr = Dir;
            }
            tokenset.tokenTurn++;
        }
    }
    void StartTokenInit()
    {
        for (int i = 0; i < Token.Count; i++)
        {
            Token[i].transform.position = g_PositionList[4 - i].transform.position;
            TokenSet tokenset = Token[i].GetComponent<TokenSet>();
            switch ((int)tokenset.TokenType)
            {
                case (int)TokenColor.TrashCan:
                    tokenset.spriterenderer.sprite = SpriteList[0];
                    break;
                case (int)TokenColor.GarbegeBag:
                    tokenset.spriterenderer.sprite = SpriteList[1];
                    break;
                case (int)TokenColor.Box:
                    tokenset.spriterenderer.sprite = SpriteList[2];
                    break;
            }
        }
    }
}

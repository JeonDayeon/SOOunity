using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
//Talk, Quest--------------------------------------
    public bool isTalk;

    public TalkManager talkManager;
    public QuestManager questManager;

    public GameObject DialoguePannel;
    public Image portraitImg;
    public Text DialogueText;
    public Text nameText;
    public GameObject scanObject;
    public int talkIndex;

    //Event--------------------------------------
    public GameObject[] EventDialoguePannel;
    //public Text[] EventTextArr;
    public Text EventText;
    public int DialogueIndex;
    public int Eventindex;
    public bool isEvent;
    public EventManager eventmanager;
    
    //QuestUI------------------------------------
    public Text QuestName;
    public string Qname;
    public Text[] QuestListText;
    //Object interactiron----------------------------------
    public InteractionManager interactionmanager;
    //SFXManager-------------------------------------------
    public SFXManager TheSfx;
    public int[] sfxObjectId;
    public bool isSfx;
    //image------------------------------------------------
    public GameObject eyes;
    public SetImage Setimage;
    public bool isImage;
    public GameObject card;
    public GameObject[] paper;
    void Awake()
    {
        isTalk = false;
    }

    void Start()
    {
        Event();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isEvent)
        {
            Event();
        }

        if (questManager.questId != 0)
        {
            Qname = questManager.CheckQuest();
            QuestName.text = Qname;
            for (int i = 0; i < 2; i++)
            {
                QuestListText[i].text = questManager.SendListQuest(i);
            }
        }
        else
        {
            QuestName.text = null;
        }
    }

    public void Action(GameObject scanobj)
    {
        scanObject = scanobj;
        ObjData objData = scanobj.GetComponent<ObjData>();
        if (!isEvent)
        {
            Talk(objData.id, objData.isNpc);
            questManager.SetIn(objData.id);
            DialoguePannel.SetActive(isTalk);
            portraitImg.gameObject.SetActive(isTalk);
            interactionmanager.TransObj(objData.id, isTalk);
        }
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id+ questTalkIndex, talkIndex);

        if(talkData == null)
        {
            if(paper[1].activeSelf)
            {
                paper[1].SetActive(false);
            }
            isTalk = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }
        if(id == 9000)
        {
            if(talkIndex == 1)
            {
                card.SetActive(true);
            }
            if(talkIndex == 2)
            {
                card.SetActive(false);
                paper[0].SetActive(true);
            }
            if(talkIndex == 3)
            {
                paper[0].SetActive(false);
                paper[1].SetActive(true);
            }
            if(talkIndex == 5)
            {
                paper[0].SetActive(false);
                paper[1].SetActive(true);
            }
        }
        for(int i = 0;  i < sfxObjectId.Length; i++)
        {
            if(sfxObjectId[i] == id )
            {
                if(i == 0 && talkIndex == 8)
                {
                    isSfx = true;
                }
                
                else if(i == 1 && talkIndex == 3)
                {
                    eyes.SetActive(true);
                    isSfx = true;
                }

                if(i == 1 && talkIndex == 4)
                {
                    eyes.SetActive(false);
                }
            }
        }

        if(id == 10000)
        {
            TheSfx.Play("´úÄÈ´úÄÈ");
        }
        if (isNpc)
        {
            DialogueText.text = talkData.Split(':')[0];
            
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse (talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }   

        if(isSfx)
        {
            DialogueText.text = talkData.Split(':')[0];
            TheSfx.Play(int.Parse(talkData.Split(':')[1]));
            isSfx = false;
        }
        else
        {
            DialogueText.text = talkData;

            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isTalk = true;
        talkIndex++;
    }

    public void Event()
    {
        string eventData = eventmanager.GetEvent(Eventindex);
        if (eventmanager.id < 10)
        {
            DialogueIndex = 0;
        }
        else if (eventmanager.id >= 10)
        {
            DialogueIndex = 1;
        }
        EventText = EventDialoguePannel[DialogueIndex].GetComponentInChildren<Text>();
        EventDialoguePannel[DialogueIndex].SetActive(isEvent);
        EventText.text = eventData;

        if (eventData == null)
        {
            isEvent = false;
            Eventindex = 0;
            EventDialoguePannel[DialogueIndex].SetActive(isEvent);
            return;
        }

        else
        {
            Eventindex += 1;
        }

        if (eventmanager.id == 10)
        {
            if (Eventindex == 8)
            {
                isImage = true;
                nameText.text = "Á¶Áö¾È";
            }

            if (Eventindex == 11)
            {
                TheSfx.Play("ÄçÄç");
            }
            if (Eventindex == 13)
            {
                TheSfx.Play("´úÄÈ´úÄÈ");
            }

            else
            {
                Debug.Log("");
            }
        }

        if (isImage)
        {
            EventText.text = eventData.Split(':')[0];
            Setimage.GetImage(int.Parse(eventData.Split(':')[1]));
        }
        else
        {
            DialogueText.text = eventData;

            portraitImg.color = new Color(1, 1, 1, 0);
        }


    }
}

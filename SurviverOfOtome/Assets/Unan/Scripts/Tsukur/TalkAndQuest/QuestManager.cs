using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestObject
{
    public int questid;
    public List<isQuest> quest = new List<isQuest>();
    public int questOk;
}

[System.Serializable]
public class isQuest
{
    public string Name;
    public int itemId;
    public bool isCheck;
    public bool isTrigger;
    public int Iindex;
}

[System.Serializable]
public class QuestList
{
    public int id;
    public string[] questsummary;
}
public class QuestManager : MonoBehaviour
{
    [SerializeField] QuestObject[] questobj = null;
    [SerializeField] QuestList[] questSummarylist;
    private TalkManager theTalk;
    public int scanobjId;
    public int questId;
    public int questActionIndex;
    public int questNext;
    public GameObject[] questObject;
    Dictionary<int, QuestData> questList;

    public GameManager TheGame;
    public EventManager TheEvent;
    // Start is called before the first frame update
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        TheGame = FindObjectOfType<GameManager>();
        TheEvent = FindObjectOfType<EventManager>();
        GenerateData();
    }

    private void Start()
    {
        theTalk = FindObjectOfType<TalkManager>();
        questSummarylist[0].id = 10;
        questSummarylist[0].questsummary[0] = ("목표 1: 단서 찾기. (" + questobj[0].questOk + "/" + "3)");
        questSummarylist[0].questsummary[1] = ("목표 2: 이곳에서 벗어나기.");
    }
    private void Update()
    {
    }
    public void SetIn(int id)
    {
        scanobjId = id;
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("양호실 조사", new int[] {3000, 10000}));
        questList.Add(20, new QuestData("무거", new int[] { }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if (id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        Debug.Log(questList[questId].npcId.Length + "길이");
        ControlObject();

        if (questActionIndex == questList[questId].npcId.Length)
        {
            NextQuest();
        }
        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject()
    {
        switch(questId)
        {
            case 10:
                CheckObj(scanobjId, 0);
                if(questobj[0].questOk == 3)
                {
                    TheEvent.id = 10;
                    TheGame.isEvent = true;
                    TheGame.Event();
                }
                break;

            case 20:
                break;

            case 30:
                break;
        }
    }

    public void CheckObj(int scanid, int questindex)
    {
        for (int i = 0; i < questobj[questindex].quest.Count; i++)
        {
            if (questobj[questindex].quest[i].itemId == scanid)
            {

                Debug.Log("마장");
                if (questobj[questindex].quest[i].isCheck == false)
                {
                    if ((questobj[questindex].quest[i].isTrigger == false) || (questobj[questindex].quest[i].isTrigger == true && questobj[questindex].quest[i].Iindex == questActionIndex))
                    {
                        questobj[questindex].quest[i].isCheck = true;
                        questobj[questindex].questOk += 1;
                        questSummarylist[0].questsummary[0] = ("목표 1: 단서 찾기. (" + questobj[0].questOk + "/" + "3)");
                    }                                                   
                    
                }
            }

        }
    }

    public string SendListQuest(int listindex)
    {
        string text = null;
        for (int i = 0; i < questSummarylist.Length; i++)
        {
            if (questId == questSummarylist[i].id)
            {
                text = questSummarylist[i].questsummary[listindex];
            }
            else
                Debug.Log("아무것도 아님");
        }
        return text;
    }

}

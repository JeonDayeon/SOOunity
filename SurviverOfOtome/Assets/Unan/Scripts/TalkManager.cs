using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    public string[] portraitName;

    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        //Talk Data

        talkData.Add(2000, new string[] { "����:0", "ó���Ա���:2" });
        talkData.Add(3000, new string[] { "����:2", "����:0" });

        for (int i = 0; i < portraitArr.Length; i++)
        {
            portraitData.Add(2000 + i, portraitArr[i]);
            portraitData.Add(3000 + i, portraitArr[i]);
            portraitData.Add(4000 + i, portraitArr[i]);
        }

        
        //Quest Talk Data
        talkData.Add(10 + 2000, new string[] { "����:2", "����:0", "�� �Ѽ��̾�:1", "�����ִ� ������:2" });
        talkData.Add(11 + 3000, new string[] { "�Գ�:2", "����:0", "�� �Ѽ��̾�:1", "���� �� �ִ� ������:2" });
        talkData.Add(12 + 4000, new string[] { "??����:3", "���� ������?:1", "����? �� �Ҿ���� ��:3", "����:1" });
        
        talkData.Add(20 + 7000, new string[] { "������ �̸��̳� �̰ǰ�?:1", "�������� �Ҿ���� ���̸� ã�Ҵ�." });
        talkData.Add(21 + 3000, new string[] { "��, �� ��:0" });

    }

    public string GetTalk(int id, int talkIndex)
    {
        if(talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}

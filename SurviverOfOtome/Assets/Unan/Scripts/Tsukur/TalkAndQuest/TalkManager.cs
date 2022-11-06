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
        talkData.Add(9000, new string[] { "��Ÿ������, ������, ���ö�...?" });
        talkData.Add(10 + 3000, new string[] { "ħ�� ���� ��Ź�̴�. �Ʒ��ʿ� ������ �����ִ�.", "���� �غ���", "(���̺���, ����, �޴���, ������ �׸���)", "��?",
            "�̰� ����?", "(�ƹ�ư ����ǰ���� ����ִ�.)", "(�翬�ϰԵ� �޴����� ���� Ȯ���ߴ�.)", "��.�����ֳ�.", "(���� ������ ������ Ȯ���ߴ�.)", "(�̰�.. �л����ΰ�...?)",
            "���ֺ��� �ʹ� ��ο��� �� �Ⱥ���", "�Һ��� ã�ƺ���." });
        talkData.Add(11 + 9000, new string[] { "����� �Һ����� ���� �ȿ� �ִ� ������ Ȯ���� �� �� ���� �� ����." });

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

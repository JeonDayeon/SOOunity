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



        //Quest Talk Data
        talkData.Add(1000, new string[] { "방금까지 누워있던 곳이다.", " 그외에 특별한 것은 없다." });
        talkData.Add(2000, new string[] { "내가 누워있던 침대와 동일한 종류다.", "온기는 남아있지 않은 걸 보니 나 외에 침대에 누워있던 사람은 없었던 것 같다. " });
        talkData.Add(5000, new string[] { "약품이 들어있는 건가...?" });
        talkData.Add(6000, new string[] { "불이 안 켜진다." });
        talkData.Add(7000, new string[] {  "밖은 어둡고 그믐달의 전경이 보인다.", "이 방은... 4층 정도의 높이인 거 같다. " +"\n"+
            "잔디밭의 정돈된 조경과 화원이 보인다.", "여기서 대체...", "...:1","방금...화원 쪽에서..." });
        talkData.Add(8000, new string[] { "깔끔하게 정리되어 있다. 의자에 하얀 가운이 걸쳐져 있다." });
        talkData.Add(9000, new string[] { "비타민음료, 얼음팩, 도시락...?" });
        talkData.Add(10000, new string[] { "쇠로 된 문이다. 아무리 힘을 줘봐도 열리지 않는다... 잠깐 사이에 숨이 차는 것 같아 그만뒀다." });

        talkData.Add(10 + 3000, new string[] { "침대 맡의 협탁이다. 아래쪽에 가방이 놓여있다.", "조사 해보자", "(종이봉투, 필통, 휴대폰, 지갑… 그리고…)", "…?",
            "이건 뭐지?", "(아무튼 귀중품들이 들어있다.)", "(당연하게도 휴대폰을 먼저 확인했다.)", "….꺼져있네.", "...:0","(나는 지갑을 꺼내서 확인했다.)", "(이건.. 학생증인가...?)",
            "…주변이 너무 어두워서 잘 안보여", "(불빛을 찾아보자.)" });
        talkData.Add(11 + 9000, new string[] { "냉장고 불빛으로 가방 안에 있던 물건을 확인해 볼 수 있을 것 같아.", "백진고등학교 학생증. \n 이름: 조지안, 나이: 17 이 학생증은 20xx년 xx월 xx일 부터 ….", "…", "신입생 선서문 – 신입생 대표 조지안.",
            "저희 신입생 일동은 나라를 이끄는 인재들의 전당인 \n 백진고등학교에 입학하게 된 것을 영광으로 …… ",  });

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);
            else
                return GetTalk(id - id % 10, talkIndex);
        }

        if(talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}

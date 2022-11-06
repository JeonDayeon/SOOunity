using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InteractObject
{
    public int itemId;

    public bool isOrigin; //�ؽ�Ʈ ��� ������ ���󺹱� �ؾߵǸ� true
    public bool isTransform; //Ʈ������ �� �������� �ƴ� �� Ȯ��(isOrigin == false �̸� ���� �� ������� �� ����)
    public GameObject original;
    public GameObject transform;
}
public class InteractionManager : MonoBehaviour
{
    [SerializeField] InteractObject[] interobj = null;
    public void TransObj(int scanid, bool istalk)
    {
        Debug.Log("�Լ�");
        for (int i = 0; i < interobj.Length; i++)
        {
            if (interobj[i].itemId == scanid)
            {
                if (!interobj[i].isTransform)
                {
                    Debug.Log(scanid);
                    interobj[i].original.SetActive(false);
                    interobj[i].transform.SetActive(true);
                    interobj[i].isTransform = true;
                }
            
                else if(interobj[i].isOrigin && !istalk)
                {
                    OriginObj(scanid, i);
                }
            }

        }
        
    }

    public void OriginObj(int scanid, int i)
    {        
         Debug.Log("�Լ�");
         
         interobj[i].original.SetActive(true);
         interobj[i].transform.SetActive(false);
         interobj[i].isTransform = false;                      
    }
}

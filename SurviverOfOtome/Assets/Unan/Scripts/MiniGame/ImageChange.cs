using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    Image thisImg;
    SpriteRenderer thisSprit;
    public List<Sprite> spritesList;

    void Start()
    {
        thisImg = GetComponent<Image>(); //�̹��� ��������
        thisSprit = GetComponent<SpriteRenderer>();
        //��������Ʈ ����
        //�̹��� �¾�Ƽ��(Ȱ��ȭ ��Ȱ��ȭ)
    }

    public void imgChange(int count)
    {
        if (count == 0) {
            thisImg.sprite = spritesList[0]; }
        else if (count == 1) thisImg.sprite = spritesList[1];
        else if (count == 2) thisImg.sprite = spritesList[2];
        //Img_Renderer.sprite = spritesList[0];
    }

    public void spriteChange(int count)
    {
        if (count == 0) thisSprit.sprite = spritesList[0];
        else if (count == 1) thisSprit.sprite = spritesList[1]; 
    }
    


}

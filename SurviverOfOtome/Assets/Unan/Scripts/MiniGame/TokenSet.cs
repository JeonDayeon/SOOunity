using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSet : MonoBehaviour
{
    public Transform targetTr;
    public int tokenTurn;
    public int Speed;
    public Vector3 pos;
    public SpriteRenderer spriterenderer;

    public enum TokenColor
    {
        TrashCan, 
        GarbegeBag,
        Box
    }

    public TokenColor TokenType;
    private void Awake()
    {
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        targetTr = gameObject.transform;
        Speed = 100;
        TokenInit();
    }
    public void TokenInit()
    {
        TokenType = (TokenColor)Random.Range(0, 3);
    }

    private void Update()
    {
        pos = targetTr.position;
        if (transform.position != targetTr.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTr.position, Speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BorderToken")
        {
            //DestroyImmediate
            Debug.Log("DESTROY!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Destroy(gameObject);
        }
    }
}

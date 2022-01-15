using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tile : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Flag;
    Transform tileTransform;

    public bool isFlag = false;
    public bool isOpen = false;
    public bool isBomb = false;
    public int flagCount;    //주변 지뢰 개수

    private void Awake()
    {
        tileTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        //현재 타일과 플레이어간의 거리가 1.5이하일 때 isOpen을 참으로 설정
        if(!isOpen&& !isBomb)
        {
            float player2TileDist = Vector3.Distance(gameManager.player.transform.position, tileTransform.position);
            if (player2TileDist < 1.5f)
                isOpen = true;
        }
    }

    public void SetFlag()
    {
        if (!isOpen)
        {//isFlag가 false일때 true로 바꾸고 깃발 오브젝트를 활성화시킴 
            if (!this.isFlag)
            {
                isFlag = true;
                Flag.SetActive(true);
            }

            //isFlag가 true일때 false로 바꾸고 깃발 오브젝트를 비활성화시킴 
            else
            {
                isFlag = false;
                Flag.SetActive(false);
            }
        }
        else 
        { 
            //이미 열려진 타일은 깃발을 생성할 수 없습니다.
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        //폭탄이 있는 타일 && 패배하지 않은 상황 && 플레이어가 움직임을 끝냈을 때 --> 폭탄 생성, 패배
        if(this.isBomb && !gameManager.isDefeated && !gameManager.playerIsMove)
            if (col.gameObject.CompareTag("Player"))
            {
                //폭탄 낙하
                gameManager.SetBomb();
                gameManager.isDefeated = true;
            }

        if(gameManager.isDefeated)
        {
            gameManager.BombIsFalled();
        }
    }
}

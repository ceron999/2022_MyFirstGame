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
    public int flagCount;    //�ֺ� ���� ����

    private void Awake()
    {
        tileTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        //���� Ÿ�ϰ� �÷��̾�� �Ÿ��� 1.5������ �� isOpen�� ������ ����
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
        {//isFlag�� false�϶� true�� �ٲٰ� ��� ������Ʈ�� Ȱ��ȭ��Ŵ 
            if (!this.isFlag)
            {
                isFlag = true;
                Flag.SetActive(true);
            }

            //isFlag�� true�϶� false�� �ٲٰ� ��� ������Ʈ�� ��Ȱ��ȭ��Ŵ 
            else
            {
                isFlag = false;
                Flag.SetActive(false);
            }
        }
        else 
        { 
            //�̹� ������ Ÿ���� ����� ������ �� �����ϴ�.
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        //��ź�� �ִ� Ÿ�� && �й����� ���� ��Ȳ && �÷��̾ �������� ������ �� --> ��ź ����, �й�
        if(this.isBomb && !gameManager.isDefeated && !gameManager.playerIsMove)
            if (col.gameObject.CompareTag("Player"))
            {
                //��ź ����
                gameManager.SetBomb();
                gameManager.isDefeated = true;
            }

        if(gameManager.isDefeated)
        {
            gameManager.BombIsFalled();
        }
    }
}

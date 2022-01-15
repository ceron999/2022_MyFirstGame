using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameManager gameManager;
    
    //��ǥ ������ ������ ��� �� ĭ �� ���� �̵��Ͽ� ���� ����ϴ�.
    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            gameManager.isVictory = true;

            gameManager.destination = new Vector3(3.5f, 3.5f, 0f);
            gameManager.PlayerMove();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameManager gameManager;
    
    //목표 지점에 도착할 경우 한 칸 더 위로 이동하여 몸을 감춥니다.
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

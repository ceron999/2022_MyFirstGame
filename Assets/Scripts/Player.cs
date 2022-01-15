using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    Animator playerAnim;
    Transform playerTransform;
    Vector3 playerScale;

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Sit"))
        {
            if (playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
            {
                playerAnim.SetBool("isSit", false);
                gameManager.playerIsSit = false;
            }
        }
    }

    public void PlayerMoveAnim()
    {
        if (gameManager.playerIsMove)
            playerAnim.SetBool("isMove", true);
        if(gameManager.playerIsMove == false)
            playerAnim.SetBool("isMove", false);
    }

    public void PlayeSitAnim()
    {
        if (gameManager.playerIsSit)
            playerAnim.SetBool("isSit", true);

        
    }

    //플레이어 좌우반전 하는 함수
    public void PlayerTransformChange(Vector3 getDir)
    {
        playerScale = transform.localScale;

        if (getDir.y == 0)
        {
            if (getDir.x > 0)
            {
                playerScale.x = -1;
                transform.localScale = playerScale;
            }
            else
            {
                playerScale.x = 1;
                transform.localScale = playerScale;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject prefab;
    public GameObject player;
    public GameObject Bomb;
    public GameObject _Bomb;    //������ Ŭ�� ��ź

    public Tile getTileScript;
    Player playerPrefab;

    Vector3 getColPos;      //Ŭ���� ������ �ݶ��̴� �߽� ��ġ
    Vector3 dir;            //player�� �����̴� ����
    public Vector3 destination;    //player�� �����ؾ��ϴ� ����

    public bool playerIsMove = false;
    public bool playerIsSit = false;

    //UI���� ������
    public bool isUIOpen = false;
    public int gameStage;
    public float time = 3f;
    public int bombCount;

    //���� ����
    public bool isVictory = false;
    public bool isDefeated = false;

    //���� �������� ���� ������
    public bool isGameStart = false;
    public bool isNextStage = false;

    void Awake()
    {
        gameManager = this;
        playerPrefab = prefab.GetComponent<Player>();
    }

    private void Update()
    {
        if (isGameStart&& !isUIOpen)
        {
            if (!isVictory && !isDefeated)
                Action();

            if (playerIsMove)
            {
                //�̵� ��� ����
                playerPrefab.PlayerMoveAnim();
                PlayerMove();
            }
            else
            {
                playerPrefab.PlayerMoveAnim();
            }
        }
    }

    void Action()
    {
        //��Ŭ���� ��ü�� Ÿ���� ��
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider.tag == "Tile" || hit.collider.tag == "Goal")
            {
                //Ŭ���� ������ �浹ü �߽��� getColPos�� ���� �ֽ��ϴ�.
                getColPos = new Vector3( hit.collider.transform.position.x,
                                                 hit.collider.transform.position.y, 
                                                 hit.collider.transform.position.z);

                //@@@@��������@@@@
                //Ŭ���� Ÿ���� ��ũ��Ʈ�� ������ �ش� Ÿ����bombCount�� 0 �ʰ��� ��� �������� �ʽ��ϴ�.
                getTileScript = hit.collider.GetComponent<Tile>();

                if (hit.collider.tag == "Goal" || getTileScript.flagCount < 1)
                {
                    //������ ������ �����ϰ� �������� ����, isMove�� ������ �����մϴ�.
                    if (!playerIsMove)
                    {
                        dir = MoveDir(getColPos);
                        destination = player.transform.position + dir.normalized;

                        //�÷��̾� �¿� ��ȯ
                        playerPrefab.PlayerTransformChange(dir);
                    }
                    playerIsMove = true;
                }
            }
        }
        //��Ŭ���� ��ü�� Ÿ���� ��
        else if(Input.GetMouseButtonDown(1))
        {
            //�ɴ� ��� �ϱ�
            if (!playerIsSit)
            {
                playerIsSit = true;
                playerPrefab.PlayeSitAnim();
            }

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider.tag == "Tile")
            {
                getTileScript = hit.collider.GetComponent<Tile>();
                getTileScript.SetFlag();
            }
        }
    }

    public void PlayerMove()
    { 
        //���� ����- �����¿� 1ĭ�� �̵��ϵ��� �ذ�
        player.transform.position = Vector3.MoveTowards(player.transform.position, destination, 0.01f);
        if (Vector3.Distance(player.transform.position, destination) < 0.001f)
        {
            playerIsMove = false;
        }
    }

    public Vector3 MoveDir(Vector3 getColPos)
    {
        Vector3 dir = getColPos - player.transform.position;
        float PosX = Mathf.Abs(dir.x);
        float PosY = Mathf.Abs(dir.y);

        if (PosX > PosY)
        {
            dir.y = 0f;
            dir.z = 0f;
            return dir;
        }
        else if (PosX < PosY)
        {
            dir.x = 0f;
            dir.z = 0f;
            return dir;
        }
        else
        {
            dir.x = 0f;
            dir.y = 0f;
            dir.z = 0f;
            //UI�� ���� �̵� �Ұ��� �˸�
            return dir;
        }
    }

    //��ź ������Ʈ ����
    public void SetBomb()
    {
        Transform bombTransform = player.transform;
        _Bomb = Instantiate(Bomb, bombTransform) as GameObject;
    }

    //��ź ������Ʈ �̵�
    public void BombIsFalled()
    {
        _Bomb.transform.position = Vector3.MoveTowards(_Bomb.transform.position, player.transform.position, 0.1f);
    }

    //���������� ���� ��ź�� ������ �ٲߴϴ�.
    void SetBombCount()
    {
        isNextStage = true;
        if (gameStage == 1)
        {
            bombCount = 1;
        }

        else if(gameStage ==2)
        {
            bombCount = 1;
        }

        else if (gameStage == 3)
        {
            bombCount = 1;
        }

        else if (gameStage == 4)
        {
            bombCount = 1;
        }
    }
}

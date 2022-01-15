using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject prefab;
    public GameObject player;
    public GameObject Bomb;
    public GameObject _Bomb;    //생성한 클론 폭탄

    public Tile getTileScript;
    Player playerPrefab;

    Vector3 getColPos;      //클릭한 지점의 콜라이더 중심 위치
    Vector3 dir;            //player가 움직이는 방향
    public Vector3 destination;    //player가 도착해야하는 지점

    public bool playerIsMove = false;
    public bool playerIsSit = false;

    //UI관련 변수들
    public bool isUIOpen = false;
    public int gameStage;
    public float time = 3f;
    public int bombCount;

    //게임 승패
    public bool isVictory = false;
    public bool isDefeated = false;

    //게임 스테이지 관련 변수들
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
                //이동 모션 시작
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
        //좌클릭한 객체가 타일일 때
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider.tag == "Tile" || hit.collider.tag == "Goal")
            {
                //클릭한 지점의 충돌체 중심을 getColPos에 집어 넣습니다.
                getColPos = new Vector3( hit.collider.transform.position.x,
                                                 hit.collider.transform.position.y, 
                                                 hit.collider.transform.position.z);

                //@@@@수정사항@@@@
                //클릭한 타일의 스크립트를 가져와 해당 타일의bombCount가 0 초과일 경우 움직이지 않습니다.
                getTileScript = hit.collider.GetComponent<Tile>();

                if (hit.collider.tag == "Goal" || getTileScript.flagCount < 1)
                {
                    //움직일 방향을 지정하고 목적지를 설정, isMove를 참으로 설정합니다.
                    if (!playerIsMove)
                    {
                        dir = MoveDir(getColPos);
                        destination = player.transform.position + dir.normalized;

                        //플레이어 좌우 변환
                        playerPrefab.PlayerTransformChange(dir);
                    }
                    playerIsMove = true;
                }
            }
        }
        //우클릭한 객체가 타일일 때
        else if(Input.GetMouseButtonDown(1))
        {
            //앉는 모션 하기
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
        //수정 사항- 상하좌우 1칸만 이동하도록 해결
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
            //UI를 통해 이동 불가를 알림
            return dir;
        }
    }

    //폭탄 오브젝트 생성
    public void SetBomb()
    {
        Transform bombTransform = player.transform;
        _Bomb = Instantiate(Bomb, bombTransform) as GameObject;
    }

    //폭탄 오브젝트 이동
    public void BombIsFalled()
    {
        _Bomb.transform.position = Vector3.MoveTowards(_Bomb.transform.position, player.transform.position, 0.1f);
    }

    //스테이지에 따라 폭탄의 개수를 바꿉니다.
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

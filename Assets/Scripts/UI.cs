using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject canvas;
    public GameObject gameSet;
    public GameObject cancelBTN;
    public GameObject nextStageBTN;
    public GameObject ExitBTN;
    public GameObject RetryBTN;
    public GameObject gameStartBTN;
    public GameObject backMainMenu;

    public Text gameSetText;
    public Text countTimerText;
    public Text BombCountText;

    //BTN 클론을 저장하기 위한 임시 오브젝트
    GameObject BTNClone;

    private void Awake()
    {
        //타이머 시간 설정
        countTimerText.text = gameManager.time.ToString();

        InstantiateBTN(gameStartBTN);
    }

    private void Update()
    {
        if(gameManager.isGameStart && !gameManager.isUIOpen)
        {        
            //상단의 타이머를 설정하고 출력합니다.
            if (gameManager.time > 0)
                gameManager.time -= Time.deltaTime;
            else if (gameManager.time <= 0)
            {
                Time.timeScale = 0.0f;
                gameManager.isDefeated = true;
            }

            countTimerText.text = Mathf.Round(gameManager.time).ToString();

            //게임 승리 및 종료시 화면에 UI를 출력합니다.
            if (gameManager.isDefeated || gameManager.isVictory)
                GameSet();

            //esc키를 누를 경우 메인 메뉴로 이동할 수 있는 UI를 엽니다.
            BackMainManuUI();
        }
    }

    void GameSet()
    {
        if(gameManager.isDefeated)
        {
            gameManager.isDefeated = true;
            gameSet.SetActive(true);
            gameSetText.text = "Defeated!";
            ExitBTN.SetActive(true);
            RetryBTN.SetActive(true);
        }

        else if(gameManager.isVictory)
        {
            gameSet.SetActive(true);
            gameSetText.text = "Victory!";
            cancelBTN.SetActive(true);
            nextStageBTN.SetActive(true);
        }

        gameManager.isGameStart = false;
    }

    //버튼 인스턴트를 생성합니다.
    void InstantiateBTN(GameObject BTN)
    {
        //초기 게임 시작 버튼 활성화
        BTNClone = Instantiate<GameObject>(BTN);
        BTNClone.transform.parent = canvas.transform;
        BTNClone.SetActive(true);

        if(BTN == gameStartBTN)
            BTNClone.transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    void BackMainManuUI()
    {
        //esc키를 누를 경우 메인 메뉴로 이동할 수 있는 UI를 엽니다.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.isUIOpen = true;
            backMainMenu.SetActive(true);
            gameManager.isGameStart = false;
        }

    }
}

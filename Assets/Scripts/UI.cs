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

    //BTN Ŭ���� �����ϱ� ���� �ӽ� ������Ʈ
    GameObject BTNClone;

    private void Awake()
    {
        //Ÿ�̸� �ð� ����
        countTimerText.text = gameManager.time.ToString();

        InstantiateBTN(gameStartBTN);
    }

    private void Update()
    {
        if(gameManager.isGameStart && !gameManager.isUIOpen)
        {        
            //����� Ÿ�̸Ӹ� �����ϰ� ����մϴ�.
            if (gameManager.time > 0)
                gameManager.time -= Time.deltaTime;
            else if (gameManager.time <= 0)
            {
                Time.timeScale = 0.0f;
                gameManager.isDefeated = true;
            }

            countTimerText.text = Mathf.Round(gameManager.time).ToString();

            //���� �¸� �� ����� ȭ�鿡 UI�� ����մϴ�.
            if (gameManager.isDefeated || gameManager.isVictory)
                GameSet();

            //escŰ�� ���� ��� ���� �޴��� �̵��� �� �ִ� UI�� ���ϴ�.
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

    //��ư �ν���Ʈ�� �����մϴ�.
    void InstantiateBTN(GameObject BTN)
    {
        //�ʱ� ���� ���� ��ư Ȱ��ȭ
        BTNClone = Instantiate<GameObject>(BTN);
        BTNClone.transform.parent = canvas.transform;
        BTNClone.SetActive(true);

        if(BTN == gameStartBTN)
            BTNClone.transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    void BackMainManuUI()
    {
        //escŰ�� ���� ��� ���� �޴��� �̵��� �� �ִ� UI�� ���ϴ�.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.isUIOpen = true;
            backMainMenu.SetActive(true);
            gameManager.isGameStart = false;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BTNScript : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject myObj;

    public GameObject gameSet;
    public GameObject backMainMenu;
    public GameObject RuleUI;

    //게임 시작 버튼과 관련된 함수입니다.
    public void GameStartBTN_Click()
    {
        gameManager.isGameStart = true;
        Destroy(myObj);
    }

    //BackMainMenu의 yesBTN을 누를 경우
    public void YesBTN_Click()
    {
        //메인 화면으로 이동
        SceneManager.LoadScene("MainMenu");
    }

    //BackMainMenu의 NoBTN을 누를 경우
    public void NoBTN_Click()
    {
        //UI 화면을 끄고 기존 게임 창으로 이동
        gameManager.isGameStart = true;
        gameManager.isUIOpen = false;
        backMainMenu.SetActive(false);
    }

    //GameSet UI의 NextStageBTN을 누를 경우 Stage1 이동
    public void NextStage1BTN_Click()
    {
        //Stage1 스테이지로 이동
        SceneManager.LoadScene("Stage1");
    }


    //GameSet UI의 NextStageBTN을 누를 경우 Stage2 이동
    public void NextStage2BTN_Click()
    {
        //Stage2 스테이지로 이동
        SceneManager.LoadScene("Stage2");
    }

    //GameSet UI의 NextStageBTN을 누를 경우 Stage3 이동
    public void NextStage3BTN_Click()
    {
        //Stage3 스테이지로 이동
        SceneManager.LoadScene("Stage3");
    }

    //GameSet UI의 CancelBTN을 누를 경우
    public void CancelBTN_Click()
    {
        //BackMainMenu 화면으로 이동하며 GameSet UI를 종료
        gameSet.SetActive(false);
        backMainMenu.SetActive(true);
    }

    //GameSet UI의 ExitBTN을 누를 경우
    public void ExitBTN_Click()
    {
        //메인 메뉴로 이동
        SceneManager.LoadScene("MainMenu");
    }

    public void RetryTutorialBTN_Click()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void RetryStage1BTN_Click()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void RetryStage2BTN_Click()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void RetryStage3BTN_Click()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void RetryEndingSceneBTN_Click()
    {
        SceneManager.LoadScene("Ending");
    }

    public void RuleBTN_Click()
    {
        gameManager.isUIOpen = true;
        RuleUI.SetActive(true);
    }

    public void RuleExitBTN()
    {
        RuleUI.SetActive(false);
        gameManager.isUIOpen = false;
    }

    //Main Menu Scene
    public void NewGameStartBTN_Click()
    {
        //새 게임 시작
        SceneManager.LoadScene("Tutorial");
    }

    public void ChapterBTN_Click()
    {
        //챕터 페이지로 이동
        SceneManager.LoadScene("Chapter");
    }

    public void GameExitBTN_Click()
    {
        //게임 종료
        Application.Quit();
    }
}

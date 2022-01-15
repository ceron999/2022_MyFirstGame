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

    //���� ���� ��ư�� ���õ� �Լ��Դϴ�.
    public void GameStartBTN_Click()
    {
        gameManager.isGameStart = true;
        Destroy(myObj);
    }

    //BackMainMenu�� yesBTN�� ���� ���
    public void YesBTN_Click()
    {
        //���� ȭ������ �̵�
        SceneManager.LoadScene("MainMenu");
    }

    //BackMainMenu�� NoBTN�� ���� ���
    public void NoBTN_Click()
    {
        //UI ȭ���� ���� ���� ���� â���� �̵�
        gameManager.isGameStart = true;
        gameManager.isUIOpen = false;
        backMainMenu.SetActive(false);
    }

    //GameSet UI�� NextStageBTN�� ���� ��� Stage1 �̵�
    public void NextStage1BTN_Click()
    {
        //Stage1 ���������� �̵�
        SceneManager.LoadScene("Stage1");
    }


    //GameSet UI�� NextStageBTN�� ���� ��� Stage2 �̵�
    public void NextStage2BTN_Click()
    {
        //Stage2 ���������� �̵�
        SceneManager.LoadScene("Stage2");
    }

    //GameSet UI�� NextStageBTN�� ���� ��� Stage3 �̵�
    public void NextStage3BTN_Click()
    {
        //Stage3 ���������� �̵�
        SceneManager.LoadScene("Stage3");
    }

    //GameSet UI�� CancelBTN�� ���� ���
    public void CancelBTN_Click()
    {
        //BackMainMenu ȭ������ �̵��ϸ� GameSet UI�� ����
        gameSet.SetActive(false);
        backMainMenu.SetActive(true);
    }

    //GameSet UI�� ExitBTN�� ���� ���
    public void ExitBTN_Click()
    {
        //���� �޴��� �̵�
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
        //�� ���� ����
        SceneManager.LoadScene("Tutorial");
    }

    public void ChapterBTN_Click()
    {
        //é�� �������� �̵�
        SceneManager.LoadScene("Chapter");
    }

    public void GameExitBTN_Click()
    {
        //���� ����
        Application.Quit();
    }
}

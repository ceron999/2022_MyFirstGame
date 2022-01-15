using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stroy_Script : MonoBehaviour
{
    public Text storyText;

    //�ش� ���� � �������� �����ִ� �����Դϴ�.
    public bool isHistory;
    public bool isDiary;
    public bool isSuicideNote;
    public bool isEnding;

    //�� ���� �´� ��ũ��Ʈ�� ������ string �迭�Դϴ�.
    public List<string> story_History = new List<string>();
    public List<string> story_Diary = new List<string>();
    public List<string> story_SuicideNote = new List<string>();
    public List<string> story_Ending = new List<string>();

    //�� ��ũ��Ʈ�� ���� ��Ÿ���� �����Դϴ�.
    int HistorySctiptAmount;
    int DiarySctiptAmount;
    int SuicideNoteSctiptAmount;
    int EndingSctiptAmount;

    private void Awake()
    {
        storyText = storyText.GetComponent<Text>();

        //��ũ��Ʈ �޾ƿ���
        if (isHistory)
        {
            HistoryScript();
        }
        else if (isDiary)
            DiaryScript();
        else if (isSuicideNote)
            SuicideNoteScript();
        else if (isEnding)
            EndingScript();
        else
            Debug.Log("����");

        //�� ���� ù ��縦 ����մϴ�.
        if (isHistory)
            storyText.text = story_History[0];
        else if (isDiary)
            storyText.text = story_Diary[0];
        else if (isSuicideNote)
            storyText.text = story_SuicideNote[0];
        else if (isEnding)
            storyText.text = story_Ending[0];
        else
            Debug.Log("����");
    }

    void Update()
    {
        
    }

    //story_History Script
    void HistoryScript()
    {
        story_History.Add("xxxx�� x�� x��");
    }


    //story_Diary Script
    void DiaryScript()
    {
        story_Diary.Add("2");
    }


    //story_SuicideNote Script
    void SuicideNoteScript()
    {
        story_SuicideNote.Add("3");
    }

    //story_Ending Script
    void EndingScript()
    {
        story_Ending.Add("4");
    }
}

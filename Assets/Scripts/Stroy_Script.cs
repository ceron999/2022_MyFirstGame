using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stroy_Script : MonoBehaviour
{
    public Text storyText;

    //해당 씬이 어떤 씬인지를 말해주는 변수입니다.
    public bool isHistory;
    public bool isDiary;
    public bool isSuicideNote;
    public bool isEnding;

    //각 씬에 맞는 스크립트를 저장한 string 배열입니다.
    public List<string> story_History = new List<string>();
    public List<string> story_Diary = new List<string>();
    public List<string> story_SuicideNote = new List<string>();
    public List<string> story_Ending = new List<string>();

    //각 스크립트의 양을 나타내는 변수입니다.
    int HistorySctiptAmount;
    int DiarySctiptAmount;
    int SuicideNoteSctiptAmount;
    int EndingSctiptAmount;

    private void Awake()
    {
        storyText = storyText.GetComponent<Text>();

        //스크립트 받아오기
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
            Debug.Log("뻐그");

        //각 씬별 첫 대사를 출력합니다.
        if (isHistory)
            storyText.text = story_History[0];
        else if (isDiary)
            storyText.text = story_Diary[0];
        else if (isSuicideNote)
            storyText.text = story_SuicideNote[0];
        else if (isEnding)
            storyText.text = story_Ending[0];
        else
            Debug.Log("뻐그");
    }

    void Update()
    {
        
    }

    //story_History Script
    void HistoryScript()
    {
        story_History.Add("xxxx년 x월 x일");
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

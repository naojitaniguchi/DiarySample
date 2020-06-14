using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryData : MonoBehaviour
{
    public int currentPage = 0;
    List<string> diaryList;
    InputField input;
    public GameObject pageNumObject;

    // Start is called before the first frame update
    void Start()
    {

        // diaryList = new List<string>();
        // PlayerPrefからロード
        diaryList = PlayerPrefsUtility.LoadList<string>("DiaryData");

        input = gameObject.GetComponent<InputField>();
        if ( diaryList.Count > 0)
        {
            input.text = diaryList[0];
        }

        setPageNum();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStringToCurrentPage()
    {
        if (currentPage < diaryList.Count - 1)
        {
            diaryList[currentPage] = input.text ;
        }
        else
        {
            diaryList.Add(input.text);
        }
    }

    public void SaveToPlayerPrefs()
    {
        PlayerPrefsUtility.SaveList<string>("DiaryData", diaryList);
    }

    public void setPageNum()
    {
        pageNumObject.GetComponent<Text>().text = currentPage.ToString() + " page";

    }

    public void Clear()
    {
        currentPage = 0;
        diaryList.Clear();
        input.text = "";
        PlayerPrefs.DeleteKey("DiaryData");
    }

    public void ShowNext()
    {
        SetStringToCurrentPage();
        currentPage++;
        input.text = "";
        if ( currentPage < diaryList.Count - 1)
        {
            input.text = diaryList[currentPage];
        }
        setPageNum();
    }
    public void ShowPrev()
    {
        SetStringToCurrentPage();
        currentPage--;
        if ( currentPage < 0)
        {
            currentPage = 0;
        }
        input.text = "";
        if (currentPage < diaryList.Count - 1)
        {
            input.text = diaryList[currentPage];
        }
        setPageNum();
    }
}

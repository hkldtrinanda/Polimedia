using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{    // Start is called before the first frame update
    [Header("Quest Component")]

    public int currentQuestID;
    public static QuestManager instance;
    private int questProgressCounter;

    [Header("Quest Component")]
    public TMP_Text UIQuestTitle;
    public TMP_Text UIQuestDetail;

    public Quest[] quests;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        
    }
    public void InitiateQuest(int id)
    {
        //if(currentQuestID != PlayerPrefs.GetInt("activeQuestID"))
        //{
        //   quests[PlayerPrefs.GetInt("activeQuestID")].questObject.SetActive(false);

       // }
        
        currentQuestID = id;
        if(quests[currentQuestID].isComplete == false)
        {
            PlayerPrefs.SetInt("activeQuestID", currentQuestID);
            quests[PlayerPrefs.GetInt("activeQuestID")].questObject.SetActive(true);
            UIQuestTitle.text = quests[currentQuestID].questName;
            UIQuestDetail.text = quests[currentQuestID].questType + " " + questProgressCounter.ToString() + "/" + quests[currentQuestID].questProgressCount;
        }
    }

    public void ProgressQuest()
    {
        
questProgressCounter++;
UIQuestDetail.text = quests[currentQuestID].questType + " " + questProgressCounter.ToString() + "/" + quests[currentQuestID].questProgressCount;
        if (questProgressCounter == quests[currentQuestID].questProgressCount)
        {
            Debug.Log("Quest Complete!");
            quests[currentQuestID].isComplete = true;
            UIQuestTitle.text = quests[currentQuestID].questName;
            UIQuestDetail.text = "SELESAI";

        }
    }

    public void ResetQuest()
    {
        UIQuestTitle.text = "No Quest";
        UIQuestTitle.text = "No Quest Details";
    }
}


[System.Serializable]
public class Quest
{
    public int id;
    public bool isComplete;
    public string questName;
    public string questType;
    public GameObject questObject;
    public int questProgressCount;

    public Quest(int id, string questName, string questType, GameObject questObject, int questProgressCount, bool isComplete)
    {
        this.id = id;
        this.questName = questName;
        this.questType = questType;
        this.questObject = questObject;
        this.questProgressCount = questProgressCount;
        this.isComplete = isComplete;

    }
}

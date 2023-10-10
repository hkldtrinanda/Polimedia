using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public GameObject questObject;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
         
            QuestManager.instance.ProgressQuest();
            Destroy(gameObject);
        }
    }
    
    public void OnClick()
    {
        QuestManager.instance.ProgressQuest();
        Destroy(gameObject);
        Destroy(questObject);
    }
    
    public void WrongClick()
    {
        Debug.Log("Wrong Click");
    }
}

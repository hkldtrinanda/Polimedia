using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
         
            QuestManager.instance.ProgressQuest();
            Destroy(gameObject);
        }
    }
}

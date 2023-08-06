    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class NPC : MonoBehaviour
    {
        public TriggerNPC trigger;
        [Header("Quest NPC")]
        public bool isQuestNPC;
        public int questID;
        public TriggerNPC questTriggerBefore;
        public TriggerNPC questTriggerAfter;


    private void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == "Player")
        {
            trigger.StartDialogue();


            if (isQuestNPC == true && QuestManager.instance.quests[questID].isComplete == false)
            {
                QuestManager.instance.InitiateQuest(questID);
                questTriggerBefore.StartDialogue();
            }
            else if(isQuestNPC == true && QuestManager.instance.quests[questID].isComplete == true)
            {
                questTriggerAfter.StartDialogue();
                QuestManager.instance.ResetQuest();
                isQuestNPC = false;
            }
            Debug.Log("Dialogue Started");
        }
               
        }

        private void OnTriggerExit(Collider collision)
        {
            /*if (collision.gameObject.CompareTag("Player") == false)
                /*trigger.StartDialogue();#1#*/
        }
    }

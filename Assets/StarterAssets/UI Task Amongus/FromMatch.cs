using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using Sirenix.OdinInspector;

public class FromMatch : MonoBehaviour
{
    public ToMatch toMatch;
    public Matchup matchup;
    public UILine fromLine;
    public ToMatch currentMatch;

    public EventTrigger eventTrigger;
    [ReadOnly] public bool rightAnswer = false;

    private void Start()
    {
        eventTrigger = GetComponent<EventTrigger>();

        eventTrigger.triggers[0].callback.AddListener(OnBeginDrag);
        eventTrigger.triggers[1].callback.AddListener(OnDrag);
        eventTrigger.triggers[2].callback.AddListener(OnEndDrag);
    }

    public void OnBeginDrag(BaseEventData p)
    {
        matchup.OnStartControllingLine(this);
    }

    public void OnDrag(BaseEventData p)
    {
        matchup.OnControllingLineFrom(this);
    }

    public void OnEndDrag(BaseEventData p)
    {
        matchup.OnReleaseLineFrom(this);
    }
}

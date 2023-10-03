using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Matchup : MonoBehaviour
{
    [DisableInPlayMode] public List<FromMatch> fromMatchs;
    [DisableInPlayMode] public List<ToMatch> toMatchs;
    public UILine controlledLine;

    [Header("Debug")]
    [SerializeField, ReadOnly] private FromMatch currentFrom;
    [SerializeField, ReadOnly] private ToMatch currentTo;

    private void Start()
    {
    }

    public void OnStartControllingLine(FromMatch from)
    {
        controlledLine.pointA.position = from.transform.position;
        controlledLine.pointB.position = Input.mousePosition;
        currentFrom = from;
    }

    public void OnControllingLineFrom(FromMatch from)
    {
        controlledLine.pointB.position = Input.mousePosition;

        if (currentTo)
        {
            controlledLine.pointB.position = currentTo.transform.position;
            return;
        }
        foreach (ToMatch to in toMatchs)
        {
            if (Vector2.Distance(Input.mousePosition, to.transform.position) < 100.0f)
            {
                currentTo = to;
                controlledLine.pointB.position = to.transform.position;
                return;
            }
        }
    }

    public void OnReleaseLineFrom(FromMatch from)
    {
        if (currentTo)
        {
            from.currentMatch = currentTo;
            currentTo.selected = true;
            from.fromLine.pointB.position = currentTo.transform.position;

            from.rightAnswer = from.currentMatch == from.toMatch;
        }

        currentFrom = null;
        currentTo = null;

        controlledLine.pointA.position = Vector3.zero;
        controlledLine.pointB.position = Vector3.zero;
    }

    [System.Serializable]
    public struct CheckData
    {
        public int rightCount;
        public int wrongCount;
        public Matchup matchup;
    }
    [Button]
    public CheckData CheckMatch()
    {
        CheckData data = new CheckData();
        data.matchup = this;
        foreach (FromMatch from in fromMatchs)
        {
            if (from.currentMatch == from.toMatch)
            {
                data.rightCount++;
            }
            else
            {
                data.wrongCount++;
            }
        }
        return data;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class WheelStopAt : MonoBehaviour
{
    [Header("Stop Setting")]
    public RectTransform stopMin;
    public RectTransform stopMax;

    [Header("Position Setting")]
    public RectTransform posMin;
    public RectTransform posMax;

    [Header("Wheel Setting")]
    public float speed = 10.0f;
    public RectTransform controlledWheel;

    [Header("Events")]
    public UnityEvent onStop;
    public UnityEvent onRightStop;
    public UnityEvent onFalseStop;

    private bool deactive = false;
    private float currentTargetPosHorizontal;
    private float t = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        currentTargetPosHorizontal = posMax.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (deactive)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            onStop.Invoke();

            if (controlledWheel.position.x < stopMax.position.x && controlledWheel.position.x > stopMin.position.x)
            {
                onRightStop.Invoke();
            }
            else
            {
                onFalseStop.Invoke();
            }
            deactive = true;
            return;
        }

        if (Mathf.Abs(controlledWheel.position.x - currentTargetPosHorizontal) < 0.1f)
        {
            currentTargetPosHorizontal = currentTargetPosHorizontal == posMax.position.x ? posMin.position.x : posMax.position.x;
        }

        controlledWheel.position = new Vector3(
            Mathf.MoveTowards(controlledWheel.position.x, currentTargetPosHorizontal, speed * Time.deltaTime),
            controlledWheel.position.y
        );
    }

    [Button("Reset")]
    public void ResetActive()
    {
        onStop.Invoke();
        deactive = false;
    }
}

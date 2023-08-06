using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDetector : MonoBehaviour
{
    public LayerMask objectLayer;
    public UnityEvent onTrigger = new UnityEvent();
    public UnityEvent onExitTrigger = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (objectLayer == (objectLayer | (1 << other.gameObject.layer)))
        {
            onTrigger?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (objectLayer == (objectLayer | (1 << other.gameObject.layer)))
        {
            onExitTrigger?.Invoke();
        }
    }
}

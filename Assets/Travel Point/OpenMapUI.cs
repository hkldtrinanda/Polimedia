using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

public class OpenMapUI : MonoBehaviour
{
    [Header("Input Settings")]
    [DisableInPlayMode] public bool isToogle = false;
    public InputActionReference openMapAction;
    public InputActionReference closeMapAction;

    [Header("Map")]
    public GameObject canvasMap;

    private void OnEnable()
    {
        openMapAction.action.started += OpenMap;

        if (isToogle)
        {
            return;
        }
        closeMapAction.action.started += CloseMap;
    }

    private void OnDisable()
    {
        openMapAction.action.started -= OpenMap;

        if (isToogle)
        {
            return;
        }
        closeMapAction.action.started -= CloseMap;
    }

    public void OpenMap(InputAction.CallbackContext ctx)
    {
        canvasMap.SetActive(isToogle ? !canvasMap.activeSelf : true);
    }

    public void CloseMap(InputAction.CallbackContext ctx)
    {
        canvasMap.SetActive(false);
    }
}

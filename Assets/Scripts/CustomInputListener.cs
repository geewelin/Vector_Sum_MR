using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomInputListener : MonoBehaviour
{

    public InputActionReference toggleReference = null;

    private void Awake()
    {
        toggleReference.action.started += Draw;
        toggleReference.action.canceled += Hide;

    }

    private void OnDestroy()
    {
        toggleReference.action.started -= Draw;
        toggleReference.action.canceled -= Hide;
    }

    private void Draw(InputAction.CallbackContext context)
    {
        Debug.Log("TriggerPressed started!");
        ToggleInformationManager.Instance.Draw();
    }

    private void Hide(InputAction.CallbackContext context)
    {
        Debug.Log("TriggerPressed ended!");
        ToggleInformationManager.Instance.Hide();
    }



}

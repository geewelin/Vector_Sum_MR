using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CustomInputListener : MonoBehaviour
{

    public InputActionReference toggleReference = null; //reference for toggle vector information
    public InputActionReference resetReference = null; //reference for resetting vectors

    private void Awake()
    {
        toggleReference.action.started += Draw;
        toggleReference.action.canceled += Hide;

        resetReference.action.started += ResetScene; 

    }

    private void OnDestroy()
    {
        toggleReference.action.started -= Draw;
        toggleReference.action.canceled -= Hide;

        resetReference.action.started -= ResetScene;
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

    private void ResetScene(InputAction.CallbackContext context)
    {
        Debug.Log("TriggerPressed performed!");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }



}

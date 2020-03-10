using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class playerAutoJoin : MonoBehaviour
{
    private InputControlList<InputDevice> inputDevices;
    public GameObject playerPrefab;
    //public InputActions controllerScheme;

    void Start()
    {
        Debug.Log(InputUser.GetUnpairedInputDevices());
        inputDevices = InputUser.GetUnpairedInputDevices();
        for (int i = 2; i < inputDevices.Count; i++)
        {
            var p1 = PlayerInput.Instantiate(playerPrefab, pairWithDevice: inputDevices[i]);
        }
    }

    void Update()
    {
        Debug.Log(InputUser.GetUnpairedInputDevices());
    }
}

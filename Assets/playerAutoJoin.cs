using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class playerAutoJoin : MonoBehaviour
{
    private InputControlList<InputDevice> inputDevices;
    public  GameObject playerPrefab;
    //public InputActions controllerScheme;

    void Start()
    {
        //Debug.Log(InputUser.GetUnpairedInputDevices());
        inputDevices = InputUser.GetUnpairedInputDevices();
        //gameObject.GetComponent<PlayerInputManager>().JoinPlayer(controlScheme: "ControllerActions", pairWithDevice: inputDevices[2]);



        for (int i = 2; i < inputDevices.Count; i++)
        {
            gameObject.GetComponent<PlayerInputManager>().JoinPlayer(playerIndex: i, controlScheme: "ControllerActions", pairWithDevice: inputDevices[i]);
        }
    }

    void Update()
    {
        Debug.Log(InputUser.GetUnpairedInputDevices());
    }
}

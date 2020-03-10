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
        inputDevices = InputUser.GetUnpairedInputDevices();
        Debug.Log(inputDevices);

        for (int i = 2; i < inputDevices.Count; i++)
        {
            Debug.Log(inputDevices[i].name);
            if ((inputDevices[i].name).Contains("XInput"))
            {
                Debug.Log("True");
                gameObject.GetComponent<PlayerInputManager>().JoinPlayer(playerIndex: i, controlScheme: "ControllerActions", pairWithDevice: inputDevices[i]);
            }
        }
    }

    void Update()
    {
        Debug.Log(InputUser.GetUnpairedInputDevices());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerColor : MonoBehaviour
{
    GameObject[] players;
    public Sprite[] playerSprites;
    SpriteRenderer sprite;
    PlayerInput playerInput;
    public InputActionAsset action;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = gameObject.GetComponent<PlayerInput>();
        Debug.Log(playerInput.currentControlScheme);
        Debug.Log(playerInput.currentActionMap);
        playerInput.defaultActionMap = "Gameplay";
        playerInput.actions = action;

        playerInput.neverAutoSwitchControlSchemes = true;
    }

    void LateStart()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<SpriteRenderer>().sprite = playerSprites[i];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

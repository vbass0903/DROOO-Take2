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
    public InputActionAsset[] action;
    // Start is called before the first frame update
    void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playerInput = gameObject.GetComponent<PlayerInput>();
        playerInput.defaultActionMap = "Gameplay";

        gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[(players.Length - 1)];
        playerInput.actions = action[(players.Length - 1)];
        playerInput.neverAutoSwitchControlSchemes = true;
    }

    void LateStart()
    {
        /*players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<SpriteRenderer>().sprite = playerSprites[i];
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

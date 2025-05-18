using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class NPC : MonoBehaviour
{
    public enum NPCState{Default, Idle, Talk}
    public NPCState currentState = NPCState.Idle;
    private NPCState defaultstate;

    public NPC_Talk talk;


    void Start()
    {
        defaultstate = currentState;
        SwitchState(currentState);
    }

    public void SwitchState(NPCState newState)
    {
        currentState = newState;
        talk.enabled = newState == NPCState.Talk;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            SwitchState(NPCState.Talk);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            SwitchState(defaultstate);
        }
    }
}
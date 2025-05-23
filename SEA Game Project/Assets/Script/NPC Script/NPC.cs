using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class NPC : MonoBehaviour
{
    public enum NPCState{Talk, Wander}
    public NPCState currentState = NPCState.Wander;
    private NPCState defaultstate;

    public NPC_Talk talk;
    public NPC_Wander wander;


    void Start()
    {
        defaultstate = currentState;
        SwitchState(currentState);
    }

    public void SwitchState(NPCState newState)
    {
        currentState = newState;
        talk.enabled = newState == NPCState.Talk;
        wander.enabled = newState == NPCState.Wander;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            SwitchState(NPCState.Talk);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            SwitchState(NPCState.Wander);
        }
    }
}
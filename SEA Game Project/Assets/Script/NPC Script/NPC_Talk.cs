using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC_Talk : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Animator interactAnim;
    public DialogueSO dialogueSO;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        rb.linearVelocity = Vector2.zero;
        interactAnim.Play("Open");
        anim.Play("Idle");
        
    }

    private void OnDisable()
    {
        interactAnim.Play("Close");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact"))
        {
            if(DialogueManager.Instance.isDialogueActive)
                DialogueManager.Instance.AdvanceDialogue();

            else
                DialogueManager.Instance.StartDialogue(dialogueSO);
        }
    }
}

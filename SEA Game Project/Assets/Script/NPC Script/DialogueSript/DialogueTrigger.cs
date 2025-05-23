using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueSO dialogueToTrigger;
    private bool hasTriggered = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTriggered && collision.CompareTag("Player"))
        {
            DialogueManager.Instance.StartDialogue(dialogueToTrigger);
            hasTriggered = true;
        }
    }
}

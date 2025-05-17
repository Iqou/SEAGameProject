using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	public static DialogueManager Instance;


  [Header("UI References")]
  public Image portrait;
  public CanvasGroup CanvasGroup;
  public TMP_Text actorName;
  public TMP_Text dialogueText;
  public bool isDialogueActive;

  public DialogueSO currentDialogue;
  private int dialogueIndex;

  private void Awake()
  {
	if(Instance == null)
		Instance = this;
	else
		Destroy(gameObject);
	CanvasGroup.alpha = 0;
	CanvasGroup.interactable = false;
	CanvasGroup.blocksRaycasts = false;
  }

  public void StartDialogue(DialogueSO dialogueSO)
  {
	  currentDialogue = dialogueSO;
	  dialogueIndex = 0;
	  isDialogueActive = true;
	  ShowDialogue();
  }

  public void AdvanceDialogue()
  {
	if(dialogueIndex < currentDialogue.lines.Length)
		ShowDialogue();
	else
		EndDialogue();
  }

  private void ShowDialogue()
  {
	  DialogueLine line = currentDialogue.lines[dialogueIndex];
	  
	  portrait.sprite = line.speaker.potrait;
	  actorName.text = line.speaker.actorName;

	  dialogueText.text = line.text;
	  CanvasGroup.alpha = 1;
	  CanvasGroup.interactable = true;
	  CanvasGroup.blocksRaycasts = true;

	  dialogueIndex++;
  }

  private void EndDialogue()
  {
	  dialogueIndex = 0;
	  isDialogueActive = false;
	  CanvasGroup.alpha = 0;
	  CanvasGroup.interactable = false;
	  CanvasGroup.blocksRaycasts = false;
  }
}

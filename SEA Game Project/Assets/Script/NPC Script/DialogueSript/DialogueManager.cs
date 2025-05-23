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
  public Button[] choiceButton;


  public DialogueSO currentDialogue;
  public DialogueSO dialogueSO;
  private int dialogueIndex;
  Audiomanager Audiomanager;

  private void Awake()
  {
	Audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();

	if(Instance == null)
		Instance = this;
	else
		Destroy(gameObject);
	CanvasGroup.alpha = 0;
	CanvasGroup.interactable = false;
	CanvasGroup.blocksRaycasts = false;

	foreach (var button in choiceButton)
		button.gameObject.SetActive(false);

  }

    public void Start()
    {
        StartDialogue(dialogueSO);
    }

    public void StartDialogue(DialogueSO dialogueSO)
  {
	  currentDialogue = dialogueSO;
	  dialogueIndex = 0;
	  isDialogueActive = true;
	  ShowDialogue();
	  playdialoguesound();
  }

  public void AdvanceDialogue()
  {
	if(dialogueIndex < currentDialogue.lines.Length){
		ShowDialogue();
		playdialoguesound();
	}
	else
		ShowChoices();
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
	  ClearChoices();
	  CanvasGroup.alpha = 0;
	  CanvasGroup.interactable = false;
	  CanvasGroup.blocksRaycasts = false;
  }

  private void ShowChoices()
  {
	  ClearChoices();
	  
	  if (currentDialogue.options.Length > 0)
	  {
			for(int i = 0 ; i < currentDialogue.options.Length; i++)
			{
				var option = currentDialogue.options[i];

				choiceButton[i].GetComponentInChildren<TMP_Text>().text = option.optionText;
				choiceButton[i].gameObject.SetActive(true);

				choiceButton[i].onClick.AddListener(() => ChooseOption(option.nextDialogue));
				choiceButton[i].onClick.AddListener(buttonsound);
			}
	  }
	  else
	  {
		  choiceButton[0].GetComponentInChildren<TMP_Text>().text = "End";
		  choiceButton[0].onClick.AddListener(EndDialogue);
		  choiceButton[0].onClick.AddListener(buttonsound);
		  choiceButton[0].gameObject.SetActive(true);
	  }
  }

  private void ChooseOption(DialogueSO dialogueSO)
  {
	  if(dialogueSO == null)
		EndDialogue();
	  else
	  {
		  ClearChoices();
		  StartDialogue(dialogueSO);
	  }

  }	

  private void ClearChoices()
  {
	  foreach(var button in choiceButton)
	  {
		  button.gameObject.SetActive(false);
		  button.onClick.RemoveAllListeners();

	  }
  }

  void playdialoguesound(){
    int randomIndex = Random.Range(1, 6);

    switch(randomIndex)
    {
        case 1:
            Audiomanager.PlaySFX(Audiomanager.talksound1);
            break;
        case 2:
            Audiomanager.PlaySFX(Audiomanager.talksound2);
            break;
        case 3:
            Audiomanager.PlaySFX(Audiomanager.talksound3);
            break;
        case 4:
            Audiomanager.PlaySFX(Audiomanager.talksound4);
            break;
        case 5:
            Audiomanager.PlaySFX(Audiomanager.talksound5);
            break;
    }
  }

  void buttonsound(){
	  Audiomanager.PlaySFX(Audiomanager.button);
  }


}

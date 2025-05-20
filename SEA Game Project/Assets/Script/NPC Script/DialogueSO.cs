using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSO", menuName = "Dialogue/DialogueNode")]
public class DialogueSO : ScriptableObject
{
	public DialogueLine[] lines;
	public DialogueOptions[] options;
}
[System.Serializable]
public class DialogueLine
{
	public ActorSO speaker;
	[TextArea(3,5)] public string text;
}
[System.Serializable]
public class DialogueOptions
{
	public string optionText;
	public DialogueSO nextDialogue;

}
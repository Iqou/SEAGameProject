using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSO", menuName = "Dialogue/DialogueNode")]
public class DialogueSO : ScriptableObject
{
	public DialogueLine[] lines;
}
[System.Serializable]
public class DialogueLine
{
	public ActorSO speaker;
	[TextArea(3,5)] public string text;
}
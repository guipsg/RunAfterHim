using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textBox;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Image panelImage;
    
    [SerializeField] private AudioSourceGroup audioSourceGroup;
    
    [SerializeField] private Button playDialogueButton;

    private int index = 0;

    [SerializeField] private string[] name;
    [TextArea]
    [SerializeField] private string[] dialogue;

    [SerializeField] private Color[] panelColor;

    [SerializeField] private AudioClip[] typingClip;

    [SerializeField] private UnityEvent OnFinishDialogueEvent;

    

    private DialogueVertexAnimator dialogueVertexAnimator;

    void Awake() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox, audioSourceGroup);
        playDialogueButton.onClick.AddListener(delegate { PlayDialogue(); });
        playDialogueButton.gameObject.SetActive(false);
    }
    public void StartDialogue()
    {
        PlayDialogue();
    }
    private void PlayDialogue() {
        if (index < dialogue.Length)
        {
            playDialogueButton.gameObject.SetActive(false);
            PlayDialogue(dialogue[index]);
            nameText.text = name[index];
            panelImage.color = Color.Lerp(panelImage.color, panelColor[index], 1f);
            index++;
        }
        else
        {
            EndDialogue();
        }
        
    }
    public void EndDialogue()
    {
        OnFinishDialogueEvent.Invoke();
    }

    private void EndSentenceAction()
    {
        playDialogueButton.gameObject.SetActive(true);
    }



    private Coroutine typeRoutine = null;
    void PlayDialogue(string message) {
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueVertexAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, typingClip[index], EndSentenceAction));
    }
}

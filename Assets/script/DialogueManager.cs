using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogeText;

    public Animator animator;

    private Queue<string> sentences;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}

    public void StartDialogue (Dialogue dialogue)
    {

        animator.SetBool("isOpen", true);

        Debug.Log("starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //dialogeText.text = sentence;
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogeText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogeText.text += letter;
            yield return null;
        }
    }

    public void DisplayQuitSentence()
    {
        EndDialogue();
        
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        Debug.Log("End of conversation");
    }
}

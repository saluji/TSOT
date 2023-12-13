using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GetScriptGraph scriptGraph;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    public float textSpeed;
    public bool activeDialogue;
    // Checks if Player is in range with NPC and pushes button to interact
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && activeDialogue)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                ZeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
    }
    //Resets text
    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }
    //Creates written text
    IEnumerator Typing()
    {
        foreach (char c in dialogue[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
        }
    }
    //Activates trigger if Player is in NPC range
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            activeDialogue = true;
        }
    }
    //Deactivates trigger if Player is not in NPC range anymore
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            activeDialogue = false;
            ZeroText();
        }
    }
}

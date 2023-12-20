using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class Dialogue : MonoBehaviour
{
    public GameObject player;
    public ScriptMachine scriptMachine;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;
    public float wordSpeed;

    private void Awake()
    {

    }
    //Start dialogueText string at 1
    void Start()
    {
        dialogueText.text = "";
    }
    //Dialogue check
    void Update()
    {
        //Checks if player is in range and hits interact button
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Z))
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            //Advandes next line of text
            else if (dialogueText.text == dialogue[index])
            {
                NextLine();
            }
        //Displays all text at once without strings overflowing
        }
        if (Input.GetKeyDown(KeyCode.X) && dialoguePanel.activeInHierarchy)
        {
            StopAllCoroutines();
            dialogueText.text = dialogue[index];
        }
    }
    //Removes text, reactivates player movement
    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }
    //Creates written text
    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    //Advances to next line of text
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
            RemoveText();
        }
    }
}
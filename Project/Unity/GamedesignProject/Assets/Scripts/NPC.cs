using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class NPC : MonoBehaviour
{
    public GameObject player;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    private ScriptMachine playerMovement;
    private Animator animator;
    public string[] dialogue;
    private int index = 0;
    public float wordSpeed;
    public bool playerIsClose;

    void Awake()
    {
        playerMovement = player.GetComponent<ScriptMachine>();
        animator = player.GetComponent<Animator>();
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
        if (Input.GetKeyDown(KeyCode.Z) && playerIsClose)
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                dialoguePanel.SetActive(true);
                //Disable player movement while in dialogue, player stays idle when activating dialogue while walking
                playerMovement.enabled = false;
                animator.SetFloat("speed", 0);
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
    //Removes text, reactivate player movement
    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        playerMovement.enabled = true;
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
    //Activates trigger if Player is in NPC range
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    //Deactivates trigger if Player is not in NPC range anymore
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            RemoveText();
        }
    }
}
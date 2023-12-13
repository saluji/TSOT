using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    public GameObject player;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public ScriptMachine playerMovement;
    //public Animator animator;
    public string[] dialogue;
    private int index = 0;
    public float wordSpeed;
    public bool playerIsClose;

    //Disable player movement while in dialogue
    void Awake()
    {
        playerMovement = player.GetComponent<ScriptMachine>();
        //animator = player.GetComponent<Animator>();
    }
    //Start dialogueText string at 1
    void Start()
    {
        dialogueText.text = "";
    }
    //Checks if Player is in range and pushes button to interact
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && playerIsClose)
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                dialoguePanel.SetActive(true);
                playerMovement.enabled = false;
                //animator.enabled = false;
                StartCoroutine(Typing());
            }
            else if (dialogueText.text == dialogue[index])
            {
                NextLine();
            }
        }
        /*if (Input.GetKeyDown(KeyCode.X) && dialoguePanel.activeInHierarchy)
        {
            RemoveText();
        }*/
    }
    //Removes text, reactivates movement
    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        playerMovement.enabled = true;
        //animator.enabled = true;
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
    //Advances to next line of texts
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
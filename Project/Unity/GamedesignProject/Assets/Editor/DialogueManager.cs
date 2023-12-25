/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine.EventSystems;
using System;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private string[] dialogue;
    [SerializeField] private float wordSpeed;
    [SerializeField] private int index = 0;
    //private ScriptMachine playerSM;
    //private RaycastHit2D hit;
    //public string nameText;

    void Awake()
    {
        //int[] array = { 1, 2, 3 };
        //Debug.Log(array.Length);
        //playerSM = player.GetComponent<ScriptMachine>();
        //raycast = player.GetComponent<RaycastHit2D>();
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
        if (Input.GetKeyDown(KeyCode.Z))
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
    void RemoveText()
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
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    private bool activeDialogue;
    // Aktivert Dialog
    void Start()
    {
        //textComponent.text = string.Empty;
        //StartDialogue();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    void StartDialogue()
    {
        gameObject.SetActive(true);
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag==("Soldier") && Input.GetKeyDown(KeyCode.Z))
        textComponent.text = string.Empty;
        StartDialogue();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Raycast : MonoBehaviour
{
    public GameObject player;
    private ScriptMachine scriptMachine;
    public LayerMask layerMask;
    RaycastHit2D hit;
    float raycastDistance = 1f;
    // Start is called before the first frame update
    void Awake()
    {
        scriptMachine = player.GetComponent<ScriptMachine>();
    }

    // Update is called once per frame
    /*void Update()
    {
        hit = Physics2D.Raycast(player.transform.position, Vector2.right*new Vector2(characterDirection,0f), raycastDistance, layerMask);
        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, hit.point, Color.white);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.position + transform.right * raycastDistance, Color.black);
        }
    }*/
}

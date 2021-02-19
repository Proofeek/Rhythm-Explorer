using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObjectNEW : MonoBehaviour
{
    public bool canBePressed;

    public ButtonController2 BC2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (canBePressed)
        {
            if (BC2.bDown)
            {
                gameObject.SetActive(false);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumsColliderScript : MonoBehaviour
{
    public string drumName;
    public bool canDrumDone = false;
    public Collider2D col;
    public DrumsButtonController theDBC;

    void OnTriggerEnter2D(Collider2D other)
    {
        col = other;
        if (other.tag == drumName)
        {
            canDrumDone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == drumName)
        {
            
            if (canDrumDone && !theDBC.bDown)
            {
                GameManager.instance.theDrum(false, new Vector2(0f,0f));
                Debug.Log("МИМО DRUM");
            }
            canDrumDone = false;
            
        }
    }
}

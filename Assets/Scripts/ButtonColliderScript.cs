using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColliderScript : MonoBehaviour
{

    public bool canTargetDone;

    public Collider col;
    public ButtonController2 theBS;
    public ButtonsScript buttons;
    public Slider slider;


    void OnTriggerEnter(Collider other)
    {
        col = other;
        if (other.tag == "Target")
        {
            canTargetDone = true;
            Debug.Log("CanTargetDone TRUE");
        }
        
        if(other.tag == "FinishSong")
        {
            GameManager.instance.Finish();
        }
        if (other.tag == "StartKnob")
        {
            buttons.L1.gameObject.SetActive(false);
            buttons.L2.gameObject.SetActive(false);
            buttons.R1.gameObject.SetActive(false);
            slider.gameObject.SetActive(true);

        }
        /*
        if (other.tag == "FinishKnob")
        {
            buttons.L1.gameObject.SetActive(true);
            buttons.L2.gameObject.SetActive(true);
            buttons.R1.gameObject.SetActive(true);
            slider.gameObject.SetActive(true);

        }*/
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Target")
        {
            if (canTargetDone && !theBS.bDown)
            {
                GameManager.instance.NoteMissed();
                //Debug.Log("МИМО");
            }
            canTargetDone = false;
            Debug.Log("CanTargetDone FALSE");
        }
    }
}
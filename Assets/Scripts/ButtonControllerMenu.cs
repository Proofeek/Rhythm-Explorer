using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerMenu : MonoBehaviour
{
    public Animator ButtonAnimator;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTouchDown()
    {
        ButtonAnimator.SetTrigger("ButtonDown");
    }

    void OnTouchUp()
    {
        ButtonAnimator.SetTrigger("ButtonUp");
    }
    void OnTouchStay()
    {
        ButtonAnimator.SetTrigger("ButtonStay");
    }
    void OnTouchExit()
    {
        ButtonAnimator.SetTrigger("ButtonUp");
    }
}

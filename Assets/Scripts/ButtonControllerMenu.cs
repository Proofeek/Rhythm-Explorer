using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonControllerMenu : MonoBehaviour
{
    public Animator ButtonAnimator;
    public float SecondsWait = 0.4f;

    [System.Serializable]
    public class MyEventType : UnityEvent { }
    public MyEventType OnButtonUp;

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
        StartCoroutine(ChangePreset());
    }
    void OnTouchStay()
    {
        ButtonAnimator.SetTrigger("ButtonStay");
    }
    void OnTouchExit()
    {
        ButtonAnimator.SetTrigger("ButtonUp");
    }

    IEnumerator ChangePreset()
	{
        yield return new WaitForSeconds(SecondsWait);
        OnButtonUp.Invoke();
    }
}

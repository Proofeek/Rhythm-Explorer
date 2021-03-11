using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerMenu : MonoBehaviour
{
    public Animator ButtonAnimator;

    public GameObject MainMenu;
    public GameObject SettingsMenu;
    public GameObject LevelMenu;

    public int buttonIndex = 0; //0-MainMenu; 1-LevelMenu; 2-SettingsMenu
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
        StartCoroutine(ChangePreset(buttonIndex));
    }
    void OnTouchStay()
    {
        ButtonAnimator.SetTrigger("ButtonStay");
    }
    void OnTouchExit()
    {
        ButtonAnimator.SetTrigger("ButtonUp");
    }

    IEnumerator ChangePreset(int buttonIndex)
	{
        yield return new WaitForSeconds(0.8f);
        if(buttonIndex == 0)
		{
            SettingsMenu.gameObject.SetActive(false);
            LevelMenu.gameObject.SetActive(false);
            MainMenu.gameObject.SetActive(true);
        }
        if(buttonIndex == 1)

        {
            SettingsMenu.gameObject.SetActive(false);
            LevelMenu.gameObject.SetActive(true);
            MainMenu.gameObject.SetActive(false);
        }
        if(buttonIndex == 2)

        {
            SettingsMenu.gameObject.SetActive(true);
            LevelMenu.gameObject.SetActive(false);
            MainMenu.gameObject.SetActive(false);
        }
    }
}

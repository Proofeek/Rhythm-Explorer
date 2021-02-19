using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    private GameObject[] sliders;
    private GameObject[] buttons;

    void Start()
    {
        buttons = GameObject.FindGameObjectsWithTag("Button");
        sliders = GameObject.FindGameObjectsWithTag("Slider");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "StartKnob")
        {
            Debug.Log("PKFDHd");
            foreach (GameObject iter in sliders)
            {
                iter.gameObject.SetActive(true);
            }
            foreach (GameObject iter in buttons)
            {
                iter.gameObject.SetActive(false);
            }
        }

        if (other.tag == "FinishKnob")
        {
            foreach (GameObject iter in sliders)
            {
                iter.gameObject.SetActive(false);
            }
            foreach (GameObject iter in buttons)
            {
                iter.gameObject.SetActive(true);
            }
        }

        if (other.tag == "FinishSong")
        {
            GameManager.instance.Finish();
        }
    }
}

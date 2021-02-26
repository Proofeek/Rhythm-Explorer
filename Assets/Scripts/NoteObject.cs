using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class NoteObject : MonoBehaviour
{
    public int color;

    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        //InkCLone = Instantiate(VFX_ink);
        //InkCLone.transform.SetParent(this.gameObject.transform, false);
        //.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log("ХАХАХАХААХАХ");
        if(other.tag == "ShadowActivator")
        {
            Debug.Log("fwefwefwe33333333333fwfw");

            GetComponent<SpriteRenderer>().enabled = true;
            // GetComponent<UnityEngine.Experimental.Rendering.Universal.ShadowCaster2D>().enabled = true;
            //InkCLone.SetActive(true);
            //InkCLone.GetComponent<VisualEffect>().SendEvent("Start");
           
            
        }
            

        if (other.tag == "ShadowDeactivator")
        {
            gameObject.SetActive(false);
        }
    }
    
    void StartAnimDisappear()
	{
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Animation>().Play(PlayMode.StopSameLayer);
        if(GetComponent<Animation>().isPlaying == false)
		{
            gameObject.SetActive(false);
		}
    }

    void ChangeColor()
	{
        if(color == 1)
		{
		}
	}
}

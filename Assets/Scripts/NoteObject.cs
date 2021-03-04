using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class NoteObject : MonoBehaviour
{
    public int color;

    public Animator targetAnimator;

    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        //InkCLone = Instantiate(VFX_ink);
        //InkCLone.transform.SetParent(this.gameObject.transform, false);
        //.SetActive(false);
        if(color == 0)
		{
            gameObject.GetComponent<SpriteRenderer>().material.SetVector("Color_HDR", new Vector4(0, 0, 0, 0));
		}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log("ХАХАХАХААХАХ");
        if(other.tag == "ShadowActivator")
        {
            Debug.Log("fwefwefwe33333333333fwfw");

            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Animator>().enabled = true;
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

        GetComponent<Animator>().SetTrigger("Dis");

        /*
        GetComponent<CircleCollider2D>().enabled = false;
        //GetComponent<Animation>().Play(PlayMode.StopSameLayer);
        GetComponent<Animation>().Blend("TargetDisappear", 0.3f, 1.0f);
        if (GetComponent<Animation>().isPlaying == false)
		{
            gameObject.SetActive(false);
		}*/
    }
}

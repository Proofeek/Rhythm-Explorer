using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class NoteObject : MonoBehaviour
{
    public int color; //0.Purple; 1.Green; 2.Red; 3.Yellow; 4.Blue;

    public Animator targetAnimator;

    Vector3 button;

    bool done = false;

    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        //InkCLone = Instantiate(VFX_ink);
        //InkCLone.transform.SetParent(this.gameObject.transform, false);
        //.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "ShadowActivator")
        {

            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Animator>().enabled = true;
            // GetComponent<UnityEngine.Experimental.Rendering.Universal.ShadowCaster2D>().enabled = true;
            //InkCLone.SetActive(true);
            //InkCLone.GetComponent<VisualEffect>().SendEvent("Start");

            if(color == 1){
                GetComponent<Animator>().SetTrigger("Green");
            }
            if(color == 2){
                GetComponent<Animator>().SetTrigger("Red");
            }
            if(color == 3){
                GetComponent<Animator>().SetTrigger("Yellow");
            }
            if(color == 4){
                GetComponent<Animator>().SetTrigger("Blue");
            }
        }
            

        if (other.tag == "ShadowDeactivator")
        {
            gameObject.SetActive(false);
        }
    }
    
    void StartAnimDisappear(Vector3 buttonPos)
	{

        GetComponent<Animator>().SetTrigger("Dis");
        GetComponent<CircleCollider2D>().enabled = false;
        button = buttonPos;
        done = true;
        /*
        //GetComponent<Animation>().Play(PlayMode.StopSameLayer);
        GetComponent<Animation>().Blend("TargetDisappear", 0.3f, 1.0f);
        if (GetComponent<Animation>().isPlaying == false)
		{
            gameObject.SetActive(false);
		}*/
    }
	private void Update()
	{
		if (done)
		{
            gameObject.transform.position = button;
            //Vector2.Lerp(gameObject.transform.position, button, Time.deltaTime*40);
        }
	}
}

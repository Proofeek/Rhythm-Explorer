using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class BeatScroller : MonoBehaviour
{
    public float BPM;
    private float beatTempo;

    public bool hasStarted;

    public float mod = 1;
    public float modPosForDrums = 0;
    private Spline spline;

    private float posYforLaser;

    public bool beat16;
    private float beatInterval16, beatTimer16;
    public int beatCount16;

    public float imageScale;
    public float colliderScale;


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] allLaserSpots = GameObject.FindGameObjectsWithTag("LaserSpot");
        foreach(GameObject laserspot in allLaserSpots)
        {

        var spriteShapeController = laserspot.GetComponent<SpriteShapeController>();
        spline = spriteShapeController.spline;

        for (var point = 1; point < spline.GetPointCount(); point++)
        {
            Vector3 pointVector = spline.GetPosition(point);
            pointVector = new Vector3(pointVector.x, pointVector.y * mod, pointVector.z);
            spline.SetPosition(point, pointVector);
        }
        }

        GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject target in allTargets)
        {
            //target.transform.localScale = new Vector3 (10f, 10f, 0f);
            target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y * mod, 0f);
        }
        GameObject[] allLasersSpots = GameObject.FindGameObjectsWithTag("LaserSpot");
        foreach (GameObject target in allLasersSpots)
        {
            target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y * mod, 0f);
        }
        GameObject[] allExtras = GameObject.FindGameObjectsWithTag("Extra");
        foreach (GameObject target in allExtras)
        {
            target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y * mod, 0f);
        }
        GameObject[] allFinLasers = GameObject.FindGameObjectsWithTag("FinishLaser");
        foreach (GameObject target in allFinLasers)
        {
            target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y * mod, 0f);
        }

        GameObject[] allStartLasers = GameObject.FindGameObjectsWithTag("StartLaser");
        foreach (GameObject target in allStartLasers)
        {
            target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y * mod, 0f);
        }

        foreach(DrumsColliderScript iter in FindObjectsOfType<DrumsColliderScript>())
        {
            GameObject[] allDrums = GameObject.FindGameObjectsWithTag(iter.GetComponent<DrumsColliderScript>().drumName);
            foreach (GameObject drum in allDrums)
            {
                drum.transform.position = new Vector3(drum.transform.position.x, (drum.transform.position.y + modPosForDrums) * mod, 0f);
            }

        }



        foreach(TransformPos iter in FindObjectsOfType<TransformPos>())
        {
            if(iter.GetComponent<TransformPos>().theButton==true)
            {
                //RectTransform lol = iter.GetComponent<TransformPos>().theButton.GetComponent<RectTransform>();
                //Vector3 pos = Camera.main.ViewportToWorldPoint(lol.position);
                //iter.transform.position = Camera.main.WorldToViewportPoint(pos);
                iter.transform.position = iter.GetComponent<TransformPos>().theButton.GetComponent<RectTransform>().transform.position;
                //var screenToWorldPosition = Camera.main.ScreenToWorldPoint(iter.GetComponent<TransformPos>().theButton.GetComponent<RectTransform>().transform.position);
                //iter.transform.position = screenToWorldPosition;

                //iter.transform.position = new Vector3(iter.GetComponent<TransformPos>().theButton.gameObject.transform.position.x, iter.GetComponent<TransformPos>().theButton.gameObject.transform.position.y, 0f);

                if (iter.gameObject.name == "L1")
                {
                    posYforLaser = iter.GetComponent<TransformPos>().theButton.gameObject.transform.position.y;
                }
            }
            else
            {
               // iter.transform.position = new Vector3(iter.GetComponent<TransformPos>().theDrum.gameObject.transform.position.x, iter.GetComponent<TransformPos>().theDrum.gameObject.transform.position.y, 0f);
            }
        }

        GameObject[] allLasers = GameObject.FindGameObjectsWithTag("Laser");
        foreach (GameObject target in allLasers)
        {
            target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + posYforLaser, 0f);
        }


        transform.position -= new Vector3(0f, -1.2f, 0f);
        beatTempo = (BPM / 60f) * mod;
        beatInterval16 = (60 / BPM/2 );

    }

    void FixedUpdate()
    {
        if (hasStarted)
        {
            transform.position -= new Vector3(0f, (beatTempo * Time.fixedDeltaTime), 0f);

            beat16 = false;
            beatTimer16 += Time.fixedDeltaTime;
            if(beatTimer16 >= beatInterval16)
			{
                beat16 = true;
                beatTimer16 =0;
                
                //beatTimer16 -= beatInterval16;
                //beatCount16++;
                //Debug.Log("D16");

			}

        }

    }
}

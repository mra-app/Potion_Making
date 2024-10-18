using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accio : MonoBehaviour
{

   public Cast subjectToObserve;
   Camera cam;
   public bool isUsed=false;
   AudioSource SoundData;
   public float SoundDelay;

    private void Awake()
    {
       
        if (subjectToObserve != null)
        {
            
            subjectToObserve.ThingHappened += OnThingHappened;
        }
        cam=subjectToObserve.GetComponentInParent<Camera>();
        SoundData = GetComponent<AudioSource>();

    }

    private void OnDestroy()
    {
        if (subjectToObserve != null)
        {
            subjectToObserve.ThingHappened -= OnThingHappened;
        }
    }
    private void OnThingHappened(){
        //cast the Spell if the item is close to mid of canves and not too far or behind user
        GameObject Canvas = GameObject.FindWithTag("Canvas");
        Vector3 ItemToCanvasDist= cam.WorldToScreenPoint(transform.position);
        if(ItemToCanvasDist.z > 20 || ItemToCanvasDist.z < 0)
            return;
        ItemToCanvasDist.z=0;
        float ItemToScreenMiddleDist = Vector3.Distance(ItemToCanvasDist, Canvas.transform.position);
        if(ItemToScreenMiddleDist < 15 ||(ItemToCanvasDist.z < 4 && ItemToScreenMiddleDist < 20)){
            SoundData.PlayDelayed(SoundDelay);
            StartCoroutine(moveItem());
        }
    }
    IEnumerator moveItem(){
        float journeyTime = 0.4f;
        float startTime = Time.time;
        Vector3 fpos=transform.position;
        Vector3 center = (subjectToObserve.transform.position + fpos) /2 + new Vector3(0,1,0) ;
        while(center!=transform.position){
            yield return new WaitForSeconds(0.01f);
            float fracComplete = (Time.time - startTime) / journeyTime;
            transform.position = Vector3.Lerp(fpos, center, fracComplete);
        }
        startTime = Time.time;
        while(subjectToObserve.transform.position!=transform.position){
            yield return new WaitForSeconds(0.01f);
            float fracComplete = (Time.time - startTime) / journeyTime;
            transform.position = Vector3.Lerp(center, subjectToObserve.transform.position, fracComplete);
        }
        

    }

}

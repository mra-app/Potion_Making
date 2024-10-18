using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformItem : MonoBehaviour
{
    
    public Cast subjectToObserve;
    public Animator MoveItem;
    Camera cam;
    public float distance;
    bool Usable = true;
    AudioSource audioData;

    private void Awake()
    {
       
        if (subjectToObserve != null)
        {
            
            subjectToObserve.ThingHappened += OnThingHappened;
        }
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        audioData = GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        if (subjectToObserve != null)
        {
            subjectToObserve.ThingHappened -= OnThingHappened;
        }
    }
    private void OnThingHappened(){
        //do the transform if the item is close to mid of canves
        GameObject Canvas = GameObject.FindWithTag("Canvas");
        WinCheck2 checker = Canvas.GetComponentInChildren<WinCheck2>();
        
        Vector3 ItemToCanvasDist= cam.WorldToScreenPoint(transform.position);
        ItemToCanvasDist.z=0;
        float ItemToScreenMiddleDist = Vector3.Distance(ItemToCanvasDist, Canvas.transform.position);
        
        if(ItemToScreenMiddleDist < distance && Usable){
            checker.MoveItemCallBack(gameObject.name);
            //To count a transform twice
            Usable = false;
            if(MoveItem != null)
                MoveItem.SetTrigger("move");
            StartCoroutine(MakeItemUseable());
        }
    }
    IEnumerator MakeItemUseable(){

            yield return new WaitForSeconds(0.5f);
            Usable = true;

    }

}

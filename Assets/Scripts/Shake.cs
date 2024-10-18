using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shake : MonoBehaviour
{

    public Vector3 Movement;
    public float journeyTime ;

    private float startTime;
    bool WandMove1 = false;
    bool WandMove2 = false;
    private Cast cast;
    Quaternion firstPlace;
    AudioSource SoundData;
    bool usable= true;

    private void Awake() {
        SoundData = GetComponent<AudioSource>();
        cast = GetComponent<Cast>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Q))
            Application.Quit();
       if(Input.GetKeyDown(KeyCode.R)){
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
       }

        if (Input.GetMouseButton(0)){
            firstPlace = transform.rotation;
            // When clicked 1) move wand  
            WandMove1 = true;
            startTime = Time.time;
            //2) get object move towards player
            cast.Accio();
            //3)play wand sound
            StartCoroutine(PlaySound());

        }
        if(WandMove1){
            moveRotationByTime(Movement,journeyTime,startTime,()=>{
                WandMove1 = false;
                WandMove2 = true;
                startTime = Time.time;
            });
        }
        if(WandMove2){
           moveRotationByTime(-Movement,journeyTime,startTime,()=>{
            WandMove2 = false;
            //to put it in the original place
            transform.rotation = firstPlace;
            });

        }

    
    }

    void moveRotationByTime(Vector3 goalRotation,float journeyTime,float startTime,UnityEngine.Events.UnityAction Callback){
        Vector3 center = new Vector3(0,0,0);
        float fracComplete = (Time.time - startTime) / journeyTime;
        transform.Rotate(Vector3.Slerp(center, goalRotation, fracComplete));
        if(fracComplete>=1f){
            Callback();
            }
    }
    //to play the sound once and not keep playing as long as the key is pressed waitForSeconds is called. 
    IEnumerator PlaySound(){
        if(usable){
            usable = false;
        if(SoundData != null)
            SoundData.Play(0);
        yield return new WaitForSeconds(0.5f);
        usable = true;
        }
    }

    
}

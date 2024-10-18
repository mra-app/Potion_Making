using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour
{
        public List<Text> UiTotal;
        public GameObject winPanel;
        public GameObject losePanel;
        AudioSource[] audioData= new AudioSource[2];
        public List<int> itemTotal = new List<int>();

    private void Awake() {
        makeItemList();
        audioData = GetComponents<AudioSource>();
    }
    private void makeItemList() {

        int n= 16;
        int count=0;
        for(int i = 0 ;i < 3; i++){
            int rand = Random.Range(2, Mathf.Min(7,n-count));
            itemTotal.Add(rand);
            UiTotal[i].text = itemTotal[i].ToString();
            count += rand;
        }
        itemTotal.Add(n-count);
        UiTotal[3].text = itemTotal[3].ToString();
        
    }

    private void OnCollisionEnter(Collision other) {
        //check for user collision to cauldron
        if(other.gameObject.tag != "Player")
            return;
        Catch catchScript = other.gameObject.GetComponent<Catch>();
        for(int i = 0 ; i < 4 ; i++){
            if(catchScript.ItemNameCountMap["Item"+i] < itemTotal[i])
            {
                losePanel.SetActive(true);
                audioData[1].Play();
                return;
            }
          }

          winPanel.SetActive(true);
          audioData[0].Play();
          StartCoroutine(GoToNextLevel());
    }
    public IEnumerator GoToNextLevel(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);


    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Catch : MonoBehaviour
{
    public List<Text> UiCounter;
    public Dictionary<string,int> ItemNameCountMap= new Dictionary<string, int>();
    public List<GameObject> UiWin;
     List<int> itemTotal = new List<int>();
    void Start()
    {
        for(int i = 0; i < 4; i++){
            ItemNameCountMap.Add("Item"+i,0);
        }          
        itemTotal = GameObject.FindWithTag("Finish").GetComponent<WinCheck>().itemTotal;

    }
     void OnTriggerEnter(Collider other)
     {
        Accio script = other.gameObject.GetComponent<Accio>();
        //To not count one item multiple times
        if(script.isUsed == false){
          ItemNameCountMap[other.gameObject.tag]++;
          Destroy(other.gameObject);

          for(int i = 0; i < 4; i++){
            UiCounter[i].text= ItemNameCountMap["Item"+i].ToString();

            if(itemTotal[i] <= ItemNameCountMap["Item"+i]){
              UiWin[i].SetActive(true);
            }
          }
          script.isUsed = true;
        }
         
     }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WinCheck2 : MonoBehaviour
{
    public List<Text> UiInstruction;
    public GameObject winPanel;
    public GameObject losePanel;
    AudioSource[] audioData= new AudioSource[2];
    public ulong SoundDelay;
    List<string> instruction=new List<string>();
    List<string> userMoveList=new List<string>();
    private void Awake() {
        audioData = GetComponents<AudioSource>();
    }
    private void Start() {
        CreateInstructions();
    }
    void CreateInstructions()
    {
        List<string> temp=new List<string>();
        int j =0;
        temp.Add("Item");
        temp.Add("Item1");
        temp.Add("Item2");
        temp.Add("Item3");
        temp.Add("Spoon");
        temp.Add("Spoon");
        int tempInitLen=temp.Count;
        while(instruction.Count < tempInitLen){
            j = Random.Range(0,temp.Count);
            instruction.Add(temp[j]);
            temp.Remove(temp[j]);
        }
        int i = 0;
        foreach(string item in instruction){

        if(item == "Item")
                UiInstruction[i].text = "  add the Orenge item";
            else if(item == "Item1")
                UiInstruction[i].text = "  add the Silver item";
            else if(item == "Item2")
                UiInstruction[i].text = "  add the Green item";
            else if(item == "Item3")
                UiInstruction[i].text = "  add the Brown item";
            else if(item == "Spoon")
                UiInstruction[i].text = "  stir antiClockwise";
            i+=1;
            Debug.Log(item);
        }

        instruction.Add("Cauldron");

    }

    public void MoveItemCallBack(string objName){
        //add the transform to user moves and check if the game is finished
        userMoveList.Add(objName);
        if(objName == "Cauldron"){
            if(userMoveList.Count != instruction.Count){ 
                losePanel.SetActive(true);
                audioData[1].Play(SoundDelay);
                return;
            }
            for(int i = 0; i < userMoveList.Count; i++){
                if(userMoveList[i] != instruction[i]){
                    losePanel.SetActive(true);
                    audioData[1].Play(SoundDelay);
                    return;
                }
            }
            winPanel.SetActive(true);
            audioData[0].Play(SoundDelay);

        }
    }
}

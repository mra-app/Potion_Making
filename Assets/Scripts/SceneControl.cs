using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoToLevel(int levelNum){
        SceneManager.LoadScene(levelNum);
    }
        
    private void Update() {
         if(Input.GetKeyDown(KeyCode.Q))
            Application.Quit();
    }
}

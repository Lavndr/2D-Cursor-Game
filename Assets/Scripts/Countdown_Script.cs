using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 


public class Countdown_Script : MonoBehaviour
{
    public Text Countdown_Text;
    public float totalTime = 60;
    public GameObject playerInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   

        if(playerInfo.GetComponent<MousePosition>().lockedCond == true)
        {
            totalTime -= Time.deltaTime; 
            Countdown_Text.text = "Time Remaining: " + Mathf.Round(totalTime);
        }

        if(totalTime <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    
    }
}

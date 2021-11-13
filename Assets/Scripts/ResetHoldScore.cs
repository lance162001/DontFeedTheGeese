using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHoldScore : MonoBehaviour
{

    public ScoreHolderScript scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Reset HoldScore
    public void ScoreReset()
    {
        //Retrieve Score
        GameObject scoreObject = GameObject.Find("ScoreHolder");
        scoreScript = scoreObject.GetComponent<ScoreHolderScript>();
        //Find Score and update
        scoreScript.gooseFedHold = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

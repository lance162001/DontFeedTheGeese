using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{

    GameObject myScoreDisplay;
    public Text gooseScore;
    public ScoreHolderScript scoreScript;
    public Font gameFont;
    public Color textColor;
    public Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        // Create a temporary reference to the current scene.
        currentScene = SceneManager.GetActiveScene();

        //Retrieve Score
        GameObject scoreObject = GameObject.Find("ScoreHolder");
        scoreScript = scoreObject.GetComponent<ScoreHolderScript>();
        //Find Score
        myScoreDisplay = GameObject.Find("GooseScore");
        gooseScore = myScoreDisplay.GetComponent<Text>();

        //Update text and display
        gooseScore.text = "Geese fed:  " + scoreScript.gooseFedHold;
        //Debug.Log(scoreScript.gooseFedHold);

        //Set text font, color, size, and alignment
        gooseScore.font = gameFont;
        gooseScore.color = textColor;
        gooseScore.fontSize = 28;
        gooseScore.alignment = TextAnchor.MiddleCenter;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    GameObject playerObj;
    int playerHealth;
    int maxGeese;
    int curGeese;
    bool lost = false;
    UserInput input;
    public GameObject goosePrefab;
    public ScoreHolderScript scoreScript;
    public GameObject scoreObject;
    int[] xCoords;
    int[] yCoords;
    int xCoord;
    int yCoord;
    int count;
    bool spawnG;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponentInChildren<UserInput>();
        playerObj = GameObject.Find("Player");
        playerHealth = 2;
        curGeese = 0;
        maxGeese = 40;
        spawnG = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!lost) { input.run(); }
        if (curGeese < 5) { 
            curGeese+=createGeese(Random.Range(5, 10)); 
        }
        if (Random.Range(0,10) == 1) { curGeese += createGeese(2); }
    }

    public void hurt()
    {
        if (playerHealth == 1)
        {
            //put up game over, stop player
            lost = true;
            SceneManager.LoadScene(2);

        }
        else
        {
            playerHealth--;
            //update ui
        }
    }

    public void byeGoose(GameObject o, Goose g)
    {
        Destroy(o);
        curGeese += createGeese(Random.Range(0,4));

        //Add one to score
        scoreObject = GameObject.Find("ScoreHolder");
        scoreScript = scoreObject.GetComponent<ScoreHolderScript>();
        scoreScript.feedGeese();
    }

    int createGeese(int amount)
    {
        int count = 0;
        while (count < amount && maxGeese > curGeese)
        {
            //Geese spawn on the map, excluding the player coordinates
            while (spawnG == false)
            {
                xCoord = Random.Range(-20, 30);
                if (xCoord != playerObj.transform.position.x)
                {
                    spawnG = true;
                    Debug.Log("Position X OKAY!");
                }
                yCoord = Random.Range(-20, 65);
                if (yCoord != playerObj.transform.position.y)
                {
                    spawnG = true;
                    Debug.Log("Position Y OKAY!");
                }
            }
            ++count;
            GameObject newGoose = Instantiate(goosePrefab);
            newGoose.transform.position = new Vector3(xCoord,yCoord,0);
            spawnG = false;
            newGoose.SetActive(true);
        }
        return count;
    }
}

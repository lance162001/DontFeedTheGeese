using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    int playerHealth;
    int maxPlayerHealth;
    int maxGeese;
    int curGeese;
    bool lost = false;
    UserInput input;
    public GameObject goosePrefab;
    public ScoreHolderScript scoreScript;
    public GameObject scoreObject;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponentInChildren<UserInput>();
        maxPlayerHealth = 1;
        playerHealth = maxPlayerHealth;
        curGeese = 0;
        maxGeese = 40;
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
            ++count;
            GameObject newGoose = Instantiate(goosePrefab);
            newGoose.transform.position = new Vector3(Random.Range(-30,50),Random.Range(-20,75),0);
            newGoose.SetActive(true);
        }
        return count;
    }
}

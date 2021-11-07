using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Manager : MonoBehaviour
{
    int playerHealth;
    int maxPlayerHealth;
    int maxGeese;
    int curGeese;
    bool lost = false;
    UserInput input;
    public GameObject goosePrefab;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponentInChildren<UserInput>();
        playerHealth = maxPlayerHealth;
        curGeese = 0;
        maxGeese = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (!lost) { input.run(); }
        if (curGeese < 5) { 
            curGeese+=createGeese(Random.Range(5, 10)); 
        }
    }

    public void hurt()
    {
        if (playerHealth == 1)
        {
            //put up game over, stop player
            lost = true;
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
    }

    int createGeese(int amount)
    {
        int count = 0;
        while (count < amount && maxGeese > curGeese)
        {
            ++count;
            GameObject newGoose = Instantiate(goosePrefab);
            Debug.Log(newGoose);
            newGoose.transform.position = new Vector3(Random.Range(-10,10),Random.Range(-10,10),0);
            newGoose.SetActive(true);
        }
        return count;
    }
}

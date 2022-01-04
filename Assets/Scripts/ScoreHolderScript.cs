using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreHolderScript : MonoBehaviour
{

    public int geeseFed = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void feedGeese()
    {
        geeseFed++;
        Debug.Log("Fuck " + geeseFed);
    }


    private static ScoreHolderScript holdInstance;
    void Awake()
    {
        //Check if instance already exists
        if (holdInstance == null)

            //if not, set instance to this
            holdInstance = this;

        //If instance already exists and it's not this:
        else if (holdInstance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }
}

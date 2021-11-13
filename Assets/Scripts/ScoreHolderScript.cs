using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreHolderScript : MonoBehaviour
{

    public int gooseFedHold = 0;
    public Manager managerScript;
    public Scene currentScene;
    public GameObject managerObject;

    // Start is called before the first frame update
    void Start()
    {
        managerObject = GameObject.Find("Manager");
        managerScript = managerObject.GetComponent<Manager>();

        // Create a temporary reference to the current scene.
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;
        if (sceneName == "TileMapTesting")
        {
            managerObject = GameObject.Find("Manager");
            managerScript = managerObject.GetComponent<Manager>();
            gooseFedHold = managerScript.geeseFed;
        }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour {
    public Animator animator;
    
    public float speed;
    bool firing = false;
    public GameObject bread;
    public GameObject sprite;
    public void run(){
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(x,y,0)*speed*Time.deltaTime);

        //Reference gamestart variable to allow animation
        GameObject Goose = GameObject.Find("Goose");
        Goose gooseScript = Goose.GetComponent<Goose>();
        if (gooseScript.startGame == true)
        {

            //Animator
            animator.SetFloat("SpeedH", x * speed * Time.deltaTime);
            animator.SetFloat("SpeedV", y * speed * Time.deltaTime);

            if (!firing && Input.GetMouseButtonDown(0))
            {
                firing = true;
                bread.SetActive(true);

            }
            else if (firing && Input.GetMouseButtonUp(0))
            {
                firing = false;
                bread.SetActive(false);
            }
            if (firing)
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 direction = (worldPosition - transform.position).normalized;
                sprite.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
            }
        }
        else
        {
            bread.SetActive(false);
        }
    }
}
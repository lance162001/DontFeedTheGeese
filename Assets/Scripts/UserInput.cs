using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour {
    public float RotationSpeed = 20;
    public float speed;
    bool firing = false;
    public GameObject bread;
    public GameObject sprite;
    public void run(){
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(x,y,0)*speed*Time.deltaTime);
        if (!firing && Input.GetMouseButtonDown(0)){
            firing=true;
            bread.SetActive(true);

        }
        else if (firing && Input.GetMouseButtonUp(0)){
            firing=false;
            bread.SetActive(false);
        }
        if (firing){
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (worldPosition - transform.position).normalized;
            sprite.transform.rotation = Quaternion.LookRotation(Vector3.forward,direction);
        }
    }

    void Start(){
    }
}
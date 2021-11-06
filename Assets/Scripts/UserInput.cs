using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public float speed;
    bool firing = false;
    public void input(){
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(x,y,0)*speed*Time.deltaTime);
        if (!firing && Input.GetMouseButtonDown(0)){
            firing=true;
        }
        if (firing){
            Attack();
        }
    }
    //want to put this into the manager but this is good for a demo
    void Update(){
        input();

    }

    void Attack() {
        //projectiles gotta be made
    }
}
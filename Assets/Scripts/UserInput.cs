using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour {
    public float RotationSpeed = 20;
    public float speed;
    bool firing = false;
    public float fireRate = 1;
    float fireCD = 0;
    public ParticleSystem projectile;
    public GameObject sprite;
    public void input(){
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(x,y,0)*speed*Time.deltaTime);
        if (!firing && Input.GetMouseButtonDown(0)){
            firing=true;
            var e = projectile.emission;
            e.enabled = true;

        }
        else if (firing && Input.GetMouseButtonUp(0)){
            firing=false;
            var e = projectile.emission;
            e.enabled = false;
        }
        if (firing){
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (worldPosition - transform.position).normalized;
            sprite.transform.rotation = Quaternion.LookRotation(Vector3.forward,direction);
        }
    }

    void Start(){
        projectile = GetComponentInChildren<ParticleSystem>();
    }
    //want to put this into the manager but this is good for a demo
    void Update(){
        input();

    }

}
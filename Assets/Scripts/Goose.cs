using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goose : MonoBehaviour
{
    float targetDelay;
    public float viewDistance = 32;
    float targetTimer = 0;
    public float speed;
    Vector3[] targets;
    int targetCount = 0;
    public Manager m;
    public GameObject player;
    public static int geeseFed = 0;
    // Start is called before the first frame update
    void Start()
    {
        targets = new Vector3[3];
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerSprite") { m.hurt(); }
        if (collision.gameObject.name == "Bread") { m.byeGoose(gameObject, this);  geeseFed++;}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerSprite") { m.hurt(); }
        if (collision.gameObject.name == "Bread") { m.byeGoose(gameObject,this); }
    }

    private void Move() {
        if (targetCount != 0) {
            transform.position = Vector3.MoveTowards(transform.position, targets[0], speed*0.01f);
            if (transform.position == targets[0])
            {
                for (int i = 1; i < targetCount; i++)
                {
                    targets[i - 1] = targets[i];
                }
            }
        }
        else
        {
            targets[targetCount]=new Vector3(Random.Range(-10, 10),Random.Range(-10,10));
        }
    }

    void Update()
    {
        Move();
        targetTimer += Time.deltaTime;
        if (targetTimer >= targetDelay)
        {
            targetTimer = 0;
            if (Vector3.Distance(transform.position,player.transform.position) <= viewDistance)
            {
                setTarget(player.transform.position);
            }
        }
    }

    public void setTarget(Vector3 t) {
        if (targets.Length == targetCount) {
            targetCount--;
            for (int i = 1; i < targetCount; i++) {
                targets[i - 1] = targets[i];
            }
        }
        targetDelay = Random.Range(1, 2);
        speed = Random.Range(1, 4);
        targets[targetCount] = t;
        if (targetCount < targets.Length) { targetCount++; }
    }
}

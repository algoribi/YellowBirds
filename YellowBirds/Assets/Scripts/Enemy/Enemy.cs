using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health = 50.0f;
    public float Speed = 1000f;

    public float Health {
        get { return health; }
    }

    void TakeDamage(int value) {
        health -= value;
        Debug.Log("enemy의 체력 : " + health);

        if (health <= 0) 
            Die();
    }

    void TakeDamage(float value) {
        health -= (health * value);
        Debug.Log("enemy의 체력 : " + health);

        if (health <= 0) 
            Die();
    }

    void Die() {
        EventManager.RunEnemyDieEvent();
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.CompareTag("Bullet")) {
            TakeDamage(10);
            coll.gameObject.SetActive(false);
        }
    }

    public virtual void Move() {}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

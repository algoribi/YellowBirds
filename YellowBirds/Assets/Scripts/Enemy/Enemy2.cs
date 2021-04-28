using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    public override void Move() {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Speed);
    }
}

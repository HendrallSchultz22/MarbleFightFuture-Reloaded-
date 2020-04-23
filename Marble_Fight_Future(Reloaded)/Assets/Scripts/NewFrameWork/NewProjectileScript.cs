using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class NewProjectileScript : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public float LifeTime = 2f;
    Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.velocity = transform.forward * MoveSpeed;
    }
    void Update()
    {
        Lifetime();
    }
    void FixedUpdate()
    {
       rb.velocity = transform.forward * MoveSpeed;
    }
    void OnCollisionEnter(Collision collision)
    {
        NewEnemyScript TETS = collision.collider.gameObject.GetComponentInParent<NewEnemyScript>();
        if (TETS)
        {
            TETS.ShotReset();
            Destroy(gameObject);
        }    
    }
    void Lifetime()
    {
        Destroy(gameObject, LifeTime);
    }
}

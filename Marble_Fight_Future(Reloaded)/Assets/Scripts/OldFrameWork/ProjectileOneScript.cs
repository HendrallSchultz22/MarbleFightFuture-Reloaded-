using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileOneScript : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float LifeTime = 10f;
    Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.velocity = transform.forward * MoveSpeed;
        Lifetime();
    }
    void FixedUpdate()
    {
        rb.velocity = transform.forward * MoveSpeed;
    }
    void OnCollisionEnter(Collision collision)
    {
        EnemyTrailerOneScript TETS = collision.collider.gameObject.GetComponentInParent<EnemyTrailerOneScript>();
        if (TETS)
        {
            TETS.ShotReset();
        }
    }
    void Lifetime()
    {
        Destroy(gameObject, LifeTime);
    }
}

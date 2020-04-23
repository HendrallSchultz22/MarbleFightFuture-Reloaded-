using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class MoveMentScript : MonoBehaviour
{    
    Vector3 Startingpos;
    Quaternion Startingrot;
    bool Fire1isEnabled = true;
    private float speed = 8f;
    private float jumpForce = 4f;
    private float gravity = 10f;  
    private Vector3 moveDir = Vector3.zero;
    public GameObject SpawnLocation;
    public GameObject SpawnPrefab;
    Rigidbody rb;
    void Start()
    {        
        rb = gameObject.GetComponent<Rigidbody>();
        Startingpos = gameObject.transform.position;
        Startingrot = gameObject.transform.rotation;
    }
    void Update()
    {
        CharacterController controller = gameObject.GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDir = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);          
            moveDir *= speed;
            if (Input.GetButtonDown("Jump"))
            {
                moveDir.y = jumpForce;
            }
        }
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * 3f, 0);
        bool fire1 = Input.GetButtonDown("Fire1");
        if (fire1)
        {
          Fire1();          
        }    
    }
    public void Fire1()
    {
        if (Fire1isEnabled)
        {
            ProjectileFire1();
        }
    }
    public void ProjectileFire1()
    {
        GameObject newObject = Instantiate(SpawnPrefab, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
    }
    public void ShotReset()
    {
        gameObject.transform.position = Startingpos;
        gameObject.transform.rotation = Startingrot;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}

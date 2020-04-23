using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class NewMovement : MonoBehaviour
{
    private Player1 Controls = null;

    float movementSpeed = 5f;

    Vector2 Moveet;
    Rigidbody rb;
    Gamepad P1;

    public float jumpForce = 300f;
    public bool isGrounded;

    public GameObject SpawnLocation1;
    public GameObject SpawnLocation2;
    public GameObject SpawnLocation3;
    public GameObject SpawnLocation4;
    public GameObject SpawnLocation5;
    public GameObject SpawnLocation6;
    public GameObject SpawnLocation7;
    public GameObject SpawnLocation8;
    public GameObject SpawnLocation9;
    public GameObject SpawnLocation10;
    public GameObject SpawnLocation11;
    public GameObject SpawnLocation12;
  


    public GameObject SpawnPrefab;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Controls = new Player1();
        
    }

  
    void Update()
    {
        Move();
        Gamepad[] pads = Gamepad.all.ToArray();
        if (pads.Length < 1)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                AntiEnemy();
            }
            if (isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
            }
        }
        else
        {
            P1 = pads[0];
            if (P1.buttonWest.wasPressedThisFrame)
            {
                AntiEnemy();
            }
            if (isGrounded)
            {
                if (P1.buttonSouth.wasPressedThisFrame)
                {
                    Jump();
                }
            }
           
        }
        
    }

    public void Move()
    {
        Vector3 movement = new Vector3(Moveet.x, 0, Moveet.y) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
    public void OnMove(InputValue value)
    {
        Moveet = value.Get<Vector2>();
    }
    
    public void Jump()
    {
        rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }  
    }
    public void AntiEnemy()
    {
        GameObject Blast1 = Instantiate(SpawnPrefab, SpawnLocation1.transform.position, SpawnLocation1.transform.rotation);
        GameObject Blast2 = Instantiate(SpawnPrefab, SpawnLocation2.transform.position, SpawnLocation2.transform.rotation);
        GameObject Blast3 = Instantiate(SpawnPrefab, SpawnLocation3.transform.position, SpawnLocation3.transform.rotation);
        GameObject Blast4 = Instantiate(SpawnPrefab, SpawnLocation4.transform.position, SpawnLocation4.transform.rotation);
        GameObject Blast5 = Instantiate(SpawnPrefab, SpawnLocation5.transform.position, SpawnLocation5.transform.rotation);
        GameObject Blast6 = Instantiate(SpawnPrefab, SpawnLocation6.transform.position, SpawnLocation6.transform.rotation);
        GameObject Blast7 = Instantiate(SpawnPrefab, SpawnLocation7.transform.position, SpawnLocation7.transform.rotation);
        GameObject Blast8 = Instantiate(SpawnPrefab, SpawnLocation8.transform.position, SpawnLocation8.transform.rotation);
        GameObject Blast9 = Instantiate(SpawnPrefab, SpawnLocation9.transform.position, SpawnLocation9.transform.rotation);
        GameObject Blast10 = Instantiate(SpawnPrefab, SpawnLocation10.transform.position, SpawnLocation10.transform.rotation);
        GameObject Blast11 = Instantiate(SpawnPrefab, SpawnLocation11.transform.position, SpawnLocation11.transform.rotation);
        GameObject Blast12 = Instantiate(SpawnPrefab, SpawnLocation12.transform.position, SpawnLocation12.transform.rotation);
        
    }
}


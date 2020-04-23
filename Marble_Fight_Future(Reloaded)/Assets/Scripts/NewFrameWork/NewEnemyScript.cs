using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class NewEnemyScript : MonoBehaviour
{
    Vector3 Startingpos;
    Quaternion Startingrot;
    Transform trans;
    public CanvasControl Control;
    public List<GameObject> PathList;
    public int PathListIndex = 0;
    public GameObject CurrentTarget;
    public float MovementSpeed = 4.0f;
    public Vector3 MoveDirection;
    public bool HasDynamicDirection;
    public bool IsE1;
    public bool IsE2;
    public bool IsE3;
    public bool IsE4;


    void Start()
    {
        
        trans = gameObject.transform;
        Startingpos = gameObject.transform.position;
        Startingrot = gameObject.transform.rotation;
        UpdateMoveDirection();
        HasDynamicDirection = true;
    }
    void Update()
    {
        Vector3 location = trans.position;
        if (HasDynamicDirection)
        {
            UpdateMoveDirection();
        }
        location += (MoveDirection * MovementSpeed * Time.deltaTime);
        if (IsClosetoTarget())
        {
            UpdateMoveDirection();
        }
        trans.position = location;
    }
    public float GetDistanceTo(GameObject Other)
    {
        float dist = Vector3.Distance(Other.transform.position, transform.position);
        return dist;
    }
    public bool IsClosetoTarget()
    {
        if (GetDistanceTo(CurrentTarget) <= MovementSpeed * Time.deltaTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void UpdateMoveDirection()
    {
        MoveDirection = (CurrentTarget.transform.position - transform.position);
        MoveDirection = MoveDirection.normalized;
    }
    void OnCollisionEnter(Collision collision)
    {
        NewMovement mms = collision.collider.gameObject.GetComponentInParent<NewMovement>();
        if (mms)
        {
            Control.UI.SetActive(false);
            Control.Loss.SetActive(true);
            Destroy(collision.gameObject.GetComponentInChildren<NewCameraScript>());
            Destroy(collision.gameObject.GetComponent<PlayerInput>());
            Destroy(collision.gameObject.GetComponentInParent<NewMovement>());
           
            Debug.Log("Hitting!!");
        }
        
    }
    
    
    public void ShotReset()
    {
        gameObject.transform.position = Startingpos;
        gameObject.transform.rotation = Startingrot;
        if (IsE1)
        {
            MovementSpeed += 2.0f;
        }
        if (IsE2)
        {
            MovementSpeed += 2.0f;
        }
        if (IsE3)
        {
            MovementSpeed += 2.0f;
        }
        if (IsE4)
        {
            MovementSpeed += 2.0f;
        }


    }
}

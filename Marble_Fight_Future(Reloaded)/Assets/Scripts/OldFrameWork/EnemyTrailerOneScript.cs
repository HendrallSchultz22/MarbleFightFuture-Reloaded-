using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class EnemyTrailerOneScript : MonoBehaviour
{
    Vector3 Startingpos;
    Quaternion Startingrot;
    string MainMenuScene = "Main Menu";
    Transform trans;
    public List<GameObject> PathList;
    public int PathListIndex = 0;
    public GameObject CurrentTarget;
    public static float MovementSpeed = 5.0f;
    public Vector3 MoveDirection;
    public bool HasDynamicDirection;
    Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
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
        MoveMentScript mms = collision.collider.gameObject.GetComponentInParent<MoveMentScript>();
        if (mms)
        {
            SceneManager.LoadScene(MainMenuScene);
        }
        GoalOneScript.GateOneCount = 0;
    }
    public void ShotReset()
    {
        gameObject.transform.position = Startingpos;
        gameObject.transform.rotation = Startingrot;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        MovementSpeed += 5.0f;
    }
}

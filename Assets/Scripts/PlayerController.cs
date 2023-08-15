using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rigidBody;
    public float moveSpeed = 300;
    private float moveX;
    private float moveY;

    // Default Score

    // Delegate
    public delegate void OnIncrementScore();
    public static OnIncrementScore onIncrementScore;

    public delegate void OnHitTheWall();
    public static OnHitTheWall onHitTheWall;


    public delegate void OnPickupItem();
    public static OnPickupItem onPickupItem;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        moveSpeed = 300;
    }

    private void OnMove(InputValue input)
    {
        Vector2 movVector = input.Get<Vector2>();
        moveX = movVector.x;
        moveY = movVector.y;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(Vector3.up, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Vector3 vector3 = new Vector3(moveX, 0, moveY);
        rigidBody.AddForce(vector3 * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickableItem")
        {
            Destroy(other.gameObject);
            //other.gameObject.SetActive(false);
            onIncrementScore?.Invoke();
            onPickupItem?.Invoke();
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Hit the wall");
            onHitTheWall?.Invoke();
        }
    }

}

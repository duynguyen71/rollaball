using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public float moveSpeed = 1;
    private float moveX;
    private float moveY;

    // Default Score
    private int score = 0;

    // UI Text
    public TextMeshProUGUI scoreText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 2;
        score = 0;
    }

    private void OnMove(InputValue input)
    {
        Vector2 movVector = input.Get<Vector2>();
        moveX = movVector.x;
        moveY = movVector.y;
    }

    private void OnFire(InputValue input){
        Debug.Log("On Fire");
    } 

    private void FixedUpdate()
    {
        Vector3 vector3 = new Vector3(moveX, 0, moveY);
        rb.AddForce(vector3 * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickableItem")
        {
            other.gameObject.SetActive(false);
            score += 10;
            scoreText.text = "Score: " + score.ToString();
        }
    }


}

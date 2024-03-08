using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public float movementSpeed = 10f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;

    private float speedIncrease = 2F;

    private float score = 0;
    public float distanceMoved;

    public GameObject menu2;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed * horizontalInput);

        speedIncrease += 0.005F;
        transform.Translate(Vector3.down * Time.deltaTime * speedIncrease);

        score = playerRb.velocity.magnitude;
        Debug.Log(score);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("Road_Block"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
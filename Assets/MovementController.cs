﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("Mouse Looking / Camera Rotation")]
    public Transform playerCamera ;  // Find the camera that the local player is using.
    public Transform orientation; // Used to find local orientation of the player.
    [SerializeField] private Vector2 mouseSensitivity = new Vector2(70f, 70f); // The Sensitivity of the Mouse (Which makes the Camera move). 
    [SerializeField] private float maxMouseRotationUp = 90f; // Maximum Upward Rotation of the Camera. 
    [SerializeField] private float maxMouseRotationDown = 90f; // Maximum Downward Rotation of the Camera. 
    public float xLocalRotation = 0f; // Local Player X Rotation 
    private float speed = 5f;
    public Rigidbody rigidbody;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerCamera = GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject Bulett = Instantiate(Bullet, this.transform.position*1.1f, Quaternion.identity);
            Bulett.GetComponent<Transform>().GetComponent<Bullet>().orientaion = orientation;
        }
                float move = Input.GetAxis("Vertical")*speed;
                rigidbody.velocity = orientation.forward*move;

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity.x * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity.y * Time.deltaTime;
        
            xLocalRotation -= mouseX;
            xLocalRotation = Mathf.Clamp(xLocalRotation, -maxMouseRotationUp, maxMouseRotationDown);

            
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * 200f, Color.green);

           
            playerCamera.transform.localRotation = Quaternion.Euler(0f,xLocalRotation, 0f);

            
            transform.Rotate(Vector3.up *mouseX);
         



    }
}

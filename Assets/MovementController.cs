using System.Collections;
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
    public Vector3 bulletOffset;
    private float speed = 0.5f;
    //public Rigidbody rigidbody;
    public GameObject Bullet;
    public GameObject PaintBullet;
    public GameColor BulletColor = GameColor.Red;
    private CharacterStats characterStats;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = GetComponent<Rigidbody>();
        playerCamera = GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
        bulletOffset = new Vector3(-1f, 2f, 1f);
        characterStats = GetComponent<CharacterStats>();
    }


    private void Update()
    {
        if (Input.GetButtonDown("Red"))
            BulletColor = GameColor.Red;
        if (Input.GetButtonDown("Blue"))
            BulletColor = GameColor.Blue;
        if (Input.GetButtonDown("Yellow"))
            BulletColor = GameColor.Yellow;

        Vector3 Spawnpoint = transform.position + transform.TransformDirection(bulletOffset);

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject BulletObj = Instantiate(Bullet, Spawnpoint, Quaternion.identity);
            BulletObj.GetComponent<Transform>().GetComponent<Bullet>().direction = orientation.forward;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject BulletObj = Instantiate(PaintBullet, Spawnpoint, Quaternion.identity);
            var bullet = BulletObj.GetComponent<Transform>().GetComponent<PaintBullet>();
            bullet.orientaion = orientation;
            bullet.color = BulletColor;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*float move = Input.GetAxis("Vertical")*speed;
        //rigidbody.velocity = orientation.forward*move;
        rigidbody.AddForce(orientation.forward * move, ForceMode.VelocityChange);
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, 1.5f);
        Debug.Log(rigidbody.velocity);*/

        float move = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal") * speed;
        transform.position += orientation.forward * move + orientation.right * strafe;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity.x * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity.y * Time.deltaTime;
        xLocalRotation += mouseX;
        // xLocalRotation = Mathf.Clamp(xLocalRotation, -maxMouseRotationUp, maxMouseRotationDown);
            
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * 200f, Color.green);
        playerCamera.transform.localRotation = Quaternion.Euler(0f,xLocalRotation, 0f);
        transform.Rotate(Vector3.up *mouseX);
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.CompareTag("Attack"))
        {
           characterStats.TakeDamage(collision.transform.gameObject.GetComponent<Bullet>().damage);
        }
    }
}

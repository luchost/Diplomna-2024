using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MovementController : MonoBehaviour
{
    [Header("Mouse Looking / Camera Rotation")]
    public Transform orientation; // Used to find local orientation of the player.
    public Vector2 mouseSensitivity = new Vector2(70f, 70f); // The Sensitivity of the Mouse (Which makes the Camera move). 
    public float maxMouseRotationUp = 45f; // Maximum Upward Rotation of the Camera. 
    public float maxMouseRotationDown = 45f; // Maximum Downward Rotation of the Camera. 
    public float xLocalRotation = 0f; // Local Player X Rotation 
    public float yLocalRotation = 0f; // Local Player X Rotation 
    public Vector3 bulletOffset;
    private float speed = 0.2f;
    public GameObject Bullet;
    public GameObject PaintBullet;
    public GameColor BulletColor = GameColor.Red;
    private CharacterStats characterStats;
    public int redBullets;
    public int blueBullets;
    public int yellowBullets;
    public Text redText;
    public Text blueText;
    public Text yellowText;
    public Image red;
    public Image blue;
    public Image yellow;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        bulletOffset = new Vector3(-1f, 2f, 1f);
        characterStats = GetComponent<CharacterStats>();
        redText.text = redBullets.ToString();
        blueText.text = blueBullets.ToString();
        yellowText.text = yellowBullets.ToString();
        blue.color = Color.magenta;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Red") && redBullets > 0)
        {
            BulletColor = GameColor.Red;
            red.color = Color.magenta;
            blue.color = Color.black;
            yellow.color = Color.black;
        }
        if (Input.GetButtonDown("Blue") && blueBullets > 0)
        {
            BulletColor = GameColor.Blue;
            blue.color = Color.magenta;
            red.color = Color.black;
            yellow.color = Color.black;
        }
        if (Input.GetButtonDown("Yellow") && yellowBullets > 0)
        {
            BulletColor = GameColor.Yellow;
            yellow.color = Color.magenta;
            blue.color = Color.black;
            red.color = Color.black;
        }
        if (BulletColor == GameColor.Red && redBullets == 0)
        { 
            BulletColor = GameColor.Blue;
            blue.color = Color.magenta;
            red.color = Color.black;
            yellow.color = Color.black;
        }
        if (BulletColor == GameColor.Blue && blueBullets == 0)
        {
            BulletColor = GameColor.Yellow;
            blue.color = Color.black;
            red.color = Color.black;
            yellow.color = Color.magenta;
        }

        if (BulletColor == GameColor.Yellow && yellowBullets == 0)
        {
            BulletColor = GameColor.Red;
            blue.color = Color.black;
            red.color = Color.magenta;
            yellow.color = Color.black;
        }

        if (redBullets == 0 && blueBullets == 0 && yellowBullets == 0)
        {
            BulletColor = GameColor.None;
            blue.color = Color.black;
            red.color = Color.black;
            yellow.color = Color.black;
        }

        Vector3 Spawnpoint = transform.position + transform.TransformDirection(bulletOffset);

        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time >= nextFire)
            {
                GameObject BulletObj = Instantiate(Bullet, Spawnpoint, Quaternion.identity);
                BulletObj.GetComponent<Transform>().GetComponent<Bullet>().direction = orientation.forward;
                nextFire = Time.time + fireRate;
            }
            if (HelpPopUps.Instance.tutorialId == 2)
            {
                HelpPopUps.Instance.tutorialId = 0;
                StartCoroutine(StartPaintTutorial());
            }
        }
        if (Input.GetButtonDown("Fire2") && BulletColor != GameColor.None)
        {
            GameObject BulletObj = Instantiate(PaintBullet, Spawnpoint, Quaternion.identity);
            var bullet = BulletObj.GetComponent<Transform>().GetComponent<PaintBullet>();
            var bulletColor = BulletObj.GetComponent<Transform>().GetComponent<MeshRenderer>();
            bullet.orientaion = orientation;
            bullet.color = BulletColor;
            switch (BulletColor)
            {
                case GameColor.Red:
                    bulletColor.material.color = Color.red;
                    redBullets -= 1;
                    redText.text = redBullets.ToString();
                    break;
                case GameColor.Blue:
                    bulletColor.material.color = Color.blue;
                    blueBullets -= 1;
                    blueText.text = blueBullets.ToString();
                    break;
                case GameColor.Yellow:
                    bulletColor.material.color = Color.yellow;
                    yellowBullets -= 1;
                    yellowText.text = yellowBullets.ToString();
                    break;
            }

            if (HelpPopUps.Instance.tutorialId == 3)
            {
                HelpPopUps.Instance.tutorialId = 0;
                StartCoroutine(StopTutorial());
            }
        }
    }

    static Vector3 verticalOrigin = new Vector3(0, 100f, 0);
    static Vector3 verticalDirection = new Vector3(0, -200f, 0);
    static float zOffset = -0.1f;

    // Update is called once per frame
    void FixedUpdate()
    {
       
        RaycastHit hitInfo;

        float move = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal") * speed;
        var velocity = orientation.forward * move + orientation.right * strafe;
        if (Physics.SphereCast(transform.position - velocity, 1.5f, velocity, out hitInfo, velocity.magnitude * 2, ~LayerMask.GetMask("Terrain")))
        {
            // collide and slide
            var truncatedVelocity = velocity.normalized * (hitInfo.distance - velocity.magnitude);
            var leftover = velocity - truncatedVelocity;
            var normal2d = new Vector3(hitInfo.normal.x, 0, hitInfo.normal.z);
            leftover = Vector3.ProjectOnPlane(leftover, normal2d);
            Debug.DrawRay(hitInfo.point, leftover, Color.green);
            velocity = truncatedVelocity + leftover;
        }
        transform.position += velocity;

        if (HelpPopUps.Instance.tutorialId == 1 && (move > 0.001f || strafe > 0.001f))
        {
            HelpPopUps.Instance.tutorialId = 0;
            StartCoroutine(StartShootTutorial());
        }

        LayerMask mask = LayerMask.GetMask("Terrain");
        if (Physics.Raycast(transform.position + verticalOrigin, verticalDirection, out hitInfo, Mathf.Infinity, mask))
            transform.position = new Vector3(transform.position.x, hitInfo.point.y + zOffset, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x, zOffset, transform.position.z);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity.x * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity.y * Time.deltaTime;
        xLocalRotation += mouseX;
        yLocalRotation += mouseY;
        yLocalRotation = Mathf.Clamp(yLocalRotation, -maxMouseRotationUp, maxMouseRotationDown);

        //Debug.DrawRay(transform.position, transform.forward * 200f, Color.green);
        transform.localRotation = Quaternion.Euler(0f, xLocalRotation, 0f);
        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(-yLocalRotation, 0f, 0f);
    }
    IEnumerator StartShootTutorial()
    {
        yield return new WaitForSeconds(2f);
        HelpPopUps.Instance.TutorialSetText(0, "");
        yield return new WaitForSeconds(1f);
        HelpPopUps.Instance.TutorialSetText(2, "Press the left mouse button to shoot.");
    }
    IEnumerator StartPaintTutorial()
    {
        yield return new WaitForSeconds(2f);
        HelpPopUps.Instance.TutorialSetText(0, "");
        yield return new WaitForSeconds(1f);
        HelpPopUps.Instance.TutorialSetText(3, "Press 1, 2 or 3 to change the active color, then the right mouse button to throw paint.");
    }
    IEnumerator StopTutorial()
    {
        yield return new WaitForSeconds(2f);
        HelpPopUps.Instance.TutorialSetText(0, "");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.CompareTag("Attack"))
        {
           characterStats.TakeDamage(collision.transform.gameObject.GetComponent<Bullet>().damage);
        }
    }
   
}

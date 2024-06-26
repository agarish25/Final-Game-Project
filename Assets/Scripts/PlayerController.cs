using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    KeyCode up;
    [SerializeField]
    KeyCode left;
    [SerializeField]
    KeyCode right;
    [SerializeField]
    KeyCode down;
    [SerializeField]
    KeyCode e;
    [SerializeField]
    KeyCode q;
    [SerializeField]
    KeyCode r;
    [SerializeField]
    KeyCode t;

    [SerializeField]
    float jumpForce;
    [SerializeField]
    float speed;
    [SerializeField]
    float dashSpeed;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    public bool doubleJumpActive;
    [SerializeField]
    public bool dashActive;
    [SerializeField]
    public bool chargeJumpActive;
    [SerializeField]
    public bool grapplerActive;
    [SerializeField]
    public bool healthGemActive;

    [SerializeField]
    public PlayerHealthManager PlayerHealthManager;
    [SerializeField]
    public KeyController KeyController;

    public GameObject grappler;
    public GrappleHook GrappleHook;
    bool grapplerStick;

    public float xSpawn;
    public float ySpawn;
    public bool direction;
    public int deaths;

    public float timeHeld;
    public float grapplerSpeed;
    public float grapplerVert;
    public float translatedDistanceUp;
    public float translate;
    public bool isOnGround;
    public bool doubleJump;
    int isDashing;
    int dashTimer;
    public int dashCool;
    int i = 0;
    Color dashColor;
    TrailRenderer myTrail;

    private float coins;

    // Start is called before the first frame update
    void Start()
    {
        GrappleHook = grappler.GetComponent<GrappleHook>();
        myTrail = gameObject.GetComponent<TrailRenderer>();
        direction = true;
        xSpawn = 0;
        ySpawn = 0;
        doubleJump = false;
        isDashing = 0;
        timeHeld = 0;
        dashTimer = 0;
        dashCool = 100;
        deaths = 0;
        translate = 0;
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.position = new Vector2(-2.35f, 0);
        }
        this.grapplerStick = GrappleHook.grapplerStick;
        if (grapplerStick)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        if (GetComponent<Rigidbody2D>().velocity.magnitude > maxSpeed)
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * maxSpeed;
        }
        if (Input.GetKey(r))
        {
            transform.position = new Vector2(xSpawn, ySpawn);
        }
        if (transform.position.y < -30)
        {
            transform.position = new Vector2(xSpawn, ySpawn);
            deaths++;
            PlayerHealthManager.healthAmount = 100;
        }
        if (isDashing == 0)
        {
            if (chargeJumpActive)
            {
                if (Input.GetKey(up) && isOnGround)
                    timeHeld += Time.deltaTime;
            }
            if (!grapplerStick) { 
                if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce * 0.5f, ForceMode2D.Impulse);
                }
                else if (Input.GetKeyUp(up) && (isOnGround))
                {
                    if (timeHeld > 0.9)
                        timeHeld = 0.9f;
                    if (timeHeld < 0.5)
                        timeHeld = 0.5f;
                    GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce * timeHeld, ForceMode2D.Impulse);
                    timeHeld = 0;
                }
                else if (!isOnGround)
                {
                    timeHeld = 0;
                }
                if (Input.GetKeyDown(up) && (doubleJump))
                {
                    GetComponent<Rigidbody2D>().velocity *= 0.1f;
                    GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce * 0.6f, ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
            if (grapplerStick && Input.GetKey(up))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.005f);
            }
            if (grapplerStick && Input.GetKey(down))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.005f);
            }
            if (dashActive)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    isDashing = 2;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    isDashing = 1;
                }
            }
        }
        if (isDashing != 0)
        {
            dashColor = new Color(100, 100, 0);
            myTrail.startColor = dashColor;
        }
        else
        {
            dashColor = new Color(255, 255, 255);
            myTrail.startColor = dashColor;
        }
    }

    private void FixedUpdate()
    {
        if (healthGemActive && PlayerHealthManager.healthAmount < 100)
        {
            PlayerHealthManager.healthAmount += 0.01f;
        }
        if (dashActive)
        {
            dashCool++;
            if (dashCool < 100)
            {
                isDashing = 0;
            }
            if (dashCool > 100)
            {
                dashCool = 100;
            }
        }
            if (isDashing == 0)
            {
                if (Input.GetKey(left) && !grapplerStick)
                {
                    direction = false;
                    transform.Translate(Vector2.left * speed);
                }
                if (Input.GetKey(right) && !grapplerStick)
                {
                    direction = true;
                    transform.Translate(Vector2.right * speed);
                }
                if (Input.GetKey(left) && grapplerStick)
                {
                    if (transform.position.x <= GrappleHook.transform.position.x)
                    {
                    transform.Translate(Vector2.left * grapplerSpeed * ((GrappleHook.transform.position.y - transform.position.y) - Mathf.Abs(GrappleHook.transform.position.x - transform.position.x)) * 0.3f);
                    transform.Translate(Vector2.up * grapplerVert * (GrappleHook.transform.position.y - transform.position.y) * 0.03f);
                    }
                    else
                    {
                        transform.Translate(Vector2.left * grapplerSpeed * ((GrappleHook.transform.position.y - transform.position.y) - Mathf.Abs(GrappleHook.transform.position.x - transform.position.x)) * 0.5f);
                        transform.Translate(Vector2.down * grapplerVert * (GrappleHook.transform.position.y - transform.position.y) * 0.05f);
                    }
                    if (Mathf.Abs(GrappleHook.transform.position.x - transform.position.x) > GrappleHook.transform.position.y - transform.position.y)
                    {
                        transform.Translate(Vector2.right * grapplerSpeed * ((GrappleHook.transform.position.y - transform.position.y) - Mathf.Abs(GrappleHook.transform.position.x - transform.position.x)) * 0.3f);
                        transform.Translate(Vector2.down * grapplerVert * (GrappleHook.transform.position.y - transform.position.y) * 0.03f);
                    }
                }
                else if (Input.GetKey(right) && grapplerStick)
                {
                    if (transform.position.x >= GrappleHook.transform.position.x)
                    {
                        transform.Translate(Vector2.right * grapplerSpeed * ((GrappleHook.transform.position.y - transform.position.y) - Mathf.Abs(GrappleHook.transform.position.x - transform.position.x)) * 0.3f);
                        transform.Translate(Vector2.up * grapplerVert * (GrappleHook.transform.position.y - transform.position.y) * 0.03f);
                    }
                    else
                    {
                        transform.Translate(Vector2.right * grapplerSpeed * ((GrappleHook.transform.position.y - transform.position.y) - Mathf.Abs(GrappleHook.transform.position.x - transform.position.x)) * 0.5f);
                        transform.Translate(Vector2.down * grapplerVert * (GrappleHook.transform.position.y - transform.position.y) * 0.05f);
                    }
                    if (Mathf.Abs(GrappleHook.transform.position.x - transform.position.x) > GrappleHook.transform.position.y - transform.position.y)
                    {
                        transform.Translate(Vector2.left * grapplerSpeed * ((GrappleHook.transform.position.y - transform.position.y) - Mathf.Abs(GrappleHook.transform.position.x - transform.position.x)) * 0.3f);
                        transform.Translate(Vector2.down * grapplerVert * (GrappleHook.transform.position.y - transform.position.y) * 0.03f);
                    }
                }
                else if (grapplerStick)
                {
                    if (transform.position.x > GrappleHook.transform.position.x + 0.04)
                    {
                        transform.Translate(Vector2.left * grapplerSpeed * Mathf.Abs((GrappleHook.transform.position.y - transform.position.y) - Mathf.Abs(GrappleHook.transform.position.x - transform.position.x)) * 0.3f);
                        transform.Translate(Vector2.down * grapplerVert * (GrappleHook.transform.position.y - transform.position.y) * 0.03f);
                    }
                    else if (transform.position.x < GrappleHook.transform.position.x - 0.04)
                    {
                        transform.Translate(Vector2.right * grapplerSpeed * Mathf.Abs((GrappleHook.transform.position.y - transform.position.y) - Mathf.Abs(GrappleHook.transform.position.x - transform.position.x)) * 0.3f);
                        transform.Translate(Vector2.down * grapplerVert * (GrappleHook.transform.position.y - transform.position.y) * 0.03f);
                    }
                }
            }
            else if (isDashing == 1)
            {
                dashTimer++;

                transform.Translate(Vector2.left * dashSpeed);
                if (dashTimer > 8)
                {
                    isDashing = 0;
                    dashTimer = 0;
                    dashCool = 0;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
            }
            else
            {
                dashTimer++;
                transform.Translate(Vector2.right * dashSpeed);
                if (dashTimer > 8)
                {
                    isDashing = 0;
                    dashTimer = 0;
                    dashCool = 0;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerHealthManager.healthAmount -= 10;
        }
        if (collision.gameObject.CompareTag("Deathbarrier"))
        {
            transform.position = new Vector2(xSpawn, ySpawn);
            deaths++;
        }
        if (collision.gameObject.CompareTag("Grappler"))
        {
            GrappleHook.grapplerEnabled = true;
        }

        if (collision.gameObject.CompareTag("Door") && KeyController.hasKey)
        {
            StartCoroutine(DoorCountdownRoutine(collision));
            translate = 0;
        }

        if (collision.gameObject.CompareTag("Coin")) {
            Destroy(collision.gameObject);
            coins++;
        }

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            PlayerHealthManager.healthAmount -= 20;
        }
    }

    IEnumerator DoorCountdownRoutine(Collision2D collision)
    {
        
        if (translate < 45)
        {
            translate++;
            translatedDistanceUp += 50f;
            collision.transform.Translate(Vector2.up * translatedDistanceUp * Time.deltaTime);
        }
        yield return new WaitForSeconds(1);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // if (collision.gameObject.CompareTag("Checkpoint"))
        // {
        //     isOnGround = false;
        //     if (doubleJumpActive)
        //         doubleJump = true;
        // }
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        // if (collide.gameObject.CompareTag("Slowzone"))
        // {
        //     speed *= 0.5f;
        // }
        // if (collide.gameObject.CompareTag("Speedzone"))
        // {
        //     speed *= 2;
        // }
    }

    private void OnTriggerExit2D(Collider2D collide)
    {
        // if (collide.gameObject.CompareTag("Slowzone"))
        // {
        //     speed *= 2;
        // }
        // if (collide.gameObject.CompareTag("Speedzone"))
        // {
        //     speed *= 0.5f;
        // }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerHealthManager.healthAmount -= 0.2f;
        }
        // if (collision.gameObject.CompareTag("Checkpoint"))
        // {
        //     isOnGround = true;
        //     doubleJump = false;
        // }
    }
}

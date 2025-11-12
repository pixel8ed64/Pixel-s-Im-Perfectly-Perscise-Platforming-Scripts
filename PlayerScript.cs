using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    //Declaration of Variablependance
    private Rigidbody2D myRigidbody;
    public Animator myAnimator;
    public float movementSpeed;
    public bool facingRight;
    public Vector3 theScale;
    [SerializeField]
    private Transform[] groundPoints;
    [SerializeField]
    private float groundRadius;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGrounded;
    private bool jump;
    [SerializeField]
    private float jumpForce;
    private bool imAlive;
    public GameObject reset;
    private Slider healthBar;
    public float health = 10f;
    private float healthBurn = 5f;

    //soy vive. adios con son idfk my spanish words uh continue looking at the code. yes. YOU. dataminer.
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        imAlive = true;
        reset.SetActive(false);
        healthBar = GameObject.Find("health slider").GetComponent<Slider>();
        healthBar.minValue = 0f;
        healthBar.maxValue = health;
        healthBar.value = healthBar.maxValue;
    }   

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Debug.Log(horizontal);
        if (imAlive)
        {
            HandleMovement(horizontal);
            Flip(horizontal);
        }
        else
        {
            return;
        }

        isGrounded = IsGrounded();

    }

    //FUNCTION DEFINITION: IDK YOU TELL ME
    private void HandleMovement(float horizontal)

    {
        myRigidbody.linearVelocity = new Vector2(horizontal*movementSpeed, myRigidbody.linearVelocity.y);
        myAnimator.SetFloat("Speed",Mathf.Abs(horizontal));
        if (isGrounded && jump) 
        { 
            isGrounded = false;
            jump = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump");
            jump = true;
            myAnimator.SetBool("jumping", true);
        }
    }


    private void Flip(float horizontal)
    {
        if (horizontal<0 && !facingRight || horizontal>0 && facingRight)
        {
            facingRight = !facingRight;
            theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private bool IsGrounded()
    {
        if (myRigidbody.linearVelocity.y <= 0)
        {
            //if player is not moving vertically, test each of Player's groundPoints for collision with Ground
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; 1 < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;

                    }
                }
            }
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground")
        {
            myAnimator.SetBool("jumping", false);
        }
        if (target.gameObject.tag == "deadly")
        {
            myAnimator.SetBool("dead", true);
            imAlive = false;
            reset.SetActive(false);
        }

        if (target.gameObject.tag == "damage")
        {
            UpdateHealth();
        }
    }

    void UpdateHealth()
    {
        if (health > 0)
        {
            health -= healthBurn;
            healthBar.value = health;
        }
        if (health <= 0)
        {
            ImDead();
        }
    }

    void ImDead()
    {
        myAnimator.SetBool("dead", true);
        imAlive = false;
        reset.SetActive(true);
        healthBar.value = 0;
    }
}

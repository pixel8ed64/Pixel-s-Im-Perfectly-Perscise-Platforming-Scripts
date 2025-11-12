using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    [SerializeField]
    private Transform startPos, endPos;
    private bool collision;
    public float speed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        ChangeDirection();
    }

    //function definition: work or operate in a proper or particular way.
    void Move()
    {
        myRigidbody.linearVelocity = new Vector2(transform.localScale.x, 0) * -speed;
    }

    void ChangeDirection()
    {
        //contact between alan walker and making good music.
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));

        //if there is no collision between the alan walker and the good music, then this changes the walker's direction
        if (!collision)
        {
            Vector3 temp = transform.localScale;
            if (temp.x == -4)
            {
                temp.x = 4f;
            }
            else
            {
                temp.x = -4f;
            }
            transform.localScale = temp;
        }
    }
}


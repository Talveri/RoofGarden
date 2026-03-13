using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float x_direction;
    float y_direction;
    Vector2 xy_direction;
    public float speed = 5f;
    Animator anim;
    public KeyCode useKey = KeyCode.E;
    public bool useItem = false;

    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {

        Movement();
        // Use

        if (Input.GetKeyDown(useKey))
        {
            anim.SetTrigger("use");
            
        }
    }

    void FixedUpdate()
    {
        xy_direction = new Vector2(x_direction, y_direction);
        xy_direction.Normalize();
        rb.linearVelocity = xy_direction * speed;

        // Animation
        anim.SetBool("isRunning", rb.linearVelocity.magnitude != 0);
    }

    void Movement()
    {
        // INPUT
        x_direction = Input.GetAxisRaw("Horizontal");
        y_direction = Input.GetAxisRaw("Vertical");

        //FlipSprite
        if (x_direction < 0)
            sr.flipX = true;
        else if (x_direction > 0)
            sr.flipX = false;
    }
}

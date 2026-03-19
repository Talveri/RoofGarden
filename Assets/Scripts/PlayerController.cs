using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 xy_direction;
    public float speed = 5f;
    Animator anim;
    public KeyCode useKey = KeyCode.E;

    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() { }

    public void Move(InputAction.CallbackContext context)
    {
        xy_direction = context.ReadValue<Vector2>();

        xy_direction.Normalize();
        rb.linearVelocity = xy_direction * speed;

        // Animation
        anim.SetBool("isRunning", rb.linearVelocity.magnitude != 0);

        if (xy_direction.x < 0)
            sr.flipX = true;
        else if (xy_direction.x > 0)
            sr.flipX = false;
    }

    public void Use()
    {
        anim.SetTrigger("use");
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 xy_direction;
    public float speed = 5f;
    Animator anim;
    public KeyCode useKey = KeyCode.E;

    private ParticleSystem dustParticles;

    private SpriteRenderer sr;

    private InteractionManager interactionManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        interactionManager = GetComponentInChildren<InteractionManager>();
        dustParticles = GetComponentInChildren<ParticleSystem>();
        anim.SetBool("isRunning", false);
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

        if(rb.linearVelocity.magnitude != 0)
        {
            dustParticles.gameObject.SetActive(true);
        }
        else
        {
             dustParticles.gameObject.SetActive(false);
        }

        if (xy_direction.x < 0){
            sr.flipX = true;
            dustParticles.transform.localScale = new Vector3(1,1,1);
        }
        else if (xy_direction.x > 0){
            sr.flipX = false;
            dustParticles.transform.localScale = new Vector3(-1,1,1);
        }
    }

    public void Use()
    {
        if (interactionManager == null)
        {
            Debug.LogError("InteractionManager not found on PlayerController");
            return;
        }

        IInteractable interactable;

        if ((interactable = interactionManager.GetInteractable()) != null)
        {
            anim.SetTrigger("use");
            interactable.Interact<object>(null);
        }
    }
}

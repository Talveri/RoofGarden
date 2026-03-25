using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// The Player Controller Handles Player Movement and Interaction and is attached to the Player gameObject
/// </summary>

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 xy_direction;
    public float speed = 5f;
    Animator anim;

    private ParticleSystem dustParticles;

    private SpriteRenderer sr;

    private InteractionManager interactionManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        InputMapManager.Initialize(GetComponent<PlayerInput>());
        

        interactionManager = GetComponentInChildren<InteractionManager>();
        dustParticles = GetComponentInChildren<ParticleSystem>();
        dustParticles.gameObject.SetActive(false);
        anim.SetBool("isRunning", false);
    }
    public void Move(InputAction.CallbackContext context)
    {
        xy_direction = context.ReadValue<Vector2>().normalized;

        // Animation
        anim.SetBool("isRunning", xy_direction != Vector2.zero);

        dustParticles.gameObject.SetActive(xy_direction != Vector2.zero); //Stop the particle system if the player does not move

        if (xy_direction.x < 0){
            sr.flipX = true;
            dustParticles.transform.localScale = new Vector3(1,1,1);
        }
        else if (xy_direction.x > 0){
            sr.flipX = false;
            dustParticles.transform.localScale = new Vector3(-1,1,1);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + xy_direction * speed * Time.fixedDeltaTime);
    }

    public void Use(InputAction.CallbackContext context)
    {
        if(!context.performed) return;

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

    public void Open_Inventory(InputAction.CallbackContext context)
    {
        
    }
}

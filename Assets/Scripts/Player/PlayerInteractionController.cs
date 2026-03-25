using UnityEngine;
using UnityEngine.InputSystem;
/// The Player Interaction Controller is added to the Player GameObject and controls the direction the InteractionComponent 
/// points to.
/// The direction the InteractionComponent points to is dependent of the last movementdirection of the player.

class PlayerInteractionController : MonoBehaviour
{
    public void PointingDirection(InputAction.CallbackContext ctx)
    {
        InteractionPointsTo(ctx.ReadValue<Vector2>());
    }

    void InteractionPointsTo(Vector2 vector)
    {
        if (vector != Vector2.zero) // avoid zero-rotation spam
        {
            float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }
}
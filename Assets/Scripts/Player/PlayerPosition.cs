using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public static PlayerPosition Instance { get; private set; }
    public Transform Player;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Debug.LogError($"An Instance of this GameObject already exist. \nDeleting GameObject {gameObject.name}");
            Destroy(gameObject);
        }
    }
    public Vector3 PlayerPositionRelativeToCamera()
    {
        return Player.position - Camera.main.transform.position;
    }

    public Vector3 PlayerScreenPosition(float offset)
    {   
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(Player.position);
        screenPosition.y = 0 + offset;
        screenPosition.x = 0;
        screenPosition.z = 0;
        return screenPosition;
    }
}
using UnityEngine;

/// The Raised Bed Collider is added to the Raised Bed gameObject, which contains the fields, the Player shall interact with.
/// The purpose of this script is to hide the selector once the players interaction collider exits the raised bed.

class RaisedBedSelectionManager : MonoBehaviour
{
    public FieldSelector fieldSelector;

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fieldSelector.Hide();
        }
    }
}
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public void Move(Vector3 movement)
    {
        // Moves the GameObject by adding the movement vector to its position.
        transform.position += movement;
    }
}

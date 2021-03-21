using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Target for follow
    public Transform player;

    // Camera smooth speed
    [SerializeField] public float smoothSpeed;

    // Offset vector for direction
    [SerializeField] public Vector3 offset;

    public float SmoothSpeed { get { return smoothSpeed; } set { smoothSpeed = value; } }
    public Vector3 Offset { get { return offset; } set { offset = value; } }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}

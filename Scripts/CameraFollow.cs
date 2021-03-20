using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    [SerializeField] public float smoothSpeed;
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

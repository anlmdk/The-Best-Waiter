using UnityEngine;
using UnityEngine.UI;

public class DebugController : MonoBehaviour
{
    public PlayerController player;
    public new CameraFollow camera;

    // Player
    public InputField _forwardSpeed, _swipeSpeed, _jump;

    // Camera
    public InputField _cameraX, _cameraY, _cameraZ, _smoothSpeed;

    private void Start()
    {
        GetPlayerValue();
        GetCameraValue();
    }

    // Player get value from player controller script
    public void GetPlayerValue()
    {
        float forwardSpeedValue = player.ForwardSpeed;
        _forwardSpeed.text = forwardSpeedValue.ToString();

        float swipeSpeedValue = player.SwipeSpeed;
        _swipeSpeed.text = swipeSpeedValue.ToString();

        float jumpValue = player.Jump;
        _jump.text = jumpValue.ToString();
    }
    // Submit the changing value of the player
    public void SetForwardSpeedValue(string forwardSpeed)
    {
        float forwardSpeedValue = float.Parse(forwardSpeed);
        player.ForwardSpeed = forwardSpeedValue;
    }
    public void SetSwipeSpeedValue(string swipeSpeed)
    {
        float swipeSpeedValue = float.Parse(swipeSpeed);
        player.SwipeSpeed = swipeSpeedValue;
    }
    public void SetJumpValue(string jump)
    {
        float jumpValue = float.Parse(jump);
        player.Jump = jumpValue;
    }

    // Camera get value from camera follow script
    public void GetCameraValue()
    {
        float offsetValueX = camera.Offset.x;
        _cameraX.text = offsetValueX.ToString();

        float offsetValueY = camera.Offset.y;
        _cameraY.text = offsetValueY.ToString();

        float offsetValueZ = camera.Offset.z;
        _cameraZ.text = offsetValueZ.ToString();

        float smoothSpeedValue = camera.SmoothSpeed;
        _smoothSpeed.text = smoothSpeedValue.ToString();
    }
    // Submit the changing value of the camera
    public void SetValueX (string offsetX)
    {
        float offsetValueX = float.Parse(offsetX);
        camera.offset.x = offsetValueX;
    }
    public void SetValueY(string offsetY)
    {
        float offsetValueY = float.Parse(offsetY);
        camera.offset.y = offsetValueY;
    }
    public void SetValueZ (string offsetZ)
    {
        float offsetValueZ = float.Parse(offsetZ);
        camera.offset.z = offsetValueZ;
    }
    public void SetSmoothSpeedValue(string smoothSpeed)
    {
        float smoothSpeedValue = float.Parse(smoothSpeed);
        camera.SmoothSpeed = smoothSpeedValue;
    }
}

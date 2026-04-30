using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f; // Change it according to how slow or fast the camera is following
    public float lookAheadDistance = 2f; // Change it according to far the camera shifts left or right

    public Vector2 minBounds;
    public Vector2 maxBounds;

    private float currentLookAhead;

    // Updates the camera's position after all movements have occured
    private void LateUpdate()
    {
        if (target == null)
            return;

        float moveInput = Input.GetAxis("Horizontal");
        // Adjusts look ahead based on the players movement direction
        if (moveInput > 0)
        {
            currentLookAhead = lookAheadDistance;
        }
        else if (moveInput < 0)
        {
            currentLookAhead = -lookAheadDistance;
        }
        // Calculates the desired camera's position
        Vector3 targetPosition = new Vector3(target.position.x + currentLookAhead, target.position.y, transform.position.z);

        float clampedX = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed * Time.deltaTime);

    }
    // This method is used for testing to verify that the positions are clamped within bounds
    public void TestClampPosition(Vector3 fakeTargetPosition)
    {
        Vector3 targetPosition = new Vector3(fakeTargetPosition.x, fakeTargetPosition.y, transform.position.z);

        float clampedX = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
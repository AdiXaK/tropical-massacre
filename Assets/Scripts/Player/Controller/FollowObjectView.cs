using UnityEngine;

public class FollowObjectView : MonoBehaviour
{
    [SerializeField] private Transform cameraPositions;
    [SerializeField] private float smoothTime = 0.3f;
    [SerializeField] private Transform player;
    [SerializeField] private float distanceFromPlayer = 5f;
    [SerializeField] private float heightOffset = 2f;
    [SerializeField] private float cursorSensitivity = 1f;

    private Vector3 targetPosition;
    private Vector3 currentVelocity = Vector3.zero;
    private float initialHeight;

    private void Start()
    {
        targetPosition = transform.position;
        initialHeight = transform.position.y;
    }

    void LateUpdate()
    {
        targetPosition = cameraPositions.position;
        Vector3 desiredPosition = targetPosition - player.forward * distanceFromPlayer + Vector3.up * heightOffset;
        float cursorMovement = Input.GetAxis("Mouse Y") * cursorSensitivity;
        desiredPosition += Vector3.up * cursorMovement;

        if (desiredPosition.y < initialHeight)
        {
            desiredPosition.y = initialHeight;
        }

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothTime);
        transform.LookAt(player);
    }
     }
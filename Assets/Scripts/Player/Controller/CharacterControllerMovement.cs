// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerMovement : BaseCharacterMovement
{
    private CharacterController characterController;
    private float verticalSpeed = 0f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float gravity = 9.8f;
    private float dragSpeedMultiplier = 1f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private new void Update()
    {
        base.Update();

        if (Input.GetButtonDown("Jump") && characterController.isGrounded && !Input.GetKey(KeyCode.LeftControl))
        {
            verticalSpeed = jumpSpeed;
        }
        float currentMovementSpeed =  movementSpeed;

        if (!characterController.isGrounded)
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }
        else
        {
            if (verticalSpeed < 0)
            {
                verticalSpeed = -2f;
            }
        }

        Vector3 moveVector = new Vector3(movementVector.x * currentMovementSpeed, verticalSpeed, movementVector.z * currentMovementSpeed);
        characterController.Move(moveVector * Time.deltaTime);
    }
    public void SetDragSpeedMultiplier(float multiplier)
    {
        dragSpeedMultiplier = multiplier;
    }
}

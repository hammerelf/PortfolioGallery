using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private CharacterController characterController;
    private InputAction moveAction, lookAction;
    private float yRot, xRot;
    public float moveSpeed = 10f, rotationSpeed = 5f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
    }

    private void Update()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveVector.x, 0, moveVector.y);
        move = transform.TransformDirection(move);
        move.y = 0;
        characterController.Move(move * Time.deltaTime * moveSpeed);

        Vector2 lookVector = lookAction.ReadValue<Vector2>();
        yRot += lookVector.x * rotationSpeed * Time.deltaTime;
        xRot += lookVector.y * rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(Mathf.Clamp(-xRot, -70, 50), yRot, 0);
    }
}

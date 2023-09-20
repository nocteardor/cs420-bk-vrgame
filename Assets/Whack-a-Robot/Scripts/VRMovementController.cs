using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VRMovementController : MonoBehaviour
{
    public bool usingContinuousTurn;
    public bool usingSnapTurn;

    public float speed = 1;
    public float continuousTurnSpeed = 60;
    public float snapTurnAngle = 45;
    public float snapTurnRate = 0.5f;

    public ActionBasedSnapTurnProvider snapTurnProvider;

    public InputActionProperty moveInputSource;
    public InputActionProperty turnInputSource;

    public Rigidbody rb;

    public LayerMask groundLayer;

    public Transform directionSource;
    public Transform turnSource;

    public CapsuleCollider bodyCollider;

    private Vector2 inputMoveAxis;
    private float inputTurnAxis;



    private void Start()
    {
        snapTurnProvider = GetComponent<ActionBasedSnapTurnProvider>();
        //establish the turning method and disable the other method accordingly
        if (usingSnapTurn)
        {
            usingContinuousTurn = false;
            snapTurnProvider.enabled = true;
            snapTurnProvider.turnAmount = snapTurnAngle;
            snapTurnProvider.debounceTime = snapTurnRate;
        }
        else if (usingContinuousTurn)
            usingSnapTurn = false;


    }

    void Update()
    {
        inputMoveAxis = moveInputSource.action.ReadValue<Vector2>();
        inputTurnAxis = turnInputSource.action.ReadValue<Vector2>().x;
    }

    private void FixedUpdate()
    {
        bool isGrounded = CheckIfGrounded();

        if(isGrounded)
        {
            Quaternion yaw = Quaternion.Euler(0, directionSource.eulerAngles.y, 0);
            Vector3 direction = yaw * new Vector3(inputMoveAxis.x, 0, inputMoveAxis.y);

            Vector3 targetMovePosition = rb.position + direction * Time.fixedDeltaTime * speed;

            Vector3 axis = Vector3.up;

            if (usingContinuousTurn)
            {
                float angle = continuousTurnSpeed * Time.fixedDeltaTime * inputTurnAxis;

                Quaternion q = Quaternion.AngleAxis(angle, axis);

                rb.MoveRotation(rb.rotation * q);

                Vector3 newPosition = q * (targetMovePosition - turnSource.position) + turnSource.position;

                rb.MovePosition(newPosition);
            }
            else if (!usingContinuousTurn && usingSnapTurn)
            {

            }
        }
    }
    public bool CheckIfGrounded()
    {
        Vector3 start = bodyCollider.transform.TransformPoint(bodyCollider.center);
        float rayLength = bodyCollider.height / 2 - bodyCollider.radius + 0.05f;

        bool hasHit = Physics.SphereCast(start, bodyCollider.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        return hasHit;
    }
}

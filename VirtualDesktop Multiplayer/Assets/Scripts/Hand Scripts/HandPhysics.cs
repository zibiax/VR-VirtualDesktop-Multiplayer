using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandPhysics : MonoBehaviour
{
    public float smoothingAmount = 15.0f;
    public Transform target = null;

    // Float for the value of smoothing

    private Rigidbody rigidbody = null;
    private Vector3 targetPosition = Vector3.zero;
    private Quaternion targetRotation = Quaternion.identity;

    // Setting variables for the rigidbody, position, and rotation 

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    // Script to get a rigidbody on awake

    private void Start()
    {
        TeleportToTarget();
    }
    //Teleporting the hands to controllers at start without animations

    private void Update()
    {
        SetTargetPosition();
        SetTargetRotation();
    }
    // Functions for the hand rotation and position

    private void SetTargetPosition()
    {
        float time = smoothingAmount * Time.unscaledDeltaTime;
        targetPosition = Vector3.Lerp(targetPosition, target.position, time);
    }
    // Script to set target position(smoothing)

    private void SetTargetRotation()
    {
        float time = smoothingAmount * Time.unscaledDeltaTime;
        targetRotation = Quaternion.Slerp(targetRotation, target.rotation, time);
    }
    // Script to set target rotation(smoothing)

    private void FixedUpdate()
    {
        MoveToController();
        RotateToController();
    }
    // Function for moving position, rigidbody, rotation

    private void MoveToController()
    {
        Vector3 positionDelta = targetPosition - transform.position;

        rigidbody.velocity = Vector3.zero;
        rigidbody.MovePosition(transform.position + positionDelta);
    }
    // Script to set rigidbody to zero and move it to cotroller

    private void RotateToController()
    {
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.MoveRotation(targetRotation);
    }
    // Script to move to controller position

    public void TeleportToTarget()
    {
        targetPosition = target.position;
        targetRotation = target.rotation;

        transform.position = targetPosition;
        transform.rotation = targetRotation;
    }
    // Script to rotate to controller position
}

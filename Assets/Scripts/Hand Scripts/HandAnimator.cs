using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAnimator : MonoBehaviour
{
    public float speed = 4.0f;
    public XRController controller = null;
    // Script to which the controller will move at and reference to the XRController controller script
    private Animator animator = null;

    private readonly List<Finger> gripFingers = new List<Finger>()
    {
        new Finger(FingerType.Middle),
        new Finger(FingerType.Ring),
        new Finger(FingerType.Pinky)
    };
    //Script to make a list of the different fingers and what the different types should animate. The gripfingers

    private readonly List<Finger> pointFingers = new List<Finger>
    {
        new Finger (FingerType.Index),
        new Finger ( FingerType.Thumb)
    };
    //Script to make a list of the different fingers and what the different types should animate. The pointfingers(thump, index)
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    // To get the animator component

    private void Update()
    {
        // Store input
        CheckGrip();
        CheckPointer();
        // Smooth input values
        SmoothFinger(pointFingers);
        SmoothFinger(gripFingers);

        // Apply smoothed values
        AnimateFinger(pointFingers);
        AnimateFinger(gripFingers);
    }

    private void CheckGrip()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            SetFingerTargets(gripFingers, gripValue);
    }

    // If the controll can grip it will pull the different values from the controller for the approriate finger/s

    private void CheckPointer()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float pointerValue))
            SetFingerTargets(pointFingers, pointerValue);
    }
    // If the controll can trigger it will pull the different values from the controller for the approriate finger/s

    private void SetFingerTargets(List<Finger> fingers, float value)
    {
        foreach(Finger finger in fingers)
        {
            finger.target = value;
        }
    }
    // Listing the different floats of the individual fingers

    private void SmoothFinger(List<Finger> fingers)
    {
        foreach(Finger finger in fingers)
        {
            float time = speed * Time.unscaledDeltaTime;
            finger.current = Mathf.MoveTowards(finger.current, finger.target, time);
        }
    }
    // List of of the fingers and function to make the animation smooth

    private void AnimateFinger(List<Finger> fingers)
    {
        foreach(Finger finger in fingers)
        {
            AnimateFinger(finger.type.ToString(), finger.current);
        }
    }
    // Script to pull for the different finger type and to animate it

    private void AnimateFinger(string finger, float blend)
    {
        animator.SetFloat(finger, blend);
    }
    // The function to set the right float to the different finger
}
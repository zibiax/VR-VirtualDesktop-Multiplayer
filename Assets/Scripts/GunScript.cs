using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class GunScript : MonoBehaviour
{

    /* Declaring all public variables*/
    [SerializeField] private GameObject impactEffect;
    [SerializeField] float range = 100f;
    [SerializeField] private ParticleSystem ShootLight;
    [SerializeField] GameObject gunObj;

    // Target Points
    [SerializeField] private GameObject Point;

    [SerializeField] private Text pointText;

    private int currPoints = 0;

    private void Start()
    {

        // Converting points to 0 everytime the game starts
        pointText.text = currPoints.ToString();
    }


    //Updating every frame
    void Update()
    {

    }


    // Shooting method for the gun
    public void Shoot()
    {

        RaycastHit hit;
        if (Physics.Raycast(gunObj.transform.position, gunObj.transform.forward, out hit, range))
        {
            // If the target getting shot at has the TargetScript, this code runs
            TargetScript target = hit.transform.GetComponent<TargetScript>();
            if (target != null)
            {
                currPoints++;
                pointText.text = currPoints.ToString();

            } else
            {
                currPoints = 0;
                pointText.text = currPoints.ToString();

            }
            // Instantiates impact effect from gun when fired
            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
        
        }
    }
}

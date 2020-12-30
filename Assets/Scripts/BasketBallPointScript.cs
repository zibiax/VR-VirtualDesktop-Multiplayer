using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketBallPointScript : MonoBehaviour
{
    // Declaring all public GameObjects
    [SerializeField]private GameObject Ball;
    
    [SerializeField]private GameObject Point;

    [SerializeField] private Text pointText;

    private int currPoints = 0;



    void Start()
    {
        // Converting points to 0 everytime the game starts
        pointText.text = currPoints.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        // One point is incremented if the basketball collides with the collider beneath the goal
        if (other.gameObject.tag == "Ball")
        {
            currPoints++;
            pointText.text = currPoints.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

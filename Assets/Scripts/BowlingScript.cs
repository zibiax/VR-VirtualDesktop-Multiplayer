using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class BowlingScript : MonoBehaviour
{

    [SerializeField] private GameObject BowlingLane;

    [SerializeField] private GameObject Point;

    [SerializeField] private Text pointText;

    private int currPoints = 0;

    void Start()
    {
        // Converting points to 0 everytime the game starts
        pointText.text = currPoints.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        // One point is incremented if the kegel collides with the plane called bowlinglane
        if (other.gameObject.tag == "Kegel")
        {
            currPoints++;
            pointText.text = currPoints.ToString();
        }
    }
}

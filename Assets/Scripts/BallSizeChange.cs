using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSizeChange : MonoBehaviour
{
    public void GrowBall()
    {
        transform.localScale *= 1.1f;
    }
    //Function to increase size of object
   public void ShrinkBall()
    {
        transform.localScale *= 0.1f;
    }
    //Function to reduce size of object
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spinningWheelScript : MonoBehaviour
{

    [SerializeField] private Rigidbody wheel;

    [SerializeField] private GameObject Arrow;

    [SerializeField] private GameObject win;

    [SerializeField] private GameObject loss;

    [SerializeField] private Text resultText;


    // Start is called before the first frame update
    void Start()
    {
        resultText.text = "Spin!";
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        {
            //IF the arrow object collides with a "win" collider, following happens
            if (other.gameObject.tag == "win")
            {
                resultText.text = "Congrats!";

            //IF the arrow object collides with a "loss" collider, following happens
            }
            else if(other.gameObject.tag == "loss")
            {
                resultText.text = "Try again!";
            }
        }
       
        
        
    }
    // Update is called once per frame
    void Update()
    {

    }
}

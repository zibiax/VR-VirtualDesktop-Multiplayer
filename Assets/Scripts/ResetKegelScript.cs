using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetKegelScript : MonoBehaviour
{
    private List<Vector3> startPos = new List<Vector3>();
    private List<Transform> kegels = new List<Transform>();
    private List<Quaternion> startRot = new List<Quaternion>();

    private int numKegelsDown = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            startPos.Add(child.position);
            kegels.Add(child);
            startRot.Add(child.rotation);
            // Script saves the position and rotation at the start of the scene
        }
    }
    void Update()
    {
        foreach (Transform child in kegels)
        {
            if (child.gameObject.activeInHierarchy && child.position.y < -5f)
            {
                child.gameObject.SetActive(false);
                numKegelsDown++;
            }
        }
        if (numKegelsDown == kegels.Count)
        {
            Reset();
        }
    }
    // Script is checking if ALL the kegels have fallen of the platform at -5y

    void Reset()
    {
        for (int i = 0; i < kegels.Count; i++)
        {
            kegels[i].gameObject.SetActive(true);
            kegels[i].position = startPos[i];
            kegels[i].rotation = startRot[i];
            Rigidbody r = kegels[i].GetComponent<Rigidbody>();
            r.velocity = Vector3.zero;
            r.angularVelocity = Vector3.zero;
        }
        numKegelsDown = 0;
        // Script gives the same values of the original position and rotation for respawn
    }
}

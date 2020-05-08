using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used To give a body its intial velocity on Start u{
/// </summary>
public class IntitalVelocityBehavior : MonoBehaviour
{
    public Vector3 Speed;
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.AddForce(Speed*100,ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

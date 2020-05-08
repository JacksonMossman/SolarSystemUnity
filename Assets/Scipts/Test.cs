using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Original Test Script similar to intial Velocity just without a 100* modifiyer used for experments
/// </summary>
public class Test : MonoBehaviour
{
    public float speed;
    public Rigidbody rigidbody;
   
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.AddForce(new Vector3 (speed,0,0),ForceMode.Acceleration );
    }

    // Update is called once per frame
    void Update()
    {
       
        
        
    }
}

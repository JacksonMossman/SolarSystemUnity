using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickBehavior : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public GravityBehavior gravity;

    //the Prefab that will be spawned
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //generate a prefab at the location of the mouse
    void Update()
    {
        //get the current moust position on the screen
        Vector3 mousePos = new Vector3(Input.mousePosition.x,Input.mousePosition.y, Input.mousePosition.z);
        //check if mouse is down
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos;
            //create a ray from the camra and mouse position  
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;
            //check if the ray hit another object
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                worldPos = hit.point;
            }
            //if ray does not hit another object will set the postion to the mouse postion in the world
            else
            {
                worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            }

            GameObject gObject= Instantiate(prefab, worldPos, Quaternion.identity);
            //set objects transform to mouse locations ignoring y axis
            gObject.transform.position = new Vector3(worldPos.x,0,worldPos.z );
            //add planet to the planet list
            gravity.addPlanet(gObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBehavior : MonoBehaviour
{
    /// <summary>
    /// Manage A list of all Gravatational Objects as well as all gravity Calculation
    /// 
    /// Notes:
    /// After Some Reserch on Similar Projects i there is a issue with my build 
    /// where all the calculation and the force are added at the same time for one object at time
    /// This Creates Some Inconsistenes in the Gravity between runs
    /// </summary>
    public float GravityConstant = 1.0f;
    public GameObject[] gravityObjects;
    public float HolderMass =0;
    public float HolderXVelocity=0;
    public float HolderYVelocity=0;
    // Start is called before the first frame update
    void Start()
    {
        //generate list of all gravityobjects currently in scene
        gravityObjects = GameObject.FindGameObjectsWithTag("Graved");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos1 = new Vector3(0.0f, 0.0f, 0.0f);
        Vector3 pos2 = new Vector3(0.0f, 0.0f, 0.0f);
        Vector3 Vector1to2 = new Vector3(0.0f, 0.0f, 0.0f);
        float Distance = 0.0f;
        Vector3 netForce = new Vector3(0.0f, 0.0f, 0.0f);
        //iterate through the list of gravational objects calculating how much force should be applyed based off distance and mass of the two objects
        for (int i = 0; i < gravityObjects.Length; i++)
        {
            netForce.Set(0, 0, 0);
            for (int j = 0; j < gravityObjects.Length; j++)
            {
                if (i != j)
                {
                    //Get Position of both gravational objects
                    pos1 = gravityObjects[i].GetComponent<Rigidbody>().position;
                    pos2 = gravityObjects[j].GetComponent<Rigidbody>().position;
                    //Debug.Log("pos1: " + pos1);
                    //Debug.Log("pos2: " + pos2);
                    
                    Vector1to2 = pos2 - pos1;
                    //Debug.Log(v1to2);
                    Distance = Vector1to2.magnitude;
                    //Using The Gravational Constant Mass Of Both objects and distance between the two objects generate the net force
                    netForce += GravityConstant * gravityObjects[i].GetComponent<Rigidbody>().mass * gravityObjects[j].GetComponent<Rigidbody>().mass / (Distance * Distance) * Vector1to2.normalized;
                }
            }
            Debug.Log(i);
            
            gravityObjects[i].GetComponent<Rigidbody>().AddForce(netForce*Time.deltaTime);
        }
    }

    //Add a planet with the values of the sliders and remake the gravataional body array
    public void addPlanet(GameObject obj)
    {
        //get values based off sliders 
        obj.GetComponent<Rigidbody>().mass = HolderMass;
        //create speed vectors are swapped around due to camara being misplaced and attempt 
        Vector3 speed = new Vector3(HolderYVelocity, 0,HolderXVelocity );
        //set intital velocity of body
        obj.GetComponent<Rigidbody>().AddForce(speed * 100, ForceMode.Acceleration);
        //create new array and lengthen
        GameObject[] temp = new GameObject[gravityObjects.Length +1];
        //iterate remaking array
        for (int i = 0; i<gravityObjects.Length; i++)
        {
            temp[i] = gravityObjects[i];
        }
        temp[gravityObjects.Length] = obj;

        gravityObjects = temp;
    }

    //Functions used by sliders to set values
    public void setHolderMass(float mass)
    {
        HolderMass = mass;
    }
    public void setHolderXVelocity(float XVel)
    {
        HolderXVelocity = XVel;
    }
    public void setHolderYVelocity(float YVel)
    {
        HolderYVelocity = YVel;
    }
}

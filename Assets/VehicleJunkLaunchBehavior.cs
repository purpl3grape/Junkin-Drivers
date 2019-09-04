using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ModuloKart.CustomVehiclePhysics;

public class VehicleJunkLaunchBehavior : MonoBehaviour
{
    public GameObject Wheel;

    private GameObject currentWheel;
    private VehicleBehavior vehicleBehavior;

    // Start is called before the first frame update
    void Start()
    {
        vehicleBehavior = GetComponent<VehicleBehavior>();    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentWheel = GetLaunchObject(Wheel);
        }
        GroundCheck();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LaunchObjectBehavior(currentWheel);
    }

    private GameObject GetLaunchObject(GameObject obj)
    {
        Debug.Log("Getting Laucned Object");
        return GameObject.Instantiate(obj, transform.position + Vector3.up * 10, Quaternion.identity);
    }

    private void LaunchObjectBehavior(GameObject obj)
    {
        if (currentWheel != null) {
            if (!isGrounded)
            {
                Debug.Log("Dropping Laucned Object");
                currentWheel.transform.position -= Vector3.up * 5 * Time.fixedDeltaTime;
            }
            else
            {
                Debug.Log("Dropped...");
            }
        }
        else
        {
            Debug.Log("No Laucned Object");
        }
    }

    bool isGrounded;

    Ray groundRay;
    RaycastHit groundHit;
    public LayerMask layerToScan;
    private void GroundCheck() {
        groundRay = new Ray(transform.position, Vector3.down * 5);
        Debug.DrawRay(transform.position, Vector3.down * 5);
        if (Physics.Raycast(groundRay, out groundHit, 1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}

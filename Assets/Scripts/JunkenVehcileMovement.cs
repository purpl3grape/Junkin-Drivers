using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkenVehcileMovement : MonoBehaviour
{
    #region Public Variables
    [HideInInspector] public Transform vehicle_transform;
    [HideInInspector] public Rigidbody vehicle_rigidbody;
    public float width_float = 4f;
    public float length_float = 4f;
    public float height_float = 4f;
    public const float GRAVITY = 5;
    public float gravity_float = GRAVITY;
    public LayerMask RayCastLayerMask;
    #endregion

    private void Start()
    {
        //Caching variables
        vehicle_transform = GetComponent<Transform>();
        vehicle_rigidbody = GetComponent<Rigidbody>();
        groundCheck_hits = new RaycastHit[255];
        ground_check_ray = new Ray[255];
    }

    private void FixedUpdate()
    {
        VehicleGroundCheck();
        VehicleMovement();
    }

    #region GroundCheck Variables
    [HideInInspector] public bool is_grounded;
    [HideInInspector] public Ray[] ground_check_ray = new Ray[5];
    #endregion

    #region GroundCheck Methods
    private void VehicleGroundCheck()
    {
        ground_check_ray[0] = new Ray(vehicle_transform.position, -vehicle_transform.up);
        ground_check_ray[1] = new Ray(vehicle_transform.position + vehicle_transform.forward * length_float, - vehicle_transform.up);
        ground_check_ray[2] = new Ray(vehicle_transform.position - vehicle_transform.forward * length_float, - vehicle_transform.up);
        ground_check_ray[3] = new Ray(vehicle_transform.position + vehicle_transform.right * width_float, - vehicle_transform.up);
        ground_check_ray[4] = new Ray(vehicle_transform.position - vehicle_transform.right * width_float, - vehicle_transform.up);

        is_grounded = VehicleGroundRaycast(ground_check_ray, 4.0f);
    }

    RaycastHit[] groundCheck_hits = new RaycastHit[255];
    private bool VehicleGroundRaycast(Ray[] rays, float dist)
    {
        foreach (Ray ray in rays)
        {
            Debug.DrawRay(vehicle_transform.position, -vehicle_transform.up * height_float, Color.red);
            if (Physics.RaycastNonAlloc(ray, groundCheck_hits, dist, RayCastLayerMask) > 0)
            {
                //Debug.Log("hit: " + groundCheck_hits[0].transform.name);
                return true;
            }
        }
        return false;
    }
    #endregion

    #region Movement Variables
    [HideInInspector] public float steer_magnitude_float;
    [HideInInspector] public float accel_magnitude_float;
    [HideInInspector] public float brake_magnitude_float;
    #endregion
    #region Movement Methods
    private void VehicleMovement()
    {
        if (is_grounded)
        {
            gravity_float = GRAVITY;
            vehicle_rigidbody.velocity = (vehicle_transform.forward * accel_magnitude_float);
        }
        else
        {
            gravity_float += Time.fixedDeltaTime * gravity_float;
            vehicle_rigidbody.velocity = (vehicle_transform.forward * 0 - vehicle_transform.up * gravity_float);
        }
    }
    #endregion

}

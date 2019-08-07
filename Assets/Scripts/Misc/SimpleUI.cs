using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleUI : MonoBehaviour
{
    public VehicleBehavior vehicleBehhavior;
    public Text Value_Velocity;
    public Text Value_Nitros;

    // Start is called before the first frame update
    void Start()
    {
        vehicleBehhavior = GameObject.FindObjectOfType<VehicleBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        Value_Velocity.text = (Mathf.FloorToInt(vehicleBehhavior.accel_magnitude_float)).ToString();
        Value_Nitros.text = (Mathf.FloorToInt(vehicleBehhavior.nitros_meter_float)).ToString();
    }
}

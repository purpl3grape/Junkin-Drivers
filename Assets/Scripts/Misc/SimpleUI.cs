using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ModuloKart.CustomVehiclePhysics;

namespace ModuloKart.HUD
{

    public class SimpleUI : MonoBehaviour
    {
        [HideInInspector] public VehicleBehavior vehicleBehavior;
        public Text Value_Velocity;
        public Text Value_Nitros;

        private void Start()
        {
            vehicleBehavior = GameObject.FindObjectOfType<VehicleBehavior>();
        }

        private void Update()
        {
            if (vehicleBehavior == null) return;
            if (Value_Velocity == null) return;
            if (Value_Nitros == null) return;

            Value_Velocity.text = (Mathf.FloorToInt(vehicleBehavior.accel_magnitude_float)).ToString();
            Value_Nitros.text = (Mathf.FloorToInt(vehicleBehavior.nitros_meter_float)).ToString();
        }
    }

}
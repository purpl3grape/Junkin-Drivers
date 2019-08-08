using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ModuloKart.CustomVehiclePhysics;

namespace ModuloKart.HUD
{

    public class SimpleUI : MonoBehaviour
    {
        VehicleBehavior[] vehicleBehaviors;
        [HideInInspector] public VehicleBehavior vehicleBehavior;
        public int PlayerID;
        public Text Value_Velocity;
        public Text Value_Nitros;

        private void Start()
        {
            vehicleBehaviors = GameObject.FindObjectsOfType<VehicleBehavior>();
            foreach (VehicleBehavior v in vehicleBehaviors)
            {
                if (v.PlayerID == PlayerID)
                {
                    vehicleBehavior = v;
                }
            }
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
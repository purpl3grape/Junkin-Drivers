﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ModuloKart.CustomVehiclePhysics;

namespace ModuloKart.Controls
{

    public class ControllerHandler : MonoBehaviour
    {

        [SerializeField] private VehicleBehavior[] vehicles;
        public VehicleBehavior vehicle1;
        public VehicleBehavior vehicle2;
        public VehicleBehavior vehicle3;
        public VehicleBehavior vehicle4;

        public int[] AssignedJoyStickNumbers;

        private void Start()
        {
            vehicles = GameObject.FindObjectsOfType<VehicleBehavior>();
            AssignedJoyStickNumbers = new int[vehicles.Length];
            foreach (VehicleBehavior v in vehicles)
            {
                if (v.PlayerID == 1)
                    vehicle1 = v;
                if (v.PlayerID == 2)
                    vehicle2 = v;
                if (v.PlayerID == 3)
                    vehicle3 = v;
                if (v.PlayerID == 4)
                    vehicle4 = v;
            }
        }

        private void Update()
        {
            if (vehicle4.isControllerInitialized)
            {
                return;
            }
            if (vehicle1.JoyStick == -1)
            {
                vehicle1.JoyStick = GetJoyStickNumber();
                if (vehicle1.JoyStick > 0)
                {
                    vehicle1.input_steering = "LeftJoyStickX_P" + vehicle1.JoyStick;
                    vehicle1.input_accelerate = "RightTrigger_P" + vehicle1.JoyStick;
                    vehicle1.input_drift = "B_P" + vehicle1.JoyStick;
                    vehicle1.input_nitros = "A_P" + vehicle1.JoyStick;
                    vehicle1.isControllerInitialized = true;
                    AssignedJoyStickNumbers[0] = vehicle1.JoyStick;
                }
            }
            else if (vehicle2.JoyStick == -1)
            {
                vehicle2.JoyStick = GetJoyStickNumber();
                if (vehicle2.JoyStick > 0)
                {
                    vehicle2.input_steering = "LeftJoyStickX_P" + vehicle2.JoyStick;
                    vehicle2.input_accelerate = "RightTrigger_P" + vehicle2.JoyStick;
                    vehicle2.input_drift = "B_P" + vehicle2.JoyStick;
                    vehicle2.input_nitros = "A_P" + vehicle2.JoyStick;
                    vehicle2.isControllerInitialized = true;
                    AssignedJoyStickNumbers[1] = vehicle2.JoyStick;
                }
            }
            else if (vehicle3.JoyStick == -1)
            {
                vehicle3.JoyStick = GetJoyStickNumber();
                if (vehicle3.JoyStick > 0)
                {
                    vehicle3.input_steering = "LeftJoyStickX_P" + vehicle3.JoyStick;
                    vehicle3.input_accelerate = "RightTrigger_P" + vehicle3.JoyStick;
                    vehicle3.input_drift = "B_P" + vehicle3.JoyStick;
                    vehicle3.input_nitros = "A_P" + vehicle3.JoyStick;
                    vehicle3.isControllerInitialized = true;
                    AssignedJoyStickNumbers[2] = vehicle3.JoyStick;
                }
            }
            else if (vehicle4.JoyStick == -1)
            {
                vehicle4.JoyStick = GetJoyStickNumber();
                if (vehicle4.JoyStick > 0)
                {
                    vehicle4.input_steering = "LeftJoyStickX_P" + vehicle4.JoyStick;
                    vehicle4.input_accelerate = "RightTrigger_P" + vehicle4.JoyStick;
                    vehicle4.input_drift = "B_P" + vehicle4.JoyStick;
                    vehicle4.input_nitros = "A_P" + vehicle4.JoyStick;
                    vehicle4.isControllerInitialized = true;
                    AssignedJoyStickNumbers[3] = vehicle4.JoyStick;
                }
            }

        }

        private int GetJoyStickNumber()
        {
            for (int joyStickNumber = 1; joyStickNumber < 10; joyStickNumber++)
            {
                for (int i = 0; i < AssignedJoyStickNumbers.Length; i++)
                {
                    //Do not want to double assign 1 controller to 2 players. So take away the Joystick number that has been served
                    if (AssignedJoyStickNumbers[i] == joyStickNumber)
                    {
                        joyStickNumber++;
                        continue;
                    }
                }

                for (int buttonNumber = 0; buttonNumber < 20; buttonNumber++)
                {
                    if (Input.GetKeyDown("joystick " + joyStickNumber + " button " + buttonNumber))
                    {
                        Debug.Log("joystick " + joyStickNumber + " button " + buttonNumber);
                        return joyStickNumber;
                    }
                }
            }
            return -1;
        }

    }

}
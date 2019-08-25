using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ModuloKart.CustomVehiclePhysics;
using ModuloKart.HUD;
using ModuloKart.PlayerSelectionMenu;
namespace ModuloKart.Controls
{

    public class ControllerHandler : MonoBehaviour
    {

        [SerializeField] private VehicleBehavior[] vehicles;
        [HideInInspector] public VehicleBehavior vehicle1;
        [HideInInspector] public VehicleBehavior vehicle2;
        [HideInInspector] public VehicleBehavior vehicle3;
        [HideInInspector] public VehicleBehavior vehicle4;

        private SimpleUI[] huds;
        [HideInInspector] public SimpleUI HUDPlayer1, HUDPlayer2, HUDPlayer3, HUDPlayer4;

        public int assignedControllerCount;
        public int ControllersToAssign;
        public int[] AssignedJoyStickNumbers;

        private void Awake()
        {
            if (!GameObject.FindObjectOfType<PlayerSelectionManager>()) {
                SceneManager.LoadScene(0);    
            }


            vehicles = GameObject.FindObjectsOfType<VehicleBehavior>();
            AssignedJoyStickNumbers = new int[vehicles.Length];
            foreach (VehicleBehavior v in vehicles)
            {
                if (v.PlayerID == 1)
                {
                    vehicle1 = v;
                    AssignedJoyStickNumbers[0] = v.JoyStick;
                }
                if (v.PlayerID == 2)
                {
                    vehicle2 = v;
                    AssignedJoyStickNumbers[1] = v.JoyStick;
                }
                if (v.PlayerID == 3)
                {
                    vehicle3 = v;
                    AssignedJoyStickNumbers[2] = v.JoyStick;
                }
                if (v.PlayerID == 4)
                {
                    vehicle4 = v;
                    AssignedJoyStickNumbers[3] = v.JoyStick;
                }
            }

            huds = GameObject.FindObjectsOfType<SimpleUI>();
            foreach (SimpleUI h in huds)
            {
                if (h.PlayerID == 1)
                {
                    HUDPlayer1 = h;
                }
                if (h.PlayerID == 2)
                {
                    HUDPlayer2 = h;
                }
                if (h.PlayerID == 3)
                {
                    HUDPlayer3 = h;
                }
                if (h.PlayerID == 4)
                {
                    HUDPlayer4 = h;
                }
            }
        }

        private void Update()
        {
            if (assignedControllerCount < ControllersToAssign)
                HandleControlsUpTo(vehicle4);
        }

        #region Vehicle To Joystick Controller Handler
        private void HandleControlsUpTo(VehicleBehavior vehicleNumber)
        {
            if (vehicleNumber.isControllerInitialized)
            {
                return;
            }
            //Debug.Log("Still Searching for controller");

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

                    assignedControllerCount++;
                }
            }
            else if (vehicle2.JoyStick == -1)
            {
                vehicle2.JoyStick = GetJoyStickNumber();
                if ((vehicle2.JoyStick == vehicle1.JoyStick) || (vehicle2.JoyStick == vehicle3.JoyStick) || (vehicle2.JoyStick == vehicle4.JoyStick))
                {
                    return;
                }
                if (vehicle2.JoyStick > 0)
                {
                    vehicle2.input_steering = "LeftJoyStickX_P" + vehicle2.JoyStick;
                    vehicle2.input_accelerate = "RightTrigger_P" + vehicle2.JoyStick;
                    vehicle2.input_drift = "B_P" + vehicle2.JoyStick;
                    vehicle2.input_nitros = "A_P" + vehicle2.JoyStick;
                    vehicle2.isControllerInitialized = true;
                    AssignedJoyStickNumbers[1] = vehicle2.JoyStick;

                    assignedControllerCount++;
                }
            }
            else if (vehicle3.JoyStick == -1)
            {
                vehicle3.JoyStick = GetJoyStickNumber();
                if ((vehicle3.JoyStick == vehicle1.JoyStick) || (vehicle3.JoyStick == vehicle2.JoyStick) || (vehicle3.JoyStick == vehicle4.JoyStick))
                {
                    return;
                }
                if (vehicle3.JoyStick > 0)
                {
                    vehicle3.input_steering = "LeftJoyStickX_P" + vehicle3.JoyStick;
                    vehicle3.input_accelerate = "RightTrigger_P" + vehicle3.JoyStick;
                    vehicle3.input_drift = "B_P" + vehicle3.JoyStick;
                    vehicle3.input_nitros = "A_P" + vehicle3.JoyStick;
                    vehicle3.isControllerInitialized = true;
                    AssignedJoyStickNumbers[2] = vehicle3.JoyStick;

                    assignedControllerCount++;
                }
            }
            else if (vehicle4.JoyStick == -1)
            {
                vehicle4.JoyStick = GetJoyStickNumber();
                if ((vehicle4.JoyStick == vehicle1.JoyStick) || (vehicle4.JoyStick == vehicle2.JoyStick) || (vehicle4.JoyStick == vehicle3.JoyStick))
                {
                    return;
                }
                if (vehicle4.JoyStick > 0)
                {
                    vehicle4.input_steering = "LeftJoyStickX_P" + vehicle4.JoyStick;
                    vehicle4.input_accelerate = "RightTrigger_P" + vehicle4.JoyStick;
                    vehicle4.input_drift = "B_P" + vehicle4.JoyStick;
                    vehicle4.input_nitros = "A_P" + vehicle4.JoyStick;
                    vehicle4.isControllerInitialized = true;
                    AssignedJoyStickNumbers[3] = vehicle4.JoyStick;

                    assignedControllerCount++;
                }
            }

        }

        private int GetJoyStickNumber()
        {
            for (int joyStickNumber = 1; joyStickNumber < 17; joyStickNumber++)
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
        #endregion
    }

}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleUI : MonoBehaviour
{
    public JunkinVehcileMovement VehicleMovement;
    public Text Value_Velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Value_Velocity.text = (Mathf.FloorToInt(VehicleMovement.accel_magnitude_float)).ToString();
    }
}
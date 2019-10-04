﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Stores data to be used between scenes (chiefly, calibration details).
 */ 
public class GlobalControl : MonoBehaviour
{
    // float data
    public float height, armLength, offset, multiplier, sub;

    // boolean data collected in RecalibrateHeight.cs and the Calibration scene
    public bool isRightHanded;

    // participant ID to differentiate logs
    public string participantID;

    // enum type(and instance) to differentiate different progression 
    public enum ProgressionType {Random, Performance, NumThrows};
    public ProgressionType progression;

    // Single instance of this class
    public static GlobalControl Instance;

    // Runs on startup
    private void Awake()
    {
        // If there is no Instance, makes this the Instance
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        // If an instance already exists, destroy this
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
 }

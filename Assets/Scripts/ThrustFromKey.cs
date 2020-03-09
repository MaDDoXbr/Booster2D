﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class ThrustFromKey : MonoBehaviour
{
    public FxHandler FX;
    
    private Rigidbody2D _rb;
    //public Vector3 force; //(0,1,0)
    public float ThrustForce = 10f;
    public KeyCode ActionKey = KeyCode.Space;
    private bool _hasFxHandler; 
    private void Awake()
    {
        _hasFxHandler = FX != null;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //## THRUST
        if (Input.GetKey(ActionKey))
        {
            _rb.AddRelativeForce(ThrustForce * Vector3.up * Time.deltaTime);
            if (_hasFxHandler)
                FX.Play();
        } else {
            if (_hasFxHandler)
                FX.Stop();
        }
    }
}
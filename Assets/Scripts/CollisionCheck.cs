using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Remoting.Services;
using UnityEngine;
using UnityEngine.Events;

public class CollisionCheck : MonoBehaviour
{
    [Serializable]
    public class UnityEventFloat : UnityEvent<float> {}
    public enum CheckType { Enter, Exit, Stay }
    public CheckType Type = CheckType.Enter;

    public bool ValidateLayer;
    public LayerMask Mask;
    public UnityEventFloat Callback;
    
    //[HideInInspector]
    public float CollisionStrength = 0f;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Type != CheckType.Enter)
            return;
        CheckCollision(other);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (Type != CheckType.Exit)
            return;
        CheckCollision(other);        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (Type != CheckType.Stay)
            return;
        CheckCollision(other);
    }

    private void CheckCollision(Collision2D col)
    {
        CollisionStrength = col.relativeVelocity.magnitude;
        if (ValidateLayer)
        {
            //01000100 (mask)
            //&
            //00100000 (test)
            //=
            //00000000 (test not "in" mask)
            var testMask = 1 << col.gameObject.layer;
            if ((Mask.value & testMask) != 0)
                Callback?.Invoke(CollisionStrength);
        }
        else
        {
            Callback?.Invoke(CollisionStrength);
        }
    }
}

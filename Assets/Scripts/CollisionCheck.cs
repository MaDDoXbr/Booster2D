using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Remoting.Services;
using UnityEngine;
using UnityEngine.Events;

public class CollisionCheck : MonoBehaviour
{
    public enum CheckType { Enter, Exit, Stay }
    public CheckType Type = CheckType.Enter;

    public bool ValidateLayer;
    public LayerMask Mask;
    public UnityEvent Callback;
    
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

    private void CheckCollision(Collision2D other)
    {
        if (ValidateLayer)
        {
            if ((Mask.value & 1 << other.gameObject.layer) > 0)
            {
                Debug.Log("In");
                Callback?.Invoke();
            }
            else
            {
                Callback?.Invoke();
            }
        }
    }
}

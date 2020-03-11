using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class IfValue : MonoBehaviour
{
    public ComparisonType Comparison;
    public float FloatValue = 3f;
    public float IntValue;
    public UnityEvent Callback;

    public enum ComparisonType { equal, greaterthan, lessthan}
    
    public void Do(float value)
    {
        if (Comparison == ComparisonType.equal && Mathf.Approximately(value, FloatValue)
            || Comparison == ComparisonType.greaterthan && value > FloatValue 
            || Comparison == ComparisonType.lessthan && value < FloatValue )
            Do();
    }
    
    public void Do(int value)
    {
        if (Comparison == ComparisonType.equal && value == IntValue 
            || Comparison == ComparisonType.greaterthan && value > IntValue 
            || Comparison == ComparisonType.lessthan && value < IntValue )
            Do();
    }

    public void Do()
    {
        Callback.Invoke();
    }
}

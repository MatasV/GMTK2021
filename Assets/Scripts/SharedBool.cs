using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Shared Bool")]
public class SharedBool : ScriptableObject
{
    private bool _value;

    public bool Value
    {
        get => _value;
        set
        {
            _value = value;
            onValueChanged.Invoke();
        }
    }

    public UnityEvent onValueChanged;
}

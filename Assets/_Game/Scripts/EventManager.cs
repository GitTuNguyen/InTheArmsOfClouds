using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public UnityAction SwitchStateToSelectPath;

    public UnityAction<int> SelectBlockOnTheMap;
    private void Awake()
    {
        Instance = this; 
    }

}

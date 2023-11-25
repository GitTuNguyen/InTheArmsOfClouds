using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public static class EventManager 
{
    public static UnityAction SwitchStateToSelectPath;

    public static UnityAction<int> SelectBlockOnTheMap;

    public static UnityAction UseAmuletItem;

    public static UnityAction EndOfTurnUseItem;
}

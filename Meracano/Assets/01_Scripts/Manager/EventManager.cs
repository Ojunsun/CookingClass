using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public delegate void BattleStartEvent();
public delegate void BattleEndEvent();
public delegate void EntityDragEvent();

public static class EventManager
{
    public static BattleStartEvent OnBattleStartEvent;
    public static BattleEndEvent OnBattleEndEvent;
    public static EntityDragEvent OnEntityDragEvent;
}

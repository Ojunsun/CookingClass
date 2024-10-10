using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BattleStartEvent();
public delegate void EntityDragEvent();

public static class EventManager
{
    public static BattleStartEvent OnBattleStartEvent;
    public static BattleStartEvent OnBattleEndEvent;
    public static EntityDragEvent OnEntityDragEvent;
}

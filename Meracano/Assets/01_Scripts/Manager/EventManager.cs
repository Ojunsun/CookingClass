using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BattleStartEvent();

public static class EventManager
{
    public static BattleStartEvent OnBattleStartEvent;
}

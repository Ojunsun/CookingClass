using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryUI : PopupUI
{
    public override void Awake()
    {
        EventManager.OnVictoryEvent += OnVictoryUIHandler;
    }

    private void OnVictoryUIHandler()
    {
        OpenPopupUI();
    }

    public override void OpenPopupUI()
    {
        base.OpenPopupUI();
    }

    public override void ClosePopupUI()
    {
        base.ClosePopupUI();
    }
}

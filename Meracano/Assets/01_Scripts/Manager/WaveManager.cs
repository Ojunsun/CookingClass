using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{
    public void BattleStartEventHandler() //버튼 이벤트 실행시 사용될 함수
    {
        Debug.Log("실행");
        EventManager.OnBattleStartEvent?.Invoke();
    }
}

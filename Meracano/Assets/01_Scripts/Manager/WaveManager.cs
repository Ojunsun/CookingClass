using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{
    public void BattleStartEventHandler() //��ư �̺�Ʈ ����� ���� �Լ�
    {
        Debug.Log("����");
        EventManager.OnBattleStartEvent?.Invoke();
    }
}

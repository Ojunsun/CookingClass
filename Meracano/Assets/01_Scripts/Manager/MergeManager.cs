using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoSingleton<MergeManager>
{
    public void FindCanMergePlayer(Player player) // ������ �����Ѥ��� ã�������̤��Ѥ� �Ԥ���
    {

    }

    public void MergePlayer(Player player1, Player player2)
    {
        player1.Upgrade();
        PoolManager.Instance.Push(player2);
        Debug.Log("Merge"); // ����
    }
}

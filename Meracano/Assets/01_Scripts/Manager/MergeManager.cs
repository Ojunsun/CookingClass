using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoSingleton<MergeManager>
{
    public void FindCanMergePlayer(Player player) // 레벨 같은 거 찾아주는 함수
    {
        int level = player.Level;
    }

    public void MergePlayer(Player player1, Player player2)
    {
        if (player1.Level != player2.Level)
        {
            return;
        }
        Debug.Log("Merge"); // 머지

        PoolManager.Instance.Push(player1);
        PoolManager.Instance.Push(player2);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoSingleton<MergeManager>
{
    public void FindCanMergePlayer(Player player) // 레베ㄹ 같ㅇㅡㄴ거 찾ㅇㅏㅈㅜㄴㅡㄴ 함ㅅㅜ
    {

    }

    public void MergePlayer(Player player1, Player player2)
    {
        player1.Upgrade();
        PoolManager.Instance.Push(player2);
        Debug.Log("Merge"); // 머지
    }
}

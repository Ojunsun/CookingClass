using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Camera MainCam;
    public PoolingListSO PoolingList;

    private void Awake()
    {
        MainCam = Camera.main;

        MakePool();
    }

    private void MakePool()
    {
        PoolManager.Instance = new PoolManager(transform);
        PoolingList.list.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.poolCount));
    }
}

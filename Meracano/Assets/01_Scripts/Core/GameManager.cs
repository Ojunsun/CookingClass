using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera mainCam;
    public PoolingListSO PoolingList;

    private void Awake()
    {
        mainCam = Camera.main;

        MakePool();
    }

    private void MakePool()
    {
        PoolManager.Instance = new PoolManager(transform);
        PoolingList.list.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.poolCount));
    }
}

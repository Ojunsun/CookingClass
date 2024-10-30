using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    private bool isEnterTrashcan;

    public void DropPlayer(Player p)
    {
        if (!isEnterTrashcan) return;

        // 쓰레기통 위에 마우스가 있을 경우에 버리고
        PoolManager.Instance.Push(p);
        // 코인 추가 로직까지
    }

    public void EnterTrashcan(Image image)
    {
        isEnterTrashcan = true;
        // 휴지통 이미지가 열리는 것으로 변경
        image.color = Color.red;
    }

    public void ExitTrashcan(Image image)
    {
        isEnterTrashcan = false;
        // 휴지통 이미지 원상태
        image.color = Color.gray;
    }
}

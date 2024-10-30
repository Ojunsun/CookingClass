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

        // �������� ���� ���콺�� ���� ��쿡 ������
        PoolManager.Instance.Push(p);
        // ���� �߰� ��������
    }

    public void EnterTrashcan(Image image)
    {
        isEnterTrashcan = true;
        // ������ �̹����� ������ ������ ����
        image.color = Color.red;
    }

    public void ExitTrashcan(Image image)
    {
        isEnterTrashcan = false;
        // ������ �̹��� ������
        image.color = Color.gray;
    }
}

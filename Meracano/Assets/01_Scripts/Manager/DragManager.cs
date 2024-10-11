using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoSingleton<DragManager>
{
    private bool isDragging;

    private Player draggedPlayer;
    private PositionPrefab currentPointedPosition;

    private void Update()
    {
        CheckPositionPref();// OnBattleEndEvent ����Ǹ� �̰� ��� ����Ǿ�� ��

        if (Input.GetMouseButtonDown(0))
        { 
            StartDrag(); 
        }

        if (isDragging && draggedPlayer != null)
        {
            DragPlayer();
        }

        if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }

    private Vector3 CheckMousePosition()
    {
        Vector3 pos = GameManager.Instance.MainCam.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }

    private void GetObjectInMousePosition()
    {
        if(draggedPlayer == null)
        {
            return;
        }

        Vector3 pos = CheckMousePosition();
        Collider2D[] colliders = Physics2D.OverlapPointAll(pos);

        foreach (var col in colliders)
        {
            if(col.TryGetComponent<Player>(out Player mergePlayer)) // ������ draggedplayer�� ������ ��
            {
                if(mergePlayer != draggedPlayer) // �� ���� �ٸ��� + ������ ���� ���
                {
                    MergeManager.Instance.MergePlayer(draggedPlayer, mergePlayer);
                }
                // �� ���� �ٸ��� + ������ �ٸ� ���
                else //
                {
                    currentPointedPosition?.SetPlayer(draggedPlayer);
                }
            }
        }
    }

    private void CheckPositionPref()
    {
        Vector3 pos = CheckMousePosition();
        Collider2D[] colliders = Physics2D.OverlapPointAll(pos);

        if (colliders.Length <= 0)
        {
            currentPointedPosition?.MouseExit();
            currentPointedPosition = null;

            return;
        }

        foreach (var col in colliders)
        {
            if (col.TryGetComponent<PositionPrefab>(out PositionPrefab pointedPos))
            {
                if (currentPointedPosition == pointedPos) return;

                pointedPos.MouseEnter();
                currentPointedPosition?.MouseExit();

                currentPointedPosition = pointedPos;
            }
        }
    }

    private void StartDrag()
    {
        Ray ray = GameManager.Instance.MainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && hit.collider.TryGetComponent<Player>(out Player p))
        {
            isDragging = true;
            draggedPlayer = p;
        }

        MergeManager.Instance.FindCanMergePlayer(draggedPlayer);
    }

    private void DragPlayer()
    {
        Vector3 pos = CheckMousePosition();
        pos.z = 0;
        draggedPlayer.transform.position = pos;
    }

    private void EndDrag()
    {
        GetObjectInMousePosition();
        isDragging = false;
        draggedPlayer = null;
    }
}

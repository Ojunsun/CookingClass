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
        CheckPositionPref();

        if (Input.GetMouseButtonDown(0))
        { 
            StartDrag(); // OnBattleEndEvent ����Ǹ� �̰� ����Ǿ�� �� �� ����
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
        Vector3 pos = CheckMousePosition();
        Collider2D[] colliders = Physics2D.OverlapPointAll(pos);

        foreach (var col in colliders)
        {
            if(col.TryGetComponent<Player>(out Player mergePlayer))
            {
                if(mergePlayer != draggedPlayer) // �� ���� �ٸ��� + ������ ���� ���
                {
                    Debug.Log("Merge"); // ����
                }
                else // ������ �ٸ� �÷��̾ ���� ���
                {

                }
            }
            else
            {
                currentPointedPosition.SetPlayer(draggedPlayer);
            }
        }
    }

    private void CheckPositionPref()
    {
        Vector3 pos = CheckMousePosition();
        Collider2D[] colliders = Physics2D.OverlapPointAll(pos);
        foreach (var col in colliders)
        {
            if (col.TryGetComponent<PositionPrefab>(out PositionPrefab pointedPos))
            {
                if (currentPointedPosition == pointedPos) return;

                pointedPos.MouseEnter();
                currentPointedPosition?.MouseExit();

                currentPointedPosition = pointedPos;
                Debug.Log("Pos");
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

    public void TryMergePlayer()
    {
        if (isDragging) return;
        Debug.Log("Merge");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragManager : MonoSingleton<DragManager>
{
    private bool isDragging;

    private Player draggedPlayer;
    private PositionPrefab firstPointedPosition;
    private PositionPrefab currentPointedPosition;

    private bool playingGame = false;

    private void Start()
    {
        EventManager.OnBattleStartEvent += OnPlayGameHandler;
    }

    private void OnPlayGameHandler()
    {
        playingGame = true;
    }

    public void OnDragGameHandler()
    {
        playingGame = false;
    }

    private void Update()
    {
        if(playingGame) { return; }
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
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

        Collider2D[] colliders = Physics2D.OverlapPointAll(CheckMousePosition());

        foreach (var col in colliders) // 3개 감지 posi playr drag 
        {
            if(col.TryGetComponent<Player>(out Player mergePlayer)) // 무조건 draggedplayer가 감지가 됨
            {
                if(mergePlayer != draggedPlayer)
                {
                    SpawnManager.Instance.MergePlayer(draggedPlayer, mergePlayer, firstPointedPosition, currentPointedPosition);
                }
                else // drag == drag
                {
                    if (currentPointedPosition == null) firstPointedPosition.SetEntity(draggedPlayer);
                    else currentPointedPosition.SetEntity(draggedPlayer);
                }
            }
        }

        UIManager.Instance.DropPlayer(draggedPlayer);
    }

    private void CheckPositionPref()
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(CheckMousePosition());

        if ((draggedPlayer != null && colliders.Length <= 1) || draggedPlayer == null) 
        {
            currentPointedPosition?.MouseExit();
            currentPointedPosition = null;

            return;
        }

        foreach (var col in colliders)
        {
            if (col.TryGetComponent<PositionPrefab>(out PositionPrefab pointedPos))
            {
                if (currentPointedPosition == pointedPos || !pointedPos.IsPlayerPos) return;

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

            firstPointedPosition = p.GetComponentInParent<PositionPrefab>();

            SpawnManager.Instance.FindCanMergePlayer(draggedPlayer);
        }
    }

    private void DragPlayer()
    {
        CheckPositionPref();
        draggedPlayer.transform.position = CheckMousePosition();
    }

    private void EndDrag()
    {
        GetObjectInMousePosition();

        isDragging = false;
        draggedPlayer = null;

        currentPointedPosition?.MouseExit();
        currentPointedPosition = null;

        SpawnManager.Instance.ResetDrag();
    }
}

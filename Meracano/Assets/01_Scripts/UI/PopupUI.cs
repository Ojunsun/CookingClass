using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUI : MonoBehaviour
{
    [Header("PopupSetting")]
    [SerializeField]
    protected float _panelFadeTime;
    [SerializeField]
    protected float _panelDelayTime;

    protected CanvasGroup _panel;

    private Coroutine _panelOpenCoroutine = null;

    public virtual void Awake()
    {
        _panel = GetComponent<CanvasGroup>();

        if (_panel != null)
        {
            _panel.alpha = 0;
            _panel.blocksRaycasts = false;
        }
    }

    public virtual void OpenPopupUI()
    {
        if( _panelOpenCoroutine != null)
            StopCoroutine(_panelOpenCoroutine);

        _panelOpenCoroutine = StartCoroutine(ShowPanelCoroutine(_panelDelayTime));
    }

    IEnumerator ShowPanelCoroutine(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        _panel.blocksRaycasts = true;
        _panel.DOFade(1, _panelFadeTime).SetUpdate(true).SetEase(Ease.InSine);
    }

    public virtual void ClosePopupUI()
    {
        _panel.blocksRaycasts = false;
        _panel.DOFade(0, _panelFadeTime).SetUpdate(true);
    }
}

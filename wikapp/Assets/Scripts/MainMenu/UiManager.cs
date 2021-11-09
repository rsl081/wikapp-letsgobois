using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public RectTransform mainPanel, setting,levels;

    public void ButtonMethod(string value)
    {
        switch (value)
        {
            case "MainMenuBtn":
                MoveUI(setting, new Vector2(0, 1660), 0.25f, 0f, Ease.OutFlash);
                MoveUI(mainPanel, new Vector2(0, 0), 0.25f, 0.25f, Ease.OutFlash);
                break;
            case "LevelBtn":
                MoveUI(mainPanel, new Vector2(-950, 0), 0.25f, 0f, Ease.OutFlash);
                MoveUI(levels, new Vector2(0, 0), 0.25f, 0f, Ease.OutFlash);
                break;
            case "SettingBtn":
                MoveUI(mainPanel, new Vector2(-950, 0), 0.25f, 0f, Ease.OutFlash);
                MoveUI(setting, new Vector2(0, 0), 0.25f, 0.25f, Ease.OutFlash);
                break;
            case "KwarterHomeBtn":
                MoveUI(levels, new Vector2(950, 0), 0.25f, 0f, Ease.OutFlash);
                MoveUI(mainPanel, new Vector2(0, 0), 0.25f, 0f, Ease.OutFlash);
                break;
        }
    }

    void FadeEffect(Image _image, float fadeTo, float fadeDuration, float delay)
    {
        _image.DOFade(fadeTo, fadeDuration);
        _image.DOFade(1, fadeDuration).SetDelay(delay).OnComplete(() => FadeEffect(_image, fadeTo, fadeDuration, delay));
    }

    void MoveUI(RectTransform _traansform, Vector2 position, float moveTime, float delayTime, Ease ease)
    {
        _traansform.DOAnchorPos(position, moveTime).SetDelay(delayTime).SetEase(ease);
    }
}

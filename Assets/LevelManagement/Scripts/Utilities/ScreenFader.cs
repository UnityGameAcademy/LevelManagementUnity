using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    [SerializeField]
    protected float _solidAlpha = 1f;

    [SerializeField]
    protected float _clearAlpha = 0f;

    [SerializeField]
    private float _fadeOnDuration = 2f;
    public float FadeOnDuration { get { return _fadeOnDuration; } }

    [SerializeField]
    private float _fadeOffDuration = 2f;
    public float FadeOffDuration { get { return _fadeOffDuration; } }

    [SerializeField]
    private MaskableGraphic[] graphicsToFade;

    protected void SetAlpha(float alpha)
    {
        foreach (MaskableGraphic graphic in graphicsToFade)
        {
            if (graphic != null)
            {
                graphic.canvasRenderer.SetAlpha(alpha);
            }
        }
    }

    private void Fade(float targetAlpha, float duration)
    {
        foreach (MaskableGraphic graphic in graphicsToFade)
        {
            if (graphic != null)
            {
                graphic.CrossFadeAlpha(targetAlpha, duration, true);
            }
        }
    }

    public void FadeOff()
    {
        SetAlpha(_solidAlpha);
        Fade(_clearAlpha, _fadeOffDuration);
    }

    public void FadeOn()
    {
        SetAlpha(_clearAlpha);
        Fade(_solidAlpha, _fadeOnDuration);
    }
}

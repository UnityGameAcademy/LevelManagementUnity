using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// specialized ScreenFader to hide the transition between scenes
public class TransitionFader : ScreenFader
{
    // duration of the transition
    [SerializeField]
    private float _lifetime = 1f;

    // delay before start fading
    [SerializeField]
    private float _delay = 0.3f;
    public float Delay { get { return _delay; } }

    // calculate the minimum lifetime
    protected void Awake()
    {
        _lifetime = Mathf.Clamp(_lifetime, FadeOnDuration + FadeOffDuration + _delay, 10f);
    }

    // coroutine to fade on, wait, and fade off
    private IEnumerator PlayRoutine()
    {
        SetAlpha(_clearAlpha);
        yield return new WaitForSeconds(_delay);

        FadeOn();
        float onTime = _lifetime - (FadeOffDuration + _delay);

        yield return new WaitForSeconds(onTime);

        FadeOff();
        Object.Destroy(gameObject, FadeOffDuration);
    }

    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }

    // instantiate a transition prefab and fade on/off
    public static void PlayTransition(TransitionFader transitionPrefab)
    {
        if (transitionPrefab != null)
        {
            TransitionFader instance = Instantiate(transitionPrefab, Vector3.zero, Quaternion.identity);
            instance.Play();
        }
    }
}


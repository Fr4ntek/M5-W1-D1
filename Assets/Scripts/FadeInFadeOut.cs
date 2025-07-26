using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    [SerializeField] private Image _imageColor;
    [SerializeField] private float _fadeTime = 5f;

    private int _target = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FadeImage(_target % 2));
            _target++;
        }
    }

    IEnumerator FadeImage(float targetAlpha)
    {
        Color color = _imageColor.color;
        float startAlpha = _imageColor.color.a;
        float time = 0f;
        while(time < _fadeTime)
        {
            time += Time.deltaTime;
            float partialAlpha = time / _fadeTime;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, partialAlpha);
            _imageColor.color = color;
            yield return null;
        }
    }
}

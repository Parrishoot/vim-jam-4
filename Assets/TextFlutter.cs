using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class TextFlutter
{
    private float letterDelay;
    private float bounceTime;
    private float bounceHeight;
    private TMP_Text text;

    public TextFlutter(TMP_Text text, float letterDelay=.1f, float bounceTime=.3f, float bounceHeight=20f)
    {
        this.letterDelay = letterDelay;
        this.bounceTime = bounceTime;
        this.bounceHeight = bounceHeight;
        this.text = text;
    }

    // Start is called before the first frame update
    public void Flutter(TweenCallback action)
    {
        DOTweenTMPAnimator animator = new DOTweenTMPAnimator(text);

        Sequence fullSequence = DOTween.Sequence();

        for (int i = 0; i < animator.textInfo.characterCount; ++i) {

            Sequence sequence = DOTween.Sequence();
            Vector3 currCharOffset = animator.GetCharOffset(i);

            sequence.AppendInterval(i * letterDelay);
            sequence.Append(animator.DOOffsetChar(i, currCharOffset + new Vector3(0, bounceHeight, 0), bounceTime / 2).SetEase(Ease.OutQuad));
            sequence.Join(animator.DOFadeChar(i, 1f, bounceTime / 2));
            sequence.Append(animator.DOOffsetChar(i, currCharOffset + new Vector3(0, -bounceHeight, 0), bounceTime / 2).SetEase(Ease.InQuad));

            fullSequence.Join(sequence.Play());
        }

        fullSequence.Play().OnComplete(action);
    }
}

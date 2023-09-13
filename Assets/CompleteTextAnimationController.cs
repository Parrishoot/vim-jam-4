using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompleteTextAnimationController : MonoBehaviour
{

    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    private float letterDelay = .1f;
    
    [SerializeField]
    private float bounceTime = .3f;
    
    [SerializeField]
    private float bounceHeight = 20f;


    private TextFlutter textFlutter;

    // Start is called before the first frame update
    void Start()
    {
        textFlutter = new TextFlutter(text, letterDelay, bounceTime, bounceHeight);
    }

    public void ShowCompleteText() {
        textFlutter.Flutter(() => {
            LevelManager.Instance.BeginNextSceneTransition();
        });
    }
}

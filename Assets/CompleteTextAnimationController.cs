using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompleteTextAnimationController : MonoBehaviour
{

    [SerializeField]
    private TMP_Text text;


    private TextFlutter textFlutter;

    // Start is called before the first frame update
    void Start()
    {
        textFlutter = new TextFlutter(text);
    }

    public void ShowCompleteText() {
        textFlutter.Flutter(() => {
            LevelManager.Instance.BeginNextSceneTransition();
        });
    }
}

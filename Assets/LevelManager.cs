using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
   
    [SerializeField]
    private CompleteTextAnimationController completeTextAnimationController;

    [SerializeField]
    private TransitionAnimationController transitionAnimationController;

    [SerializeField]
    private String nextScene;


    public void WinLevel() {
        completeTextAnimationController.ShowCompleteText();
    }

    public void BeginNextSceneTransition() {
        transitionAnimationController.TransitionOut();
    }

    public void LoadNextLevel() {
        SceneManager.LoadScene(nextScene);
    }

}

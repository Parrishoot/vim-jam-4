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
        transitionAnimationController.TransitionOut(LoadNextLevel);
    }

    public void LoadNextLevel() {
        SceneManager.LoadScene(nextScene);
    }

    public void RestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Death() {
        transitionAnimationController.TransitionOut(RestartScene);
    }

}

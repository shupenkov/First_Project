using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EndGameScreenEnable : MonoBehaviour
{
    public TransitionGameCamera transitionGameCamera;
    public TMP_Text timeResult;
    public GameObject screenEndGame;
    public AddResultEndGame addResultEndGame;
    private string playerNameResult;

    

    void EnableEndScreen()
    {
        screenEndGame.SetActive(true);
        timeResult.text = TimerController.instance.timeCounter.text;
    }

    private void OnEnable()
    {
        playerNameResult = transitionGameCamera.PlayerName;
        addResultEndGame.AddResult(playerNameResult, TimerController.instance.GetTimePlaying());
    }
}

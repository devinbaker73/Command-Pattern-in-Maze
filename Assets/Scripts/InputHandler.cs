using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Invoker invoker;
    private bool isRecording;
    private bool isReplaying;
    private PlayerController playerController;
    private Command buttonA, buttonD, buttonW, buttonS;

    private void Start()
    {
        this.invoker = gameObject.AddComponent<Invoker>();
        this.playerController = FindObjectOfType<PlayerController>();

        this.buttonA = new MoveLeft(playerController);
        this.buttonD = new MoveRight(playerController);
        this.buttonW = new MoveForward(playerController);
        this.buttonS = new MoveBack(playerController);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            invoker.ExecuteCommand(buttonA);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            invoker.ExecuteCommand(buttonD);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            invoker.ExecuteCommand(buttonW);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            invoker.ExecuteCommand(buttonS);
        }
        if(playerController.isOnButton())
        {
            isReplaying = true;
            isRecording = false;
            invoker.Revert();
        }
    }

    private void OnGUI()
    {
        if(GUILayout.Button("Start Recording"))
        {
            playerController.ResetPosition();
            isReplaying = false;
            isRecording = true;
            invoker.Record();
        }

        if (GUILayout.Button("Stop Recording"))
        {
            playerController.ResetPosition();
            isReplaying = false;
            isRecording = false;
        }

        if(!isRecording)
        {
            if (GUILayout.Button("Start Replay"))
            {
                playerController.ResetPosition();
                isReplaying = true;
                isRecording = false;
                invoker.Replay();
            }

            if (GUILayout.Button("Start Reverse"))
            {
                isReplaying = true;
                isRecording = false;
                invoker.Revert();
            }
        }
    }
}

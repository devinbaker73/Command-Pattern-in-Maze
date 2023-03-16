using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    private bool isRecording;
    private bool isReplaying;

    private List<Command> recordedCommands = new List<Command>();
    private Stack<Command> commandStack = new Stack<Command>();

    public void ExecuteCommand(Command aCommand)
    {
        if(aCommand.Execute() && isRecording)
        {
            recordedCommands.Add(aCommand);
            commandStack.Push(aCommand);
            Debug.Log("Recorded Command: " + aCommand);
        }
    }

    public void Record()
    {
        isRecording = true;
    }

    public void Replay()
    {
        isReplaying = true;

        if(recordedCommands.Count <= 0)
        {
            Debug.Log("There is nothing to replay");
        }
        else
        {
            foreach(Command aCommand in recordedCommands)
            {
                Debug.Log("Executing Command: " + aCommand);

                aCommand.Execute();
            }

            isReplaying = false;
        }
    }
    public void Revert()
    {
        isReplaying = true;

        if (recordedCommands.Count <= 0)
        {
            Debug.Log("There is nothing to replay");
        }
        else
        {
            foreach (Command aCommand in commandStack)
            {
                Debug.Log("Executing Command: " + aCommand);

                aCommand.Undo();
            }

            isReplaying = false;
        }
    }

}

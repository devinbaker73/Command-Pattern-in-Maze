using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : Command
{
    private PlayerController controller;

    public MoveBack(PlayerController controller)
    {
        this.controller = controller;
    }

    public override bool Execute()
    {
        return this.controller.MoveBack();
    }

    public override bool Undo()
    {
        return this.controller.MoveForward();
    }
}
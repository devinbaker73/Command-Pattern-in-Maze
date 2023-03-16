using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract bool Execute();
    public abstract bool Undo();
}

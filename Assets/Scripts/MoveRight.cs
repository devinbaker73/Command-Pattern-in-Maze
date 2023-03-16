public class MoveRight : Command
{
    private PlayerController controller;

    public MoveRight(PlayerController controller)
    {
        this.controller = controller;
    }

    public override bool Execute()
    {
        return this.controller.MoveRight();
    }

    public override bool Undo()
    {
        return this.controller.MoveLeft();
    }
}

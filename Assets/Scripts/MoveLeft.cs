public class MoveLeft : Command
{
    private PlayerController controller;

    public MoveLeft(PlayerController controller)
    {
        this.controller = controller;
    }

    public override bool Execute()
    {
        return this.controller.MoveLeft();
    }

    public override bool Undo()
    {
        return this.controller.MoveRight();
    }
}

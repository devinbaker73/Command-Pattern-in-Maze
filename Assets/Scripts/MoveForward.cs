public class MoveForward : Command
{
    private PlayerController controller;

    public MoveForward(PlayerController controller)
    {
        this.controller = controller;
    }

    public override bool Execute()
    {
        return this.controller.MoveForward();
    }

    public override bool Undo()
    {
        return this.controller.MoveBack();
    }
}
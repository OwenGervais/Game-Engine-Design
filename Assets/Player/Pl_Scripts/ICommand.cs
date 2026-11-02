using UnityEngine;

public interface ICommand
{
    void Execute(Player player);
}

//Vector2 movement from the player input
public class MoveCommand : ICommand
{
    private Vector2 movementDir;
    public MoveCommand(Vector2 movementDir)
    {
        this.movementDir = movementDir;
    }
    public void Execute(Player player)
    {
        player.SetMoveDirection(movementDir);
    }
}

//bool focuas from the player input
public class FocusCommand : ICommand
{
    private bool focused;
    public FocusCommand(bool focused)
    {
        this.focused = focused;
    }
    public void Execute(Player player)
    {
        player.SetFocus(focused);
    }
}
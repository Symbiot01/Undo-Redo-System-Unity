using UnityEngine;

public class MoveCommand : ICommand
{
    private PlayerMover _playerMover;
    private Vector3 _movement;

    public MoveCommand(PlayerMover playerMover, Vector3 movement)
    {
        _playerMover = playerMover;
        _movement = movement;
    }

    public void Execute()
    {
        _playerMover.Move(_movement);
    }
    public void Undo()
    {
        // Reverse the movement to undo
        _playerMover.Move(-_movement);
    }
}

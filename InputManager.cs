using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Assign the PlayerMover instance via the Inspector.
    public PlayerMover playerMover;
    public CommandInvoker commandInvoker;

    private void Start()
    {
        playerMover = GetComponent<PlayerMover>();
        commandInvoker = GetComponent<CommandInvoker>();    
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            movement = Vector3.up; // Adjust as needed.
            Debug.Log("Up arrow pressed.");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            movement = Vector3.down;
            Debug.Log("Down arrow pressed.");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movement = Vector3.left;
            Debug.Log("Left arrow pressed.");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movement = Vector3.right;
            Debug.Log("Right arrow pressed.");
        }

        // Execute a move command if a movement key was pressed.
        if (movement != Vector3.zero)
        {
            RunPlayerCommand(playerMover, movement);
        }

        // Undo with Q key.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Undo command executed.");
            CommandInvoker.UndoCommand();
        }

        // Redo with E key.
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Redo command executed.");
            CommandInvoker.RedoCommand();
        }
    }

    private void RunPlayerCommand(PlayerMover playerMover, Vector3 movement)
    {
        if (playerMover == null)
        {
            Debug.LogWarning("PlayerMover reference is missing!");
            return;
        }

        ICommand command = new MoveCommand(playerMover, movement);
        CommandInvoker.ExecuteCommand(command);
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private bool _gameStarted = false;
    public enum BatEnableType
    {
        Disabled = -1,
        Started = 0,
        Finalised = 1
    }
    
    public BatEnableType batEnableType = BatEnableType.Disabled;

    private BallProjectileController _ball;
    private BatCreator _batCreator;

    private void Start()
    {
        _ball = FindFirstObjectByType<BallProjectileController>();
        _batCreator = FindFirstObjectByType<BatCreator>();
    }

    public void CallbackMouseClicked(InputAction.CallbackContext context)
    {
        bool clickStatus = context.ReadValue<float>() == 1.0f;
        
        if (!_gameStarted)
        {
            // If mouse click up before game start - start game
            if (!clickStatus)
            {
                StartGame(Input.mousePosition);
            }
        }
        else if (batEnableType != BatEnableType.Finalised)
        {
            if (clickStatus)
            {
                // Start Bat Draw
                _batCreator.BatCreationToggle(MousePosToWorldPos(Input.mousePosition), BatCreator.BatEndType.Start);
                batEnableType = BatEnableType.Started;
            }
            else
            {
                // End Bat Draw
                _batCreator.BatCreationToggle(MousePosToWorldPos(Input.mousePosition), BatCreator.BatEndType.End);
                batEnableType = BatEnableType.Finalised;
            }
        }
    }

    public void CallbackMouseDrag(InputAction.CallbackContext context)
    {
        if (!_gameStarted)
        {
            RotateTrail(Input.mousePosition);
        }

        if (batEnableType != BatEnableType.Disabled)
        {
            _batCreator.RoatateBat(MousePosToWorldPos(Input.mousePosition));
        }
    }

    public void CallBackMouseRightClick(InputAction.CallbackContext context)
    {
        batEnableType = BatEnableType.Disabled;
        _batCreator.DisableBat();
    }

    private void RotateTrail(Vector3 mousePos)
    {
        Vector2 worldPos = MousePosToWorldPos(mousePos);
        _ball.RotateTrail(worldPos);
    }

    private void StartGame(Vector3 mousePos)
    {
        _gameStarted = true;
        
        Vector2 worldMousePos =MousePosToWorldPos(mousePos);
        
        _ball.ThrowBall(worldMousePos);
    }

    private Vector2 MousePosToWorldPos(Vector3 mousePos)
    {
        // Convert mouse position to world to get target position to throw ball
        mousePos.z = 0;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        
        return new Vector2(worldMousePos.x, worldMousePos.y);
    }
}

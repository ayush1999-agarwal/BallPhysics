using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private bool _gameStarted = false;

    private BallProjectileController _ball;

    private void Start()
    {
        _ball = FindFirstObjectByType<BallProjectileController>();
    }

    public void CallbackMouseClicked(InputAction.CallbackContext context)
    {
        bool clickStatus = context.ReadValue<float>() == 1.0f;

        // If mouse click before game start - start game
        if (!_gameStarted && clickStatus)
        {
            StartGame(Input.mousePosition);
        }
    }

    private void StartGame(Vector3 mousePos)
    {
        _gameStarted = true;

        // Convert mouse position to world to get target position to throw ball
        mousePos.z = 0;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        
        _ball.ThrowBall(new Vector2(worldMousePos.x, worldMousePos.y));
    }
}

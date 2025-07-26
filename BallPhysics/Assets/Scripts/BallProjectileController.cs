using System;
using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallProjectileController : MonoBehaviour
{
    [SerializeField] private int startImpulse;
    
    private Rigidbody2D _rigidBody;
    
    private bool _gameStarted = false;
    
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>() as Rigidbody2D;
        _rigidBody.gravityScale = 0;
    }

    private void OnMouseUp()
    {
        if (!_gameStarted)
        {
            _gameStarted = true;
            _rigidBody.gravityScale = 1;
            
            // Calculating the position on mouse up to throw the ball
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            
            ThrowBall(new Vector2(worldMousePos.x, worldMousePos.y));
        }
    }

    // Throws the ball in the direction after normalizing
    // Params: Vector2 targetPos: The direction in which the ball is to be thrown
    private void ThrowBall(Vector2 targetPos)
    {
        Vector2 dir = targetPos - new Vector2(transform.position.x, transform.position.y);
        dir = dir.normalized;
        
        _rigidBody.AddForce(dir * startImpulse, ForceMode2D.Impulse);
    }
}



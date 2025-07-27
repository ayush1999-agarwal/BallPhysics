using System;
using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallProjectileController : MonoBehaviour
{
    [SerializeField] private int startImpulse;
    
    private Rigidbody2D _rigidBody;
    
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>() as Rigidbody2D;
        _rigidBody.gravityScale = 0;
    }

    // Throws the ball in the direction after normalizing
    // Params: Vector2 targetPos: The direction in which the ball is to be thrown
    public void ThrowBall(Vector2 targetPos)
    {
        Vector2 dir = targetPos - new Vector2(transform.position.x, transform.position.y);
        dir = dir.normalized;
        
        _rigidBody.AddForce(dir * startImpulse, ForceMode2D.Impulse);
    }
}



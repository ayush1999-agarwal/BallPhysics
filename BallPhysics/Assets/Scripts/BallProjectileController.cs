using System;
using UnityEngine;

public class BallProjectileController : MonoBehaviour
{
    [SerializeField] private int startImpulse;
    [SerializeField] private GameObject startProjectileTrail;
    
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
        return;
        _rigidBody.gravityScale = 1;
        
        ToggleProjectileTrail(false);
        
        Vector2 dir = targetPos - new Vector2(transform.position.x, transform.position.y);
        dir = dir.normalized;
        
        _rigidBody.AddForce(dir * startImpulse, ForceMode2D.Impulse);
    }

    // Toggle the visiblity of the trail
    // Params: bool visibleStatus: Visibility status
    public void ToggleProjectileTrail(bool visibleStatus)
    {
        startProjectileTrail.SetActive(visibleStatus);
    }

    // Calculate the direction to target and rotate the trail
    public void RotateTrail(Vector2 targetPos)
    {
        targetPos -= new Vector2(transform.position.x, transform.position.y);
        float angleRot = (float)(Math.Atan2(targetPos.y , targetPos.x) * 180 / Mathf.PI);
        startProjectileTrail.transform.rotation = Quaternion.Euler(0, 0, angleRot);
    }
}



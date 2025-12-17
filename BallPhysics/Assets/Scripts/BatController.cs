using System;
using UnityEngine;

public class BatController : MonoBehaviour
{
    private InputController _inputController;

    private void Start()
    {
        _inputController = FindFirstObjectByType<InputController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       DisableBat();

        //TODO: Use Signal
        _inputController.batEnableType = InputController.BatEnableType.Disabled;
    }

    public void DisableBat()
    {
        BoxCollider2D colliderRef = GetComponent<BoxCollider2D>();
        colliderRef.enabled = false;
        this.gameObject.SetActive(false);
    }

    public void RotateBat(float newScaleX, Vector3 targetPos, float targetAngle)
    {
        transform.localScale = new Vector3(newScaleX, transform.localScale.y, transform.localScale.z);
        Rigidbody2D rigidbodyRef = GetComponent<Rigidbody2D>();
        rigidbodyRef.MovePosition(targetPos);
        rigidbodyRef.MoveRotation(targetAngle);
        
        BoxCollider2D colliderRef = GetComponent<BoxCollider2D>();
        colliderRef.size = new Vector2(newScaleX, transform.localScale.y);
    }
}

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
        Destroy(colliderRef);
        this.gameObject.SetActive(false);
    }
}

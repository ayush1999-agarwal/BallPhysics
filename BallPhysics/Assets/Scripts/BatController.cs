using UnityEngine;

public class BatController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BoxCollider2D colliderRef = GetComponent<BoxCollider2D>();
        Destroy(colliderRef);
        this.gameObject.SetActive(false);
    }
}

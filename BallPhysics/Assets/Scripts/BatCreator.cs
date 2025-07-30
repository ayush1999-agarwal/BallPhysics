using System.Collections.Generic;
using System;
using UnityEngine;

public class BatCreator : MonoBehaviour
{
    [SerializeField] private BatController _bat;
    private float batLength = 0.0f;
    public enum BatEndType
    {
        Start = 0,
        End = 1
    }
    private List<Vector2> _batEndPoints = new List<Vector2>();
    
    public void BatCreationToggle(Vector2 endPointPos, BatEndType endType)
    {
        if (_batEndPoints.Count >= 2)
        {
            _batEndPoints.Clear();
        }
        _batEndPoints.Add(endPointPos);

        if (endType == BatEndType.End && _batEndPoints.Count == 2)
        {
            SetBatTransform(_batEndPoints[(int)BatEndType.Start], _batEndPoints[(int)BatEndType.End]);
            _bat.gameObject.AddComponent<BoxCollider2D>();

            batLength = Vector2.Distance(_batEndPoints[(int)BatEndType.End], _batEndPoints[(int)BatEndType.Start]);
        }
    }

    public void RoatateBat(Vector2 targetPos)
    {
        _bat.gameObject.SetActive(true);
        
        if (_batEndPoints.Count == 2)
        {
            float newLength = Vector2.Distance(targetPos, _batEndPoints[(int)BatEndType.Start]);
            float newX = (_batEndPoints[(int)BatEndType.Start].x + (batLength * (targetPos.x - _batEndPoints[(int)BatEndType.Start].x)) / newLength);
            float newY = (_batEndPoints[(int)BatEndType.Start].y + (batLength * (targetPos.y - _batEndPoints[(int)BatEndType.Start].y)) / newLength);
            
            targetPos = new Vector2(newX, newY);
        }
        
        SetBatTransform(_batEndPoints[(int)BatEndType.Start], targetPos);
    }

    public void DisableBat()
    {
        _bat.DisableBat();
    }
    
    private void SetBatTransform(Vector2 startPos, Vector2 endPos)
    {
        // Calculate x scale of bat
        float length = Vector2.Distance(endPos, startPos);
        Vector2 targetPos = endPos - startPos;
        // Calculate rotation along z axis
        float angleRot = (float)(Math.Atan2(targetPos.y , targetPos.x) * 180 / Mathf.PI);

        // Calculate the position of bat - center of end and start point
        float xPos = (endPos.x + startPos.x) / 2.0f;
        float yPos = (endPos.y + startPos.y) / 2.0f;
            
        // Apply bat transform
        _bat.transform.position = new Vector3(xPos, yPos, 0.0f);
        _bat.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angleRot);
        _bat.transform.localScale = new Vector3(length, _bat.transform.localScale.y,_bat.transform.localScale.z);
    }
}

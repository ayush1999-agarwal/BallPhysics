using System.Collections.Generic;
using System;
using UnityEngine;

public class BatCreator : MonoBehaviour
{
    [SerializeField] private GameObject _bat;
    
    public enum BatEndType
    {
        Start = 0,
        End = 1
    }
    private List<Vector2> _batEndPoints = new List<Vector2>();
    
    public void BatCreationToggle(Vector2 endPointPos, BatEndType endType)
    {
        if (_batEndPoints.Count > (int)BatEndType.End)
        {
            _batEndPoints.Clear();
        }
        _batEndPoints.Add(endPointPos);

        if (endType == BatEndType.End)
        {
            // Calculate x scale of bat
            float length = Vector2.Distance(_batEndPoints[(int)BatEndType.End], _batEndPoints[(int)BatEndType.Start]);
            Vector2 targetPos = _batEndPoints[(int)BatEndType.End] - _batEndPoints[(int)BatEndType.Start];
            // Calculate rotation along z axis
            float angleRot = (float)(Math.Atan2(targetPos.y , targetPos.x) * 180 / Mathf.PI);

            // Calculate the position of bat - center of end and start point
            float xPos = (_batEndPoints[(int)BatEndType.End].x + _batEndPoints[(int)BatEndType.Start].x) / 2.0f;
            float yPos = (_batEndPoints[(int)BatEndType.End].y + _batEndPoints[(int)BatEndType.Start].y) / 2.0f;
            
            _bat.SetActive(true);
            // Apply bat transform
            _bat.transform.position = new Vector3(xPos, yPos, 0.0f);
            _bat.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angleRot);
            _bat.transform.localScale = new Vector3(length, _bat.transform.localScale.y,_bat.transform.localScale.z);
        }
    }
}

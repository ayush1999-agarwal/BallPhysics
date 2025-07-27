using System.Collections.Generic;
using System;
using UnityEngine;

public class BatCreator : MonoBehaviour
{
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
            float length = Vector2.Distance(_batEndPoints[(int)BatEndType.End], _batEndPoints[(int)BatEndType.Start]);
            Vector2 targetPos = _batEndPoints[(int)BatEndType.End] - _batEndPoints[(int)BatEndType.Start];
            float angleRot = (float)(Math.Atan2(targetPos.y , targetPos.x) * 180 / Mathf.PI);
            Debug.Log(angleRot + " " + length);
        }
    }
}

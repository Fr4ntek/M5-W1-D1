using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public enum ESERCIZIO { STANDARD, EASY, MEDIUM, HARD };

    [SerializeField] Transform _nucleus;
    [SerializeField] private float _orbitTime = 2f; // tempo per un giro completo
    [SerializeField] private float _radiusA = 1;
    [SerializeField] private float _radiusB = 2;
    [SerializeField] private ESERCIZIO _esercizio = ESERCIZIO.STANDARD;
    [SerializeField] private Vector3 inclination = Vector3.up;



    private float _angleDeg = 0f;
    private float _angleRad = 0f;
    private float x;
    private float y;

    //void OnDrawGizmos()
    //{
    //    if (_nucleus == null) return;

    //    Gizmos.color = Color.cyan;

    //    const int segments = 100;
    //    float step = 2 * Mathf.PI / segments;
    //    Vector3 prev = Vector3.zero;

    //    for (int i = 0; i <= segments; i++)
    //    {
    //        float theta = i * step;
    //        float x = Mathf.Cos(theta) * _radiusA;
    //        float y = Mathf.Sin(theta) * _radiusB;

    //        Vector3 localPos = new Vector3(x, y, 0);
    //        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, inclination.normalized);
    //        Vector3 worldPos = _nucleus.position + rotation * localPos;

    //        if (i > 0)
    //            Gizmos.DrawLine(prev, worldPos);

    //        prev = worldPos;
    //    }
    //}

    void Update()
    {
        switch (_esercizio)
        {
            case ESERCIZIO.STANDARD:
                _angleDeg += 360f * (Time.deltaTime / _orbitTime);
                if (_angleDeg >= 360f) _angleDeg -= 360f; // resetto _angleDeg

                _angleRad = _angleDeg * Mathf.Deg2Rad;
                x = Mathf.Cos(_angleRad) * _radiusA;
                y = Mathf.Sin(_angleRad) * _radiusA;
                transform.position = _nucleus.position + new Vector3(x, y, 0);
                break;
            case ESERCIZIO.EASY:
                _angleDeg += 360f * (Time.deltaTime / _orbitTime);
                if (_angleDeg >= 360f) _angleDeg -= 360f; // resetto _angleDeg

                _angleRad = _angleDeg * Mathf.Deg2Rad;
                x = Mathf.Cos(_angleRad) * _radiusA;
                y = Mathf.Sin(_angleRad) * _radiusB;
                transform.position = _nucleus.position + new Vector3(x, y, 0);
                break;
            case ESERCIZIO.MEDIUM:

                _angleDeg += 360f * (Time.deltaTime / _orbitTime);
                if (_angleDeg >= 360f) _angleDeg -= 360f; // resetto _angleDeg

                _angleRad = _angleDeg * Mathf.Deg2Rad;
                x = Mathf.Cos(_angleRad) * _radiusA;
                y = Mathf.Sin(_angleRad) * _radiusB;

                Vector3 localPos = new Vector3(x, y, 0);
                Quaternion rotation = Quaternion.FromToRotation(Vector3.up, inclination.normalized);
                Vector3 rotatedPos = rotation * localPos;

                transform.position = _nucleus.position + rotatedPos;
                break;
            case ESERCIZIO.HARD:
                break;
        }
        
            
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlar : MonoBehaviour
{
    [SerializeField] GameObject lookat;
    [SerializeField] float smooth;
    [SerializeField] int Expandx;
    [SerializeField] int Expandy;
    [SerializeField] Vector2 OffSet;

    private Vector3 offset;

   
    private void LateUpdate()
    {
        Vector3 vector3 = new Vector3(lookat.transform.position.x + Expandx, lookat.transform.position.y + Expandy, lookat.transform.position.z);
        Vector3 pos = transform.position;
        pos = Vector3.Lerp(pos, vector3, smooth);
        offset = new Vector3(OffSet.x, OffSet.y, 0.0f);
        pos.z = -17;
        transform.position = pos + offset;

        
    }
}

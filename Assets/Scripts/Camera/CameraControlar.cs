using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlar : MonoBehaviour
{
    [SerializeField] GameObject lookat;
    [SerializeField] float smooth;

    private void LateUpdate()
    {
      
            Vector3 pos = transform.position;
            pos = Vector3.Lerp(pos, lookat.transform.position, smooth);
            pos.z = -17;
            transform.position = pos;

        
    }
}

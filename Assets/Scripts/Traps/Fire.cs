using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{   public float firedelay;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    IEnumerator FireCoroutine()
    {   
        Vector2 Flower=gameObject.transform.position;
        GameObject bullet = Instantiate(bulletPrefab, Flower,Quaternion.identity);
        yield return new WaitForSeconds(firedelay);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right*bulletSpeed;
    }
    private void OnEnable()
    {
         StartCoroutine(FireCoroutine());
    }


}

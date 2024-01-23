using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{   public float firedelay;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    IEnumerator FireCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 Flower = gameObject.transform.position;
                GameObject bullet = Instantiate(bulletPrefab, Flower, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(firedelay);
        }
    }
    private void  OnEnable()
    {
         StartCoroutine(FireCoroutine());
    }


}

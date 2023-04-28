using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletBase // INHERITANCE
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ê⁄êG" + other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
        }
    }
}

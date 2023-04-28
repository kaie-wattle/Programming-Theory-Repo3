using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : BulletBase // INHERITANCE
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ê⁄êG" + other.gameObject.name);
        if (other.gameObject.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerController playerCon = other.gameObject.GetComponent<PlayerController>();
            if (!playerCon.isDamage)
            {
                Rigidbody playerRb = other.gameObject.GetComponent<Rigidbody>();
                playerRb.AddForce(transform.TransformDirection(Vector3.forward) * 20f, ForceMode.Impulse);
                playerCon.DamageBound();
                gameObject.SetActive(false);
            }
        }
    }
}

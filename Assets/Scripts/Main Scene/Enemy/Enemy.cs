using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour
{
    protected int life;
    public int point;
    protected MainManager mainManager;

    abstract protected void Attack();

    virtual protected void Damage(int damage)
    {
        life -= damage;
        if(life <= 0)
        {
            mainManager.UpdateScore(point);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Damage");
        Debug.Log(other);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player�ƐڐG");
            PlayerController playerCon = other.gameObject.GetComponent<PlayerController>();
            if(!playerCon.isDamage)
            {
                Rigidbody playerRb = other.gameObject.GetComponent<Rigidbody>();
                var v = other.gameObject.transform.position - transform.position;
                playerRb.AddForce(v * 20f, ForceMode.Impulse);
                playerCon.DamageBound();
            }
        }
        if(other.CompareTag("Bullet"))
        {
            Damage(1);
        }
    }
}

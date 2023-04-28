using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour // INHERITANCE
{
    private float lifeTime = 3f;
    [SerializeField] protected float speed;

    private void OnEnable()
    {
        lifeTime = 3f;
    }

    void FixedUpdate()
    {
        Move();
        DestroyObject();
    }

    protected virtual void Move()
    {
        transform.Translate(Vector3.forward * speed);
    }

    private void DestroyObject()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0f)
        {
            gameObject.SetActive(false);
        }
    }
}

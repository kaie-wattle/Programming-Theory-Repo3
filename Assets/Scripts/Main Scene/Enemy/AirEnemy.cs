using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemy : Enemy
{
    [SerializeField] private bool isAttack;
    [SerializeField] private int setLife;
    [SerializeField] private float shotCoolTime;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
    }

    private void OnEnable()
    {
        life = setLife;
    }

    private void Update()
    {
        if (mainManager.isGameActive)
        {
            IsAttack();
        }
    }

    private void FixedUpdate()
    {
        if (mainManager.isGameActive)
        {
            PlayerFocus();
        }
    }

    private void IsAttack()
    {
        shotCoolTime -= Time.fixedDeltaTime;
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 60f)
        {
            if (shotCoolTime <= 0f)
            {
                Attack();
            }
        }
    }

    private void PlayerFocus()
    {
        transform.LookAt(player.transform);
    }

    protected override void Attack()
    {
        Debug.Log("Attack");
        var bullet = EnemyBulletPool.instance.GetBulletObject();
        if (bullet != null)
        {
            bullet.SetActive(true);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
        }
        shotCoolTime = 4f;
    }
}

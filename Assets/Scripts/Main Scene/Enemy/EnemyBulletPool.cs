using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : BulletPoolBase
{
    public static EnemyBulletPool instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            return;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPool : BulletPoolBase
{
    public static PlayerBulletPool instance { get; private set; }

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

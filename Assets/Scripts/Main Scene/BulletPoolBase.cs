using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolBase : MonoBehaviour
{
    public int count;
    public GameObject bulletPrefab;
    public List<GameObject> bulletList;

    private void Start()
    {
        SetPool();
    }

    void SetPool()
    {
        for (int i = 0; i < count; i++)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bullet.transform.SetParent(this.transform);
            bulletList.Add(bullet);
        }
    }

    public GameObject GetBulletObject()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                return bulletList[i];
            }
        }
        return null;
    }
}

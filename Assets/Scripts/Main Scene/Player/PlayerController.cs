using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float rotateSpeed = 2f;
    public int zRotate;
    public bool isDamage;

    private Rigidbody playerRb;
    private MainManager mainManager;
    private float rotateLimit = 35f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
    }

    void Update()
    {
        if (mainManager.isGameActive)
        {
            CommandProcess();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mainManager.isGameActive)
        {
            PlayerControl();
        }
    }

    /// <summary>
    /// プレイヤー操作
    /// </summary>
    void PlayerControl()
    {
        PlayerMove();
    }

    #region プレイヤー移動処理

    /// <summary>
    /// プレイヤー移動処理
    /// </summary>
    void PlayerMove()
    {
        Move();
        RotateRuturn();
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    void Move()
    {
        zRotate = 0;
        float currentAngles = transform.localEulerAngles.x;
        if (transform.localEulerAngles.x > 180)
        {
            currentAngles -= 360;
        }
        Debug.Log(currentAngles);
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotateSpeed);
            zRotate = 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotateSpeed);
            zRotate = -1;
        }
        if (Input.GetKey(KeyCode.UpArrow) && currentAngles < rotateLimit)
        {
            transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * rotateSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow) && currentAngles > -rotateLimit)
        {
            transform.Rotate(new Vector3(-1, 0, 0) * Time.deltaTime * rotateSpeed);
        }
    }

    /// <summary>
    /// プレイヤーの回転角度を戻す
    /// </summary>
    void RotateRuturn()
    {
        float currentAngles = transform.eulerAngles.z;
        if (transform.eulerAngles.z > 180)
        {
            currentAngles -= 360;
        }
        if (currentAngles <= 2f && currentAngles >= -2f)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }
        else if (currentAngles > 0f)
        {
            transform.Rotate(new Vector3(0, 0, -1));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, 1));
        }
    }

    #endregion

    #region コマンド処理
    void CommandProcess()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Shot();
        }
    }

    void Shot()
    {
        var bullet = PlayerBulletPool.instance.GetBulletObject();
        if (bullet != null)
        {
            bullet.SetActive(true);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
        }
    }
    #endregion

    public void DamageBound()
    {
        if (mainManager.isGameActive)
        {
            isDamage = true;
            mainManager.UpdateLife(1);
            StartCoroutine(DamageTimeCountCoroutine());
        }
    }

    IEnumerator DamageTimeCountCoroutine()
    {
        yield return new WaitForSeconds(0.6f);
        playerRb.velocity = Vector3.zero;
        isDamage = false;
    }
}

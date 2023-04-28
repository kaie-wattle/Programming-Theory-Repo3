using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject target;
    private MainManager mainManager;

    void Start()
    {
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
    }

    void Update()
    {
        CameraPos();// ABSTRACTION
    }

    void CameraPos()
    {
        if (mainManager.isGameActive)
        {
            Vector3 targetPos = target.transform.position;
            Vector3 targetForward = target.transform.forward;
            targetPos.y += 2f;
            transform.position = targetPos - (targetForward * 7f);
            transform.LookAt(targetPos);
        }
    }
}

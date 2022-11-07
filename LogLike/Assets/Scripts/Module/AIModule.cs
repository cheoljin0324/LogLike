using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIModule : MonoBehaviour
{
    MainModule mainModule;
    float aggroRange = 10;
    float speed = 1f;

    private void Awake()
    {
        mainModule = GetComponent<MainModule>();
    }

    private void Update()
    {
        if (mainModule.Player != null && Vector3.Distance(transform.position, mainModule.Player.transform.position) < aggroRange)
        {
            mainModule.animator.SetBool("isBool", true);
            mainModule.animator.Play("Move");
            mainModule.SetDestination(mainModule.Player.transform.position, speed);
        }
        else
        {
            mainModule.animator.SetBool("isBool", false);
        }
    }

}

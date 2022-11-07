using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputModule : MonoBehaviour
{

    MainModule mainModule;

    private void Awake()
    {
        mainModule = GetComponent<MainModule>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LeftClick();
        }

        if (Input.GetMouseButtonDown(1))
        {
            RightClick();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InputSpace();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            lefetShift();
        }

        if (0 != Input.GetAxis("Vertical") || 0 != Input.GetAxis("Horizontal"))
        {
            InputKeyBoard();
        }

        if(Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            mainModule.animator.SetBool("Move", false);
            mainModule.playerIsMove = false;
        }
        
    }

    void LeftClick()
    {
        mainModule.FirstAttack();
    }

    void RightClick()
    {

    }

    void InputKeyBoard()
    {
        mainModule.MoveTo(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
    }

    void InputSpace()
    {

    }

    void lefetShift()
    {
        StartCoroutine(mainModule.DashTo());
    }
}

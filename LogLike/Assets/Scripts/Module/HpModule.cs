using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpModule : MonoBehaviour
{
    private int _hp = 10;
    public int Hp
    {
        get
        {
            return _hp;
        }
    }

    public void Damage(int damage)
    {
        Debug.Log("데미지 함수");
        if(_hp > 0)
        {
            Debug.Log("아야!");
            _hp -= damage;
            if(_hp <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

}

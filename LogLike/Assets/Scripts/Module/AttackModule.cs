using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackModule : MonoBehaviour
{
    public Collider attackCollider;
    public float Range;
    MainModule mainModule;

    public RaycastHit[] hit;
    public float MaxDistance;

    private void Awake()
    {
        mainModule = GetComponent<MainModule>();
    }

    public void ShotAttack(Transform setpos)
    {
        GameObject target = null;
        hit = Physics.RaycastAll(mainModule.shotPos.position, mainModule.shotPos.forward, MaxDistance);
        for(int i = 0; i<hit.Length; i++)
        {
            if (hit[i].collider.CompareTag("Monster"))
            {
                if (target==null || target.transform.position.magnitude > Vector3.Distance(transform.position, hit[i].transform.position))
                {
                    target = hit[i].transform.gameObject;
                }
            }
        }
        target.GetComponent<HpModule>().Damage(mainModule.useWeapown.weapownData.attacker);
    }


}

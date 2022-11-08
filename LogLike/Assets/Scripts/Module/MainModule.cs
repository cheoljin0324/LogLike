using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainModule : MonoBehaviour
{
    public GameObject Player;
    public Transform target;
    public Transform shotPos;
    public WeapownEntity useWeapown;
    private float rotationspd = 360.0f;

    [HideInInspector]
    public List<GameObject> SearchItem;

    private float xRotate, yRotate, xRotateMove, yRotateMove;
    float rotateSpeed = 30.0f;

    InputModule inputModule;
    CharacterController characterController;
    HpModule _hpModule;
    AttackModule _attackModule;
    NavMeshAgent agent;

    Collider[] itemToWorld;

    bool isDashing = false;
    int dashAtemp;
    float dashTime = 2f;

    public bool playerIsMove = false;

    public float spd = 3f;
    public float aggroRange = 10;

    float speed;

    public Animator animator;
    public float movespd;

    private void Awake()
    {
        inputModule = GetComponent<InputModule>();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        _hpModule = GetComponent<HpModule>();
        _attackModule = GetComponent<AttackModule>();
        if (GetComponent<NavMeshAgent>()!= null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }

    public void SetDestination(Vector3 dest, float? _speed = null)
    {
        agent.isStopped = false;
        if(_speed == null)
        {
            agent.speed = speed;
        }
        else
        {
            agent.speed = _speed.Value;
        }
        agent.destination = dest;
    }

    public void MoveTo(float x, float z)
    {
        if(playerIsMove == false)
        {
            playerIsMove = true;
            animator.Play("Move");
        }

        Vector3 direction = new Vector3(x, 0, z).normalized;
        direction *= movespd;
        if(Mathf.Abs(x)>0 || Mathf.Abs(z)>0)
        {
            animator.SetBool("Move", true);
            characterController.SimpleMove(direction);
            
        }
    }

    public IEnumerator DashTo()
    {
        if (!isDashing)
        {
            animator.Play("Dash");
            movespd *= 5;
            isDashing = true;
            Debug.Log("대쉬");
            yield return new WaitForSeconds(0.3f);
            Debug.Log("대쉬 끝");
            movespd /= 5;
            isDashing = false;
        }
    }

    public void ItemSearch()
    {
        itemToWorld = Physics.OverlapSphere(transform.position, 10f);
        SearchItem.Clear();
        for (int i = 0; i < itemToWorld.Length; i++)
        {
            if (itemToWorld[i].CompareTag("Weapown"))
            {
                SearchItem.Add(itemToWorld[i].gameObject);
            }
        }
    }

    void OnAnimatorIK()
    {
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.5f);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.5f);

        animator.SetIKPosition(AvatarIKGoal.LeftHand, target.position);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, target.rotation);

        animator.SetLookAtWeight(1.0f);
        animator.SetLookAtPosition(target.position);
    }

    public void FirstAttack()
    {
        _attackModule.ShotAttack(shotPos);
    }
}

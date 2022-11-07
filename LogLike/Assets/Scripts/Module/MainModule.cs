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

    InputModule inputModule;
    CharacterController characterController;
    HpModule _hpModule;
    AttackModule _attackModule;
    NavMeshAgent agent;

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
        speed = agent.speed;
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
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 3);
        }
    }

    public IEnumerator DashTo()
    {
        if (!isDashing)
        {
            animator.Play("Dash");
            movespd *= 4;
            isDashing = true;
            Debug.Log("대쉬");
            yield return new WaitForSeconds(0.5f);
            Debug.Log("대쉬 끝");
            movespd /= 4;
            isDashing = false;
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

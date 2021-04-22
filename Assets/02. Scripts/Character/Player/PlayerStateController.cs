using Hyunsang.Core;
using Hyunsang.UIs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Hyunsang.Characters
{
    [RequireComponent(typeof(NavMeshAgent)), RequireComponent(typeof(CharacterController))]
    public class PlayerStateController : State
    {
        #region Variables

        private NavMeshAgent navMeshAgent;
        private CharacterController characterController;
        private Animator animator;
        private JoyStick joyStick;

        readonly int hashMove = Animator.StringToHash("Move");
        readonly int hashAttackTrigger = Animator.StringToHash("AttackTrigger");
        readonly int hashAttackIndex = Animator.StringToHash("AttackIndex");
        readonly int hashDie = Animator.StringToHash("Die");
       


        #endregion Variables

        #region Unity Methods
        // Start is called before the first frame update
        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            characterController = GetComponent<CharacterController>();
            animator = GetComponentInChildren<Animator>();
            navMeshAgent.radius = 0.25f;
            navMeshAgent.height = 0.75f;
            navMeshAgent.speed = 1.0f;
            joyStick = GameObject.Find("D-Pad").GetComponent<JoyStick>();
        }

        // Update is called once per frame
        protected override void Update()
        {
            switch (state)
            {
                case CharacterState.Idle:
                    Idle();
                    break;
                case CharacterState.Move:
                    Move();
                    break;
                case CharacterState.Attack:
                    break;
                case CharacterState.Die:
                    break;
            }
        }

        #endregion Unity Methods
        protected override void Idle()
        {
            navMeshAgent.ResetPath();
            if(isAttack)
            {
                animator.SetInteger(hashAttackIndex, Random.Range(0, 2));
                animator.SetTrigger(hashAttackTrigger);
                state = CharacterState.Attack;
            }
            if (joyStick.IsTouch)
            {
                animator.SetBool(hashMove, true);
                state = CharacterState.Move;
            }
        }
        protected override void Move()
        {
            navMeshAgent.SetDestination(gameObject.transform.localPosition + joyStick.Dir);
            characterController.Move(navMeshAgent.velocity * Time.deltaTime);
            transform.LookAt(gameObject.transform.localPosition + joyStick.Dir);
            if (isAttack)
            {
                navMeshAgent.ResetPath();
                animator.SetBool(hashMove, false);
                animator.SetInteger(hashAttackIndex, Random.Range(0, 2));
                animator.SetTrigger(hashAttackTrigger);
                state = CharacterState.Attack;
            }
            if (!joyStick.IsTouch)
            {
                navMeshAgent.ResetPath();
                animator.SetBool(hashMove, false);
                state = CharacterState.Idle;
            }
        }
        protected override void Attack()
        {
            isAttack = false;
            if (joyStick.IsTouch)
            {
                animator.SetBool(hashMove, true);
                state = CharacterState.Move;
            }
            else 
            {
                state = CharacterState.Idle;
            }

        }
        public void ATTACK() => Attack();

        public override void Damage(int damage)
        {
            isDamage = true;
            GameManager.Instance.playerInfo.Damage(damage);
            if(GameManager.Instance.playerInfo.CurrentHp<0)
            {
                Die();
            }
            StartCoroutine("Damaged");
        }

        IEnumerator Damaged()
        {
            yield return new WaitForSeconds(1.0f);
            isDamage = false;
        }

        protected override void Die()
        {
            animator.SetBool(hashDie, true);
        }

        public void AttackButton()
        {
            isAttack = true;
        }

    }
}
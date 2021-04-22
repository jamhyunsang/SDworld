using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Hyunsang.Characters
{
    [RequireComponent(typeof(CharacterController)),RequireComponent(typeof(NavMeshAgent))]
    public class EnemyController : State
    {
        #region Variables

        [SerializeField]
        private EnemyInfo enemyInfo;

        public Transform target;

        #endregion Variables

        #region Unity Methods

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
                    Attack();
                    break;
                case CharacterState.Die:
                    break;
            }
        }

        #endregion Unity Methods

        #region Help Methods

        protected override void Idle()
        {
            
        }
        protected override void Move()
        {
            
        }
        protected override void Attack()
        {
            
        }
        public override void Damage(int damage)
        {
            
        }
        protected override void Die()
        {
            
        }

        #endregion Help Methods
    }

    [Serializable]
    public class EnemyInfo
    {
        [SerializeField]
        int hp, attackPoint;
        public float attackRange, targetCatchRange;
        public int Hp => hp;
        public int AttackPoint => attackPoint;
        public void Damage(int damage)
        {
            hp -= damage;
        }
    }
}

using Hyunsang.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyunsang.Characters
{
    public enum CharacterState
    {
        Idle,
        Move,
        Attack,
        Die
    }

    public abstract class State : MonoBehaviour
    {
        
        #region Variables 

        protected CharacterState state = CharacterState.Idle;
        public bool isAttack, isDamage;

        #endregion Variables


        protected abstract void Update();

        #region Help Methods
        protected abstract void Idle();
        protected abstract void Move();
        protected abstract void Attack();
        public abstract void Damage(int damage);
        protected abstract void Die();

        #endregion Help Methods
    }
}

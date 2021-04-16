using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyunsang.Characters
{
    [Serializable]
    public class PlayerInfo
    {
        [SerializeField]
        string id;
        [SerializeField]
        int level,exp;
        [SerializeField]
        int currentHp, maxHp;
        public int CurrentHp => currentHp;
        [SerializeField]
        int attackPoint, defPoint;
        [SerializeField]
        int stat_str, stat_dex, stat_int, stat_luk;

        public PlayerInfo(string id, int level, int currentHp, int maxHp, int attackPoint, int defPoint, int stat_str, int stat_dex, int stat_int, int stat_luk)
        {
            this.id = id;
            this.level = level;
            this.currentHp = currentHp;
            this.maxHp = maxHp;
            this.attackPoint = attackPoint;
            this.defPoint = defPoint;
            this.stat_str = stat_str;
            this.stat_dex = stat_dex;
            this.stat_int = stat_int;
            this.stat_luk = stat_luk;
        }

        public PlayerInfo(string id)
        {
            this.id = id;
            this.level = 1;
            this.currentHp = 50;
            this.maxHp = 50;
            this.attackPoint = stat_str*1;
            this.defPoint = stat_str * 1;
            this.stat_str = 23;
            this.stat_dex = 4;
            this.stat_int = 4;
            this.stat_luk = 4;
        }

        public void Damage(int damage)
        {
            currentHp -= damage;
        }

        public void Heel(int heel)
        {
            if(currentHp+heel>maxHp)
            {
                currentHp = maxHp;
            }
            else
            {
                currentHp += heel;
            }
        }
    }
}

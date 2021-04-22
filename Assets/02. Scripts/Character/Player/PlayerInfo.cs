using Hyunsang.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyunsang.Info
{
    [Serializable]
    public class PlayerInfo
    {
        [SerializeField]
        string userName;
        [SerializeField]
        int level, exp, attack, def, stat_str, stat_dex, stat_int, stat_luk, currentHp, maxHp;
        public int CurrentHp => currentHp;

        public PlayerInfo(string userName, int level, int currentHp, int maxHp, int attack, int def, int stat_str, int stat_dex, int stat_int, int stat_luk)
        { 
            this.userName = userName;
            this.level = level;
            this.currentHp = currentHp;
            this.maxHp = maxHp;
            this.attack = attack;
            this.def = def;
            this.stat_str = stat_str;
            this.stat_dex = stat_dex;
            this.stat_int = stat_int;
            this.stat_luk = stat_luk;
        }

        public PlayerInfo(string userName)
        {
            this.userName = userName;
            this.level = 1;
            this.currentHp = 50;
            this.maxHp = 50;
            this.stat_str = 30;
            this.stat_dex = 4;
            this.stat_int = 4;
            this.stat_luk = 4;
            this.def = stat_str * 1;
            this.attack = stat_str*1;
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

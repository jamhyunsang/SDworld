using Hyunsang.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyunsang.Core
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance = null;
        [SerializeField]
        public PlayerInfo plyerInfo;
        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public static GameManager Instance
        {
            get
            {
                if(null == instance)
                {
                    return null;
                }
                return instance;
            }
        }
    }
}

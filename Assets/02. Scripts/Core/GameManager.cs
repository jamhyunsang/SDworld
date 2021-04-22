using Firebase.Auth;
using Firebase.Database;
using Hyunsang.Info;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyunsang.Core
{
    public class GameManager : MonoBehaviour
    {
        #region Variables
        private static GameManager instance = null;
        public static GameManager Instance
        {
            get
            {
                if (null == instance)
                {
                    return null;
                }
                return instance;
            }
        }

       
       public PlayerInfo playerInfo;

        public FirebaseAuth auth;
        public FirebaseUser user;
        public DatabaseReference reference;
        #endregion Variables

        #region Unity Methods

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

        private void Start()
        {
            auth = FirebaseAuth.DefaultInstance;
            user = auth.CurrentUser;
            reference = FirebaseDatabase.DefaultInstance.RootReference;
        }

        #endregion Unity Methods

        #region Help Methods

        public void SignOut()
        {
            auth.SignOut();
        }

        public void Save()
        {
            
            string json = JsonUtility.ToJson(playerInfo);

            reference.Child(user.UserId).Child("PlayerInfo").SetRawJsonValueAsync(json);

        }


        #endregion Help Methods

    }
}

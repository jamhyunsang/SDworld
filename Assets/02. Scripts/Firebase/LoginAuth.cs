using Hyunsang.Core;
using System;
using TMPro;
using UnityEngine;

namespace Hyunsang.Firebase
{
    [Serializable]
    public class LoginAuth
    {
        #region Variables

        [SerializeField]
        private TMP_InputField inputID = null;
        [SerializeField]
        private TMP_InputField inputPW = null;
        [SerializeField]
        private GameObject loginPanel = null;
        [SerializeField]
        private GameObject createPanel = null;

        #endregion Variables

        #region Help Methods

        public void LoginBtn()
        {
            GameManager.Instance.auth.SignInWithEmailAndPasswordAsync(inputID.text, inputPW.text).ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }

                GameManager.Instance.user = task.Result;
                Debug.LogFormat("User signed in successfully: {0} ({1})",
                    GameManager.Instance.user.DisplayName, GameManager.Instance.user.UserId);
            });
        }

        public void CreateBtn()
        {
            loginPanel.SetActive(false);
            createPanel.SetActive(true);
        }
        #endregion Help Methods
    }
}
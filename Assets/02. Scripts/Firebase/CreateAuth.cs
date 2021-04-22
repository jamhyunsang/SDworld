using Hyunsang.Core;
using System;
using TMPro;
using UnityEngine;

namespace Hyunsang.Firebase
{
    [Serializable]
    public class CreateAuth
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

        #region  Help Methods

        public void CreateBtn()
        {
            GameManager.Instance.auth.CreateUserWithEmailAndPasswordAsync(inputID.text, inputPW.text).ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }

                // Firebase user has been created.
                GameManager.Instance.user = task.Result;
                Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                    GameManager.Instance.user.DisplayName, GameManager.Instance.user.UserId);
            });
        }

        public void CloseBtn()
        {
            loginPanel.SetActive(true);
            createPanel.SetActive(false);
        }

        #endregion Help Methods
    }
}

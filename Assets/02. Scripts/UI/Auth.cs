using Hyunsang.Core;
using Hyunsang.Firebase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auth : MonoBehaviour
{
    #region Variables

    [SerializeField]
    LoginAuth loginAuth;
    [SerializeField]
    CreateAuth createAuth;

    #endregion Variables

    #region Help Methods
    public void CreateBtn() => createAuth.CreateBtn();
    public void CloseBtn() => createAuth.CloseBtn();
    public void LoginBtn() => loginAuth.LoginBtn();
    public void NewCreateBtn() => loginAuth.CreateBtn();

    #endregion Help Methods
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyunsang.Cameras
{
    public class MainCamera : MonoBehaviour
    {
        #region Variables

        private Camera mainCamera;
        Rect rect;

        public float height;
        public float distance;
        [SerializeField]
        private  Transform player;

        #endregion Variables

        #region Unity Methods

        private void Awake()
        {
            mainCamera = GetComponent<Camera>();
            rect = mainCamera.rect;

            float scaleHeight = ((float)Screen.width / Screen.height) / ((float)16 / 9);
            float scaleWidth = 1f / scaleHeight;

            if(scaleHeight<1)
            {
                rect.height = scaleHeight;
                rect.y = (1f - scaleHeight) / 2f;
            }
            else
            {
                rect.width = scaleWidth;
                rect.x = (1f - scaleWidth) / 2f;
            }
        }

        private void Start()
        {
            height = 5f;
            distance = 10f;
            player = GameObject.Find("Player").GetComponent<Transform>();
        }

        private void LateUpdate()
        {
            HandleCamera();
        }

        #endregion Unity Methods

        #region Help Methods

        private void HandleCamera()
        {
            if(!player)
            {
                return;
            }
            Vector3 worldPosition = (Vector3.forward * -distance) + (Vector3.up * height);
            Vector3 finalTargetPosition = player.position;
            Vector3 finalPosition = finalTargetPosition + worldPosition;
            transform.position = Vector3.Lerp(transform.position, finalPosition, 1.0f);
            transform.LookAt(player.position);
        }
        #endregion Help Methods
    }
}
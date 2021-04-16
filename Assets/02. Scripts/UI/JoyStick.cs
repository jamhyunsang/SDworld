using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hyunsang.UIs
{
    public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        #region Variables
        // 백그라운드
        [SerializeField]
        private RectTransform backGroundRect;
        // 조이스틱
        [SerializeField]
        private RectTransform joyStickRect;
        // 백그라운드 반지름
        private float backGroundRadius;
        // 터치상태
        private bool isTouch;
        public bool istouch => isTouch;
        // 방향 
        private Vector3 dir;
        public Vector3 Dir => dir;
        #endregion Variables

        #region Unity Methods

        // Start is called before the first frame update
        void Start()
        {
            backGroundRadius = backGroundRect.rect.width * 0.5f;
        }

        #endregion UnityMetods

        #region Help Methods

        // 터치 시작
        public void OnPointerDown(PointerEventData eventData)
        {
            isTouch = true;
        }

        // 드래그
        public void OnDrag(PointerEventData eventData)
        {
            Vector2 value = eventData.position - (Vector2)backGroundRect.position;
            value = Vector2.ClampMagnitude(value, backGroundRadius);
            joyStickRect.localPosition = value;
            value = value.normalized;
            dir = new Vector3(value.x, 0, value.y);
        }

        // 터치 끝
        public void OnPointerUp(PointerEventData eventData)
        {
            isTouch = false;
            joyStickRect.localPosition = Vector3.zero;
        }

        #endregion Help Methods
    }
}
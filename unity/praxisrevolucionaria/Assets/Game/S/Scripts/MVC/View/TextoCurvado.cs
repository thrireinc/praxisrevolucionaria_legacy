namespace Game.S.Scripts.MVC.View
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    [ExecuteInEditMode]
    public class TextoCurvado : Text
    {
        public float radius = 0.5f;
        public float wrapAngle = 360.0f;
        public float scaleFactor = 100.0f;
        private float _radius = -1;
        private float _scaleFactor = -1;
        private float _circumference = -1;
        private float Circumference
        {
            get
            {
                if (Math.Abs(_radius - radius) < .01f && Math.Abs(_scaleFactor - scaleFactor) < .01f) return _circumference;
                _circumference = 2.0f * Mathf.PI * radius * scaleFactor;
                _radius = radius;
                _scaleFactor = scaleFactor;
                return _circumference;
            }
        }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            base.OnPopulateMesh(vh);
            var stream = new List<UIVertex>();
            vh.GetUIVertexStream(stream);

            for (var i = 0; i < stream.Count; i++)
            {
                var v = stream[i];
                var position = v.position;
                var percentCircumference = position.x / Circumference;
                var offset = Quaternion.Euler(0.0f, 0.0f, -percentCircumference * 360.0f) * Vector3.up;
                
                v.position = offset * radius * scaleFactor + offset * position.y;
                v.position += Vector3.down * radius * scaleFactor;
                stream[i] = v;
            }

            vh.AddUIVertexTriangleStream(stream);
        }
        private void Update()
        {
            var sizeDelta = rectTransform.sizeDelta;
            
            if (radius <= 0.0f)
                radius = 0.001f;

            if (scaleFactor <= 0.0f)
                scaleFactor = 0.001f;

            rectTransform.sizeDelta = new Vector2(Circumference * wrapAngle / 360.0f, sizeDelta.y);
        }
    }
}
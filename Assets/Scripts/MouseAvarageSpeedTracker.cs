using UnityEngine;

namespace Assets.Scripts
{
    class MouseAvarageSpeedTracker : AbstractTimeAvarageTracker
    {
        public float Epsilon;

        private Vector3 prevPosition;
        private bool inited;


        protected override float GetNewValue()
        {
            float newValue = 0;

            if (inited)
            {
                float delta = (Input.mousePosition - prevPosition).magnitude;
                if (delta >= Epsilon)
                    newValue = delta / Time.deltaTime;
            }

            prevPosition = Input.mousePosition;
            inited = true;

            return newValue;
        }
    }
}
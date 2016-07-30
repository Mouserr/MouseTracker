using UnityEngine;

namespace Assets.Scripts
{
    public class MouseSpeedTracker : AbstractTracker
    {
        public float Epsilon;

        private Vector3 prevPosition;
        private bool inited = false;


        private void Update()
        {
            if (inited)
            {
                float delta = (Input.mousePosition - prevPosition).magnitude;
                if (delta < Epsilon)
                    CurrentValue = 0;
                else
                    CurrentValue = delta / Time.deltaTime;
            }

            prevPosition = Input.mousePosition;
            inited = true;
        }
    }
}

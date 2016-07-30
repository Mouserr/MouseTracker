using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class AbstractTimeAvarageTracker : AbstractTracker
    {
        [SerializeField] private int valuesCount = 15;

        private Queue<float> prevValues;

        private void Awake()
        {
            prevValues = new Queue<float>(valuesCount);
        }

        private void Update()
        {
            float newValue = GetNewValue();
            prevValues.Enqueue(newValue);
            if (prevValues.Count >= valuesCount)
            {
                CurrentValue = CurrentValue + newValue / valuesCount - prevValues.Dequeue() / valuesCount;
            }
            else
            {
                CurrentValue = CurrentValue + newValue / prevValues.Count;
            }
        }

        protected abstract float GetNewValue();
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TrackerLabel : MonoBehaviour
    {
        [SerializeField] private AbstractTracker tracker;
        [SerializeField] private Text currentLabel;
        [SerializeField] private Text maximumLabel;
        private float maximum;

        private void Update()
        {
            currentLabel.text = getValueString(tracker.CurrentValue);
            if (tracker.CurrentValue > maximum)
            {
                maximum = tracker.CurrentValue;
                maximumLabel.text = getValueString(maximum);
            }
        }


        private string getValueString(float value)
        {
            return Mathf.Max(0 , Mathf.FloorToInt((value/Screen.width)*100)).ToString();
        }
    }
}
using UnityEngine;

namespace MyNamespace
{
    public abstract class HorizontalInputProviderBase : MonoBehaviour
    {
        public abstract void OnUpdate();
        public abstract float GetCurrentInput(float currentPosition, float speed);
    }
}
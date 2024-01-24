using Sirenix.OdinInspector;
using UnityEngine;

namespace SystemsLibrary.AI
{
    [CreateAssetMenu(fileName = "NewMotive", menuName = "SystemsLibrary/AI/Motive", order = 1)]
    public class Motive: ScriptableObject
    {
        public string Name;
        [PropertyRange(-100, 100)] public float StartingAmount;
        [PropertyRange(0, 10)] public float DecrimentalAmount;
    }
}
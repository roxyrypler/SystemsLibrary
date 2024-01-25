using UnityEngine;

namespace Plugins.SystemsLibrary.Runtime.UI.Types.ScriptableObjects.Variables
{
    [CreateAssetMenu(menuName = "ModularSystem/Variables/FloatVariable", fileName = "FloatVariable")]
    public class FloatVariable: ScriptableObject
    {
        public float Value;
    }
}
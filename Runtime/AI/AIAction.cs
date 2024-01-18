using System;
using UnityEngine;

namespace SystemsLibrary.AI
{
    [Serializable]
    public abstract class AIAction: MonoBehaviour
    {
        public Motive motive;
        public abstract float EvaluateAction(AIEntity ai);
        public abstract void ExecuteAction(AIEntity ai);
    }
}
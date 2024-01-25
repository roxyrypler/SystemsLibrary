namespace Plugins.SystemsLibrary.Runtime.UI.Types.ScriptableObjects.Variables
{
    public class FloatReference
    {
        public bool UseConstant = true;
        public float ConstantValue;
        public FloatVariable Variable;

        public float Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }
    }
}
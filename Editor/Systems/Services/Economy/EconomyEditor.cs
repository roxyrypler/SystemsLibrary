using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using SystemsLibrary.Runtime;

namespace SystemsLibrary.Editor
{
    public class EconomyEditor
    {

        [Button]
        void CreateEconomySystem()
        {
            Transform systemsObject = CreateSystemsObject();
            CreateEconomyObject(systemsObject);
        }

        Transform CreateSystemsObject()
        {
            var obj = GameObject.Find("Systems");
            GameObject systemsObject = null;
            if (obj == null)
            {
                systemsObject = new GameObject("Systems");
                // Make the operation undoable
                Undo.RegisterCreatedObjectUndo(systemsObject, "Create Systems Object");
                systemsObject.transform.SetParent(null);
                return systemsObject.transform;
            }
            else
            {
                return obj.transform;
            }
        }

        void CreateEconomyObject(Transform systemsObject)
        {
            Transform obj = systemsObject.Find("Economy");
            if (obj == null)
            {
                GameObject EconomyObject = new GameObject("Economy");
                EconomyObject.AddComponent<Economy>();
                Undo.RegisterCreatedObjectUndo(EconomyObject, "Create Economy Object");
                EconomyObject.transform.SetParent(systemsObject);
            } else
            {
                Debug.LogWarning("Economy System already exists");
            }
        }
    }
}

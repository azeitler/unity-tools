using UnityEditor;
using UnityEngine;

namespace A6Z6.UnityTools.Menu
{
    public static class GameObjectMenu
    {
        public static bool IsAsset(this Object obj)
        {
            return AssetDatabase.Contains(obj);
        }

        [MenuItem("GameObject/Hierarchy/Delete all Children #%d", false, 155)]
        private static void DeleteAllChildren()
        {
            var transforms = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

            foreach (var transform in transforms)
            {
                while (transform.childCount > 0)
                {
                    Object.DestroyImmediate(transform.GetChild(0).gameObject);
                }
            }
        }

        [MenuItem("GameObject/Hierarchy/Delete all Children #%d", true, 155)]
        private static bool DeleteAllChildrenValidate()
        {
            return Selection.activeGameObject != null && !Selection.activeGameObject.IsAsset();
        }

        [MenuItem("GameObject/Toggle Active Recursively (all) %t", false, 20)]
        private static void ToggleActive_Recursively()
        {
            foreach (var currentTransform in Selection.transforms)
            {
                currentTransform.gameObject.SetActive(!currentTransform.gameObject.activeInHierarchy);
            }
        }

        [MenuItem("GameObject/Toggle Active Recursively (all) %t", true, 20)]
        private static bool ValidateToggleActive_Recursively()
        {
            return Selection.activeTransform;
        }

        [MenuItem("GameObject/Toggle Active Children %#t", false, 21)]
        private static void ToggleActive_Children()
        {
            foreach (var currentTransform in Selection.transforms)
            {
                currentTransform.gameObject.SetActive(!currentTransform.gameObject.activeSelf);
            }
        }

        [MenuItem("GameObject/Toggle Active Children %#t", true, 21)]
        private static bool ValidateToggleActive_Children()
        {
            return Selection.activeTransform != null;
        }

        [MenuItem("GameObject/Toggle Active Parent #&t", false, 22)]
        private static void ToggleActive_Parent()
        {
            foreach (var currentTransform in Selection.transforms)
            {
                currentTransform.gameObject.SetActive(!currentTransform.gameObject.activeSelf);
            }
        }

        [MenuItem("GameObject/Toggle Active Parent #&t", true, 22)]
        private static bool ValidateToggleActive_Parent()
        {
            return Selection.activeTransform != null;
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace jomi.utils {
#if UNITY_EDITOR
    public static class CEditorFunc
    {
        public static int MakePopupOfResources<T>(int currentSelection, SerializedProperty serializedProperty, string path, string label = "Choose: ") where T : UnityEngine.Object
        {
            T[] ObjectList = Resources.LoadAll<T>(path);
            currentSelection = EditorGUILayout.Popup(label, currentSelection, Array.ConvertAll(ObjectList, Input => Input.name));
            if (ObjectList.Length <= currentSelection) return 0;
            serializedProperty.boxedValue = ObjectList[currentSelection];
            return currentSelection;
        }
    }
#endif
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace jomi.utils
{
    public class MenuFunctions : MonoBehaviour
    {
#if UNITY_EDITOR

        [MenuItem("JomiHelper/AddSeparator")]
        static void AddSeparator() => new GameObject("---------------------").transform.position = Vector3.zero;

        [MenuItem("JomiHelper/ResetPivot")]
        static void ResetPivot()
        {
            foreach (GameObject g in Selection.gameObjects)
            {
                if(g.transform.parent == null) continue;
                if(!g.TryGetComponent(out MeshFilter mf)) continue;
                
                Vector3 finalPos = mf.sharedMesh.bounds.center - new Vector3(0, mf.sharedMesh.bounds.extents.y, 0);
                g.transform.localPosition = -finalPos;
                
            }
        }
#endif

    }
}

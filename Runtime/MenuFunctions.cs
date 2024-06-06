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

#endif

    }
}

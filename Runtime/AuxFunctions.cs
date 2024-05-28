using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace jomi.utils
{
    public static class Jaux
    {
        /// <summary> (Make a description) </summary> 
        public static bool Exists<T>(T elementT, List<T> listT, string pro) where T : struct
        {
            foreach (T ele in listT)
                if (ele.GetType().GetField(pro).GetValue(ele).ToString() ==
                        elementT.GetType().GetField(pro).GetValue(elementT).ToString()) return true;
            return false;
        }

        /// <summary> (Make a description) </summary> 
        public static Vector3 Dontknow(Vector3 origin, Vector3 direction, float y) => origin - direction * ((origin.y - y) / direction.y);

        /// <summary> (Make a description) </summary>
        public static Vector3 GetcurrentMousePosition(Camera camera, float targetY)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            return Dontknow(ray.origin, ray.direction, targetY);
        }


        #if UNITY_EDITOR
        /// <summary>
        /// With a folders path in the assets returns an array of sprites from a sprite sheet
        /// </summary>
        /// <param name = "spShPath"> Sprite sheet path </param>
        /// <returns> An array of sprites </returns>
        public static Sprite[] LoadSpriteSheetFromAssets(string spShPath)
        {
            UnityEngine.Object[] objs =  AssetDatabase.LoadAllAssetRepresentationsAtPath(spShPath);
            Sprite[] sprites = new Sprite[objs.Length];
            for (int i = 0; i < objs.Length; i++)
            {
                sprites[i] = objs[i] as Sprite;
            }
            return sprites;

        }
#endif

        public static int[] FindAllIndexOf<T>(this T[] a, Predicate<T> match)
        {
            T[] subArray = Array.FindAll<T>(a, match);
            return (from T item in subArray select Array.IndexOf(a, item)).ToArray();
        }

        public static int[] FindAllIndexOfBasic<T>(this T[] a, Predicate<T> match)
        {
            List<int> arr = new List<int>();

            for(int i = 0; i < a.Length; i++)
            {
                if (match(a[i]))
                {
                    arr.Add(i);
                }
            }
            return arr.ToArray();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyMath
{
    public static class DrawVector2D
    {

        public static void DoDraw(Vector3 vector, Color color)
        {
            Debug.DrawLine(Vector3.zero, vector, color);
        }

        public static void DoDraw(Vector3 origin, Vector3 vector, Color color)
        {
            Debug.DrawLine(origin, origin + vector, color);
        }
        public static void Draw(this Vector3 vector, Color color)
        {
            DoDraw(vector, color);
        }
        public static void Draw(this Vector3 vector, Vector3 origin, Color color)
        {
            DoDraw(origin, vector, color);
        }
    }
}
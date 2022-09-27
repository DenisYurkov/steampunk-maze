using UnityEditor;
using UnityEngine;

namespace Steampunk.Code.Editor
{
    [InitializeOnLoad]
    public class HierarchyColor
    {
        static HierarchyColor() => EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindow;

        private static void HandleHierarchyWindow(int instanceID, Rect selectRect)
        {
            var instance = EditorUtility.InstanceIDToObject(instanceID);

            if (instance != null)
            {
                if (instance.ToString().StartsWith("*"))
                {
                    var colorText = "purple";
                    
                    EditorGUI.DrawRect(selectRect, Color.yellow);
                    RenderText(selectRect, colorText, instance);
                }

                if (instance.ToString().StartsWith("-"))
                {
                    var colorText = "black";
                
                    EditorGUI.DrawRect(selectRect, Color.magenta);
                    RenderText(selectRect, colorText, instance);
                }
                
                if (instance.ToString().StartsWith("%"))
                {
                    var colorText = "#4C5270";
                
                    EditorGUI.DrawRect(selectRect, Color.cyan);
                    RenderText(selectRect, colorText, instance);
                }

                if (instance.ToString().StartsWith("+"))
                {
                    var colorText = "black";
                
                    EditorGUI.DrawRect(selectRect, Color.green);
                    RenderText(selectRect, colorText, instance);
                }
                
                if (instance.ToString().StartsWith("^"))
                {
                    var colorText = "black";
                
                    EditorGUI.DrawRect(selectRect, Color.white);
                    RenderText(selectRect, colorText, instance);
                }
                
                if (instance.ToString().StartsWith("&"))
                {
                    var colorText = "white";
                
                    EditorGUI.DrawRect(selectRect, Color.blue);
                    RenderText(selectRect, colorText, instance);
                }
                
                if (instance.ToString().StartsWith("#"))
                {
                    var colorText = "white";
                
                    EditorGUI.DrawRect(selectRect, Color.red);
                    RenderText(selectRect, colorText, instance);
                }
            }
        }

        private static void RenderText(Rect selectRect, string colorText, Object instance)
        {
            var guiStyle = new GUIStyle
            {
                richText = true,
                alignment = TextAnchor.MiddleCenter
            };

            var text = $"<b><size=13><color={colorText}>" + instance.name.Remove(0, 1) + "</color></size></b>";
            EditorGUI.LabelField(selectRect, text, guiStyle);
        }
    }
}
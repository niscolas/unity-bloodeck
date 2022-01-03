using System;
using niscolas.UnityUtils.Core.Extensions;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Creatable.Editor
{
    [CustomPropertyDrawer(typeof(CreatableAttribute))]
    public class CreatableAttributeDrawer : PropertyDrawer
    {
        private const float ButtonWidthRatio = 0.05f;
        private const float SpacingRatio = 0.01f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Rect propertyRect = position.PadRight(position.width * (ButtonWidthRatio + SpacingRatio));
            Rect buttonRect = position.PadLeft(position.width * (1 - ButtonWidthRatio));

            Type propertyType = property.GetRealType();
            bool isScriptableObjectField = propertyType.IsSubclassOf(typeof(ScriptableObject));

            if (!isScriptableObjectField)
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
            else
            {
                EditorGUI.PropertyField(propertyRect, property, label, true);
                DrawCreateButton(buttonRect, propertyType, property);
            }
        }

        private void DrawCreateButton(Rect position, Type scriptableObjectType, SerializedProperty targetProperty)
        {
            if (!GUI.Button(position, "+"))
            {
                return;
            }

            string targetPath = EditorUtility.SaveFilePanel(
                "Select the location of the ScriptableObject", 
                "Assets", 
                "SO",
                "asset");

            if (string.IsNullOrEmpty(targetPath))
            {
                return;
            }
            
            Object createdAsset = ScriptableObject.CreateInstance(scriptableObjectType);
            createdAsset.Create(targetPath.AsProjectRelativePath());
            
            targetProperty.objectReferenceValue = createdAsset;
            targetProperty.serializedObject.ApplyModifiedProperties();
            targetProperty.serializedObject.Update();
        }
    }
}
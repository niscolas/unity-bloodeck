using System;
using System.Reflection;
using UnityEditor;

namespace niscolas.UnityUtils.Core.Extensions
{
    public static class SerializedPropertyExtensions
    {
        public static Type GetRealType(this SerializedProperty property)
        {
            string[] slices = property.propertyPath.Split('.');
            Type type = property.serializedObject.targetObject.GetType();

            for (int i = 0; i < slices.Length; i++)
                if (slices[i] == "Array")
                {
                    i++;
                    type = type.GetElementType();
                }
                else
                {
                    type = type.GetField(
                        slices[i],
                        BindingFlags.NonPublic |
                        BindingFlags.Public |
                        BindingFlags.FlattenHierarchy |
                        BindingFlags.Instance).FieldType;
                }

            return type;
        }
    }
}
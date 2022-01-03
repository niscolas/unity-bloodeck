using System;
using UnityEngine;

namespace Creatable
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class CreatableAttribute : PropertyAttribute { }
}
﻿using UnityEngine;

namespace SO_Utilities
{
    [CreateAssetMenu(menuName = "Variable/Int")]
    public class IntVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline] public string developerDescription = "";
#endif
        public int value;

        public void SetValue(int value)
        {
            this.value = value;
        }

        public void SetValue(IntVariable value)
        {
            this.value = value.value;
        }

        public void ApplyChange(int amount)
        {
            value += amount;
        }

        public void ApplyChange(IntVariable amount)
        {
            value += amount.value;
        }
    }
}
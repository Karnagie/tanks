using TMPro;
using UnityEngine;

namespace Core.Behaviours
{
    public class UnitBehaviour : MonoBehaviour
    {
        public Transform Transform;
        public Collider2D Collider;

        public TMP_Text Name;
        public TMP_Text Health;
        public TMP_Text Armor;
        public TMP_Text Speed;
    }
}
using Core.Models.Systems;
using Infrastructure.Helpers;
using UnityEngine;

namespace Core.Models
{
    public class Unit : ISingleSystem
    {
        public string Name { get; }
        public Transform Transform { get; }
        public Observable Killed { get; } = new();
        public Fraction Fraction { get; }

        public Unit(
            string name, 
            Transform transform,
            Fraction fraction)
        {
            Name = name;
            Transform = transform;
            Fraction = fraction;
        }
    }

    public enum Fraction
    {
        Player,
        Monster
    }
}
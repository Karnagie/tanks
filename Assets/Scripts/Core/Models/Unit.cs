using System;
using Core.Models.Systems;
using UniRx;
using UnityEngine;
using Observable = Infrastructure.Helpers.Observable;

namespace Core.Models
{
    public class Unit : ISingleSystem
    {
        public IObservable<string> Name { get; }
        public Transform Transform { get; }
        public Transform WeaponPoint { get; }
        public Observable Killed { get; } = new();
        public Fraction Fraction { get; }
        public ReactiveProperty<float> Health { get; }
        public ReactiveProperty<float> Armor { get; }
        public ReactiveProperty<float> Speed { get; }
        public Collider2D Collider { get; }


        public Unit(
            string name, 
            Transform transform,
            Fraction fraction,
            float health,
            float armor,
            float speed, 
            Transform weaponPoint, 
            Collider2D collider)
        {
            Name = new ReactiveProperty<string>(name);
            Transform = transform;
            Fraction = fraction;
            WeaponPoint = weaponPoint;
            Collider = collider;
            Health = new ReactiveProperty<float>(health);
            Armor = new ReactiveProperty<float>(armor);
            Speed = new ReactiveProperty<float>(speed);
        }

        public void Damage(int damage)
        {
            Health.Value -= (damage * Armor.Value);
            if(Health.Value <= 0)
                Killed.Invoke();
        }
    }

    public enum Fraction
    {
        Player,
        Monster
    }
}
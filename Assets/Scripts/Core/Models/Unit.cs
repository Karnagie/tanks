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
        public IObservable<int> Health { get; }
        public IObservable<int> Armor { get; }
        public IObservable<float> Speed { get; }


        public Unit(
            string name, 
            Transform transform,
            Fraction fraction,
            int health,
            int armor,
            float speed, 
            Transform weaponPoint)
        {
            Name = new ReactiveProperty<string>(name);
            Transform = transform;
            Fraction = fraction;
            WeaponPoint = weaponPoint;
            Health = new ReactiveProperty<int>(health);
            Armor = new ReactiveProperty<int>(armor);
            Speed = new ReactiveProperty<float>(speed);
        }
    }

    public enum Fraction
    {
        Player,
        Monster
    }
}
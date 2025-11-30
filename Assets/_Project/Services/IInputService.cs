using System;
using UnityEngine;
using UniRx;

public interface IInputService
{
   IObservable<Vector2> MoveAxis { get; }

   IObservable<Unit> FireStream { get; }
}

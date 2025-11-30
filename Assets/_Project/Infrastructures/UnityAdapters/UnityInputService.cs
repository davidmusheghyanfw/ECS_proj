using System;
using UniRx;
using UnityEngine;
using Zenject;

public class UnityInputService : IInputService, IInitializable, ITickable, IDisposable
{
    private readonly Subject<Vector2> _moveAxisSubject = new Subject<Vector2>();
    private readonly Subject<Unit> _fireStreamSubject = new Subject<Unit>();
    
    private CompositeDisposable _disposables = new CompositeDisposable();
    private Vector2 _lastMoveAxis = Vector2.zero;

    public IObservable<Vector2> MoveAxis => _moveAxisSubject.AsObservable();
    public IObservable<Unit> FireStream => _fireStreamSubject.AsObservable();

    public void Initialize()
    {
        Debug.Log("UnityInputService Initialized");
    }

    public void Tick()
    {
        // Read input every frame
        var moveAxis = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        // Only emit if input changed
        if (moveAxis != _lastMoveAxis)
        {
            _lastMoveAxis = moveAxis;
            _moveAxisSubject.OnNext(moveAxis);
        }

        // Check fire button
        if (Input.GetButtonDown("Fire1"))
        {
            _fireStreamSubject.OnNext(Unit.Default);
        }
    }

    public void Dispose()
    {
        _disposables?.Dispose();
        _moveAxisSubject?.OnCompleted();
        _moveAxisSubject?.Dispose();
        _fireStreamSubject?.OnCompleted();
        _fireStreamSubject?.Dispose();
    }
}

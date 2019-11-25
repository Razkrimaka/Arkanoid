using System;

public interface IInputController : IReleasable
{
    event EventHandler<float> MoveLeft;
    event EventHandler<float> MoveRight;
}

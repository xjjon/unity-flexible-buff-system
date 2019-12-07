
using Components;
using ScriptableObjects;
using UnityEngine;

public class TimedSpeedBuff : TimedBuff
{
    private readonly ScriptableSpeedBuff _speedBuff;

    private readonly MovementComponent _movementComponent;

    public TimedSpeedBuff(float duration, ScriptableBuff buff, GameObject obj) : base(duration, buff, obj)
    {
        //Getting MovementComponent, replace with your own implementation
        _movementComponent = obj.GetComponent<MovementComponent>();
        _speedBuff = (ScriptableSpeedBuff)buff;
    }

    protected override void ApplyEffect()
    {
        //Add speed increase to MovementComponent
        ScriptableSpeedBuff speedBuff = (ScriptableSpeedBuff) Buff;
        _movementComponent.MovementSpeed += speedBuff.SpeedIncrease;
    }

    public override void End()
    {
        //Revert speed increase
        _movementComponent.MovementSpeed -= _speedBuff.SpeedIncrease;
    }
}

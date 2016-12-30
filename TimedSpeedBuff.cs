public class TimedSpeedBuff : TimedBuff
{
    private ScriptableSpeedBuff speedBuff;

    private MovementComponent movementComponent;

    public TimedSpeedBuff(float duration, ScriptableBuff buff, GameObject obj) : base(duration, buff, obj)
    {
        //Getting MovementComponent, replace with your own implementation
        movementComponent = obj.GetComponent<MovementComponent>();
        speedBuff = (ScriptableSpeedBuff)buff;
    }

    public override void Activate()
    {
        //Add speed increase to MovementComponent
        ScriptableSpeedBuff speedBuff = (SpeedBuff) buff;
        movementComponent.moveSpeed += speedBuff.SpeedIncrease;
    }

    public override void End()
    {
        //Revert speed increase
        movementComponent.moveSpeed -= speedBuff.SpeedIncrease;
    }
}

[CreateAssetMenu(menuName = "Buffs/SpeedBuff")]
public class SpeedBuff: ScriptableBuff
{
    public float SpeedIncrease;

    public override TimedBuff InitializeBuff(GameObject obj)
    {
       return new TimedSpeedBuff(Duration, this, obj);
    }
}

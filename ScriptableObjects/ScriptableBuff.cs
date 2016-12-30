public abstract class ScriptableBuff : ScriptableObject
{

    //Duration of the buff
    public float Duration;

    public abstract TimedBuff InitializeBuff(GameObject obj);

}

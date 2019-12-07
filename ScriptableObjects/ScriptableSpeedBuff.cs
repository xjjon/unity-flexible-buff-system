using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Buffs/SpeedBuff")]
    public class ScriptableSpeedBuff : ScriptableBuff
    {
        public float SpeedIncrease;

        public override TimedBuff InitializeBuff(GameObject obj)
        {
            return new TimedSpeedBuff(this, obj);
        }
    }
}

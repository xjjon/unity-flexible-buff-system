using UnityEngine;

public abstract class TimedBuff
{

    protected float Duration;
    protected readonly ScriptableBuff Buff;
    protected readonly GameObject Obj;
    public bool IsFinished => Duration <= 0;

    public TimedBuff(float duration, ScriptableBuff buff, GameObject obj)
    {
        Duration = duration;
        Buff = buff;
        Obj = obj;
    }

    public void Tick(float delta)
    {
        Duration -= delta;
        if (Duration <= 0)
        {
            End();
        }
    }

    /**
     * Activates buff or extends duration if ScriptableBuff has IsDurationStacked or IsEffectStacked set to true.
     */
    public void Activate()
    {
        if (Buff.IsDurationStacked)
        {
            Duration += Buff.Duration;
        }

        if (Buff.IsEffectStacked || Duration <= 0)
        {
            ApplyEffect();
        }
    }
    protected abstract void ApplyEffect();
    public abstract void End();
}

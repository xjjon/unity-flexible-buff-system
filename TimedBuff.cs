using UnityEngine;

public abstract class TimedBuff
{
    // How often ApplyTick() is called (in seconds
    protected float TickRate = 1;
    // Total duration of buff
    protected float Duration;
    protected int EffectStacks;
    public ScriptableBuff Buff { get; }
    protected readonly GameObject Obj;
    public bool IsFinished;

    private float _timeSinceLastTick;

    public TimedBuff(ScriptableBuff buff, GameObject obj)
    {
        Buff = buff;
        Obj = obj;
    }

    public void Tick(float delta)
    {
        Duration -= delta;
        _timeSinceLastTick += delta;
        if (_timeSinceLastTick >= TickRate)
        {
            ApplyTick();
            _timeSinceLastTick = 0;
        }

        if (Duration <= 0)
        {
            End();
            IsFinished = true;
        }
    }

    /**
     * Activates buff or extends duration if ScriptableBuff has IsDurationStacked or IsEffectStacked set to true.
     */
    public void Activate()
    {
        if (Buff.IsEffectStacked || Duration <= 0)
        {
            ApplyEffect();
            EffectStacks++;
        }
        
        if (Buff.IsDurationStacked || Duration <= 0)
        {
            Duration += Buff.Duration;
        }
    }
    protected abstract void ApplyEffect();

    // Called every TickRate seconds. Can be used for things such as damage over time or healing over time.
    protected abstract void ApplyTick();
    public abstract void End();
}

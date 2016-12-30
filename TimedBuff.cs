public abstract class TimedBuff
{

    protected float duration;
    protected ScriptableBuff buff;
    protected GameObject obj;
    public Boolean IsFinished
    {
        get { return duration <= 0? true: false; }
    }

    public TimedBuff(float duration, ScriptableBuff buff, GameObject obj)
    {
        this.duration = duration;
        this.buff = buff;
        this.obj = obj;
    }

    public void Tick(float delta)
    {
        duration -= delta;
        if(duration <= 0)
            End();
    }

    public abstract void Activate();
    public abstract void End();
}

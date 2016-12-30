public class BuffableEntity: MonoBehaviour
{

    //List of all current buffs
    public List<TimedBuff> CurrentBuffs = new List<TimedBuff>();

    void Update()
    {
        //OPTIONAL, return before updating each buff if game is paused
        //if (Game.isPaused)
        //    return;

        foreach(TimedBuff buff in CurrentBuffs.ToArray())
        {
            buff.Tick(Time.deltaTime);
            if (buff.IsFinished)
            {
                CurrentBuffs.Remove(buff);
            }
        }
    }

    public void AddBuff(TimedBuff buff)
    {
        CurrentBuffs.Add(buff);
        buff.Activate();
    }
}

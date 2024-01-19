using System.Collections;
using System.Collections.Generic;
using UnityEngine;



class TimerNode
{
    public Timer.TimerHandler callback;
    public float duration;
    public float delay;//隔多少时间触发一次
    public int times;//触发的次数
    public float passedTime;//Timer过去了多少
    public object param;//需要什么类型的玩意
    public int timerId;
    public bool isRemoved = false;
}
public class Timer : MonoBehaviour
{
    public static Timer Instance = null;
    public delegate void TimerHandler(object param);
    private Dictionary<int, TimerNode> timers = null;
    private int autoId = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {//保证单例
            GameObject.Destroy(this);
            return;
        }
        this.Init();//初始化
    }
    private void Update()
    {

        float dt = Time.deltaTime;
        foreach (TimerNode timer in this.timers.Values)
        {
            if (timer.isRemoved)
            {
                continue;
            }
            timer.passedTime += dt;
            if (timer.passedTime >= (timer.delay + timer.duration))
            {
                timer.callback(timer.param); ;
                timer.times--;
                timer.passedTime -= (timer.delay + timer.duration);
                timer.delay = 0;
            }
            if (timer.times == 0)
            {
                timer.isRemoved = true;
                //删除
            }
        }
    }
    private void Init()
    {
        this.timers = new Dictionary<int, TimerNode>();
    }
    //启动timer
    public int ScheduleOnce(TimerHandler func, float delay)
    {
        return Schedule(func, 1, 0, delay);
    }
    public int ScheduleOnce(TimerHandler func, object param, float delay)
    {

        return Schedule(func, param, 1, 0, delay);
    }
    public int Schedule(TimerHandler fuc, int times, float delay, float duration)
    {
        return Schedule(fuc, null, times, delay, duration);
    }
    public int Schedule(TimerHandler func, object param, int times, float delay, float duration)
    {
        TimerNode timer = new TimerNode();
        timer.callback = func;
        timer.duration = duration;
        timer.param = param;
        timer.times = times;
        timer.delay = delay;
        timer.passedTime = duration;
        timer.timerId = this.autoId;
        timer.isRemoved = false;
        autoId++;
        this.timers.Add(timer.timerId, timer);
        return timer.timerId;
    }



}



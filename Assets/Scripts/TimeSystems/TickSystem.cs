using System.Collections;
using RoofGardenGame;
using RoofGardenGame.Models.Events;
using UnityEngine;

public class TickSystem : MonoBehaviour
{
    [SerializeField]
    [Min(0.01f)]
    private float tickInterval = 1f; // tick interval in seconds

    private Coroutine tickCoroutine;
    private uint tickPauseLevel = 0; // number of active pauses "blocks" of the tick system. So that one event cannot resume a pause still active by another event.

    private void Awake()
    {
        if (tickInterval <= 0)
        {
            tickInterval = 1f; // 1 second default in case of invalid value from the editor
        }
    }

    private void Start()
    {
        tickCoroutine = StartCoroutine(TickEnumerator());
    }

    private void OnEnable()
    {
        EventBus.OnDayEnd += PauseTicks;
        EventBus.OnDayStart += ResumeTicks;
    }

    private void OnDisable()
    {
        EventBus.OnDayEnd -= PauseTicks;
        EventBus.OnDayStart -= ResumeTicks;
    }

    private void PauseTicks(DayEvent dayEvent)
    {
        tickPauseLevel++;
    }

    private void ResumeTicks(DayEvent dayEvent)
    {
        // check to prevent subtracting under 0 as tickPauseLevel is uint
        if (tickPauseLevel > 0)
        {
            tickPauseLevel--;
        }
    }

    private IEnumerator TickEnumerator()
    {
        float elapsedTime = 0f;

        while (true)
        {
            if (tickPauseLevel == 0)
            {
                elapsedTime += Time.deltaTime;

                while (elapsedTime >= tickInterval)
                {
                    elapsedTime -= tickInterval;
                    Tick(tickInterval);
                }
            }

            yield return null;
        }
    }

    public void skipTicks(int Amount = 20)
    {
        Tick(Amount);
    }


    private void Tick(float deltaTime)
    {
        TickEvent tickEvent = new TickEvent(deltaTime);

        EventBus.RaiseTick(tickEvent);
    }
}

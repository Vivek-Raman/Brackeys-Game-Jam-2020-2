using System.Collections.Generic;
using UnityEngine;

struct TrackableOverTime
{
    public Vector3 position;
    public Quaternion rotation;

    public TrackableOverTime(Vector3 position, Quaternion rotation)
    {
        this.position = position;
        this.rotation = rotation;
    }
}

public class RewindTracker : MonoBehaviour
{
    public bool CanRewind => hasBufferPassed;

    [SerializeField] private float rewindBufferInSeconds = 3f;
    
    private Stack<TrackableOverTime> timeStack;
    private bool hasBufferPassed = false;
    private bool shouldTrack = true;

    private void Awake()
    {
        timeStack = new Stack<TrackableOverTime>();
        Invoke(nameof(BufferHasPassed), rewindBufferInSeconds);
    }

    private void LateUpdate()
    {
        if (!shouldTrack) return;
        if (hasBufferPassed)
        {
            timeStack.Pop();
        }
        timeStack.Push(
            new TrackableOverTime(
                this.transform.position,
                this.transform.rotation));
    }

    public void Rewind()
    {
        StopTracking();
        // SetStateToSuspended();
    }

    private void BufferHasPassed()
    {
        hasBufferPassed = true;
    }

    private void StopTracking()
    {
        shouldTrack = false;
    }
}

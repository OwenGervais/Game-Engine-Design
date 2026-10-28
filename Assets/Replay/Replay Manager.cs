using System.Collections.Generic;
using UnityEngine;

public class ReplayManager : MonoBehaviour
{
    public static ReplayManager instance;

    public enum State
    {
        Idle,
        Recording,
        Playback
    }

    public ReplayContainer replayContainer;

    public List<IReplayObject> replayObjects;

    public State currentState;

    public float SnapshotInterval = 0.01666666666f;

    private void Awake()
    {
        instance = this;
    }

    public void StartRecording()
    {
        currentState = State.Recording;
    }

    public void StartPlayback()
    {
        currentState = State.Playback;
    }

    public void Stop()
    {
        currentState = State.Idle;
    }

    public void Register(IReplayObject replayObject)
    {
        if (replayObjects == null)
        {
            replayObjects = new List<IReplayObject>();
        }

        replayObjects.Add(replayObject);
    }

    private void FixedUpdate()
    {
        if (currentState == State.Recording)
        {
            m_snapshotDeltaTotal += Time.fixedDeltaTime;
            if (m_snapshotDeltaTotal >= snapshotDelta)
            {
                TakeSnapshot();

                m_snapshotDeltaTotal -= snapshotDelta;
            }
        }
    }

    private int SnapshotIndex = 0;

    private void TakeSnapshot()
    {
        m_time += Time.fixedDeltaTime;

        SnapshotData snapshoData = new SnapshotData(m_time);

        foreach(IReplayObject replayObject in replayObjects)
        {
            replayObject.AddObjectSnapshot(((UnityEngine.Object)replayObject).name, replayObject.SaveSnapshot());
        }

        replayContainer.AddSnapshot(snapshoData);

        SnapshotIndex++;
    }
}

public interface IReplayObject
{
    SnapshotInfo SaveSnapshot();

    void LoadSnapshot();
}

public struct SnapshotData
{
    public float frameTime;
    public Dictionary<string, object> snapshots;

    public SnapshotData(float time)
    {
        frameTime = time;
        snapshots = new Dictionary<string, object>();
    }

    public void AddObjectSnapshot(string ID, object data)
    {
        snapshots.Add(ID, data);
    }
}

[System.Serializable]
public class SnapshotInfo
{
    public string ID;
}

[System.Serializable]
public class PlayerSnapshotInfo : SnapshotInfo
{
    public string ID;
}
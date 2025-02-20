using UnityEngine;

public interface Game
{
    public abstract void OnAwake();
    public abstract void OnStart();
    public abstract void OnPause();
    public abstract void OnRunning();
    public abstract void OnExit();
}

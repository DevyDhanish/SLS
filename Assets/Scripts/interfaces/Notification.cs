using UnityEngine;

public interface Notification
{
    // protected virtual void Callback(){
    //     close();
    // }

    public abstract void display(string msg);
    public abstract void conceal();
    public abstract NotificationTypes.N_Types getType();

    // protected virtual void close()
    // {
    //     conceal();
    // }
}

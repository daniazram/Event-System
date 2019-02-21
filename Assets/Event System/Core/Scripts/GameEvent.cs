using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class GameEvent : ScriptableObject 
{
    private EventCallback response;

    public EventCallback Response
    {
        set{ response = value;}
    }

    public void Invoke()
    {
        response.Invoke(new object[] { });
    }

    public void Invoke(object[] data)
    {
        response.Invoke(data);
    }
}

[System.Serializable]
public class EventCallback : UnityEvent<object[]>
{ }

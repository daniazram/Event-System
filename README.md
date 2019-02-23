# Event System with Scriptable Objects

#### NOTE: This project is built with Unity 2018.3.4, if you face any problem try upgrading to Unity 2018.3 or above. This is the first iteration of the project I will add more features and enhance it.

## About
This event system is inspired from the [Unite 2017 talk about scriptable objects](https://www.youtube.com/watch?v=raQ3iHhE_Kk), aim is to provide simple and easy to use event system. If you are like me and don't like doing: `SomeClass.SomeEvent += SomeOtherClassFunction();` then you might find this event system useful.

Code example above works perfectly fine, what I don't like about this is that:

* `SomeOtherClass.cs` has to know about `SomeClass.cs` 
* `SomeOtherClass.cs` has to make sure that it remove its `SomeOtherClassFunction()` from the `SomeEvent`'s invokation list.

With this event system not only you can get rid of this extra code plus both classes can live without even knowing each other which increases the reusability.

## How To Use
Before I give an example to explain the usage I would like to explain the workflow first. Event System has only two scripts `GameEvent.cs` and `GameEventTrigger.cs`. 

Every event is a **GameEvent** and to invoke the event you need to have a reference to that event e.g. `ShootEvent.Invoke(object []);`, to add listeners to the event's invocation list you have **GameEventTrigger** which, ideally, resides on an empty gamobject in the hierarchy and acts as a manager. 

**GameEventTrigger** shows you the list of every **GameEvent** you have created and you can choose any event you want to add listeners to. This is all you need to know before we get to the example.

Lets say we want to shoot bullets, whenever user presses left mouse button we want to play the shooting animation, spawn particle effect, and spawn bullet. A typical setup with this event system will look like following:

1. Create a new event by right clicking in the assets folder and selecting **Game Event** from the create menu, name it **Shoot**. ![example-create](https://user-images.githubusercontent.com/12896256/53290872-3c895500-37cc-11e9-95f6-a15636027566.png)
2. If haven't already, create an emtpy GameObject, name it something like **Game Event Manager**, and add the script   **GameEventTrigger.cs** to it.
3. Select the **Game Event Manager**, from the inspector click on the **Add New Event** button and select the **Shoot** event. ![example-add-01](https://user-images.githubusercontent.com/12896256/53290884-6f334d80-37cc-11e9-877f-02053e73008f.png)
4. You will see the default Unity Event interface, you can remove the event by clicking the little **minus sign** on the top right or you can add/remove listeners to/from the event by pressing the **+/-** on the bottom right of that event.
5. Press the **+** button and add as many new listeners as you want e.g. add the `WeaponController.OnShoot()`, `AnimationController.PlayShootAnimation()`, and `EffectsController.StartMuzzleFlashEffect()`. ![example-add-02](https://user-images.githubusercontent.com/12896256/53290888-7fe3c380-37cc-11e9-930d-bc94bb05e328.png)
6. Now in the class where you have the reference of **Shoot** event, whenever user presses LMB you can say `Shoot.Invoke()` and all the listeners will get notified. ![example-invoke](https://user-images.githubusercontent.com/12896256/53290894-90943980-37cc-11e9-8ae2-2a59d3252bb3.PNG)

This is the simplest use case of this system, you can send data of any type through these events and unlike the UnityEvent the **GameEvent** supports more than 4 arguments. Argument can only be `object[]` which you can cast to appropriate data type when recieved.
##### For Example
```
int Score
{ 
    set { score = value; ScoreUpdateEvent.Invoke(object[] {value}); } 
}
```
Then somewhere else.
```
public void OnScoreUpdate(object[] data)
{ int score = (int)data[0]; }
```
###### Make sure you have added the listener as dynamic, a section on the top showing the functions that matches the argument list of the event, when selecting the function to add as a listener.
![example-dynamic](https://user-images.githubusercontent.com/12896256/53271990-dc35dd00-3711-11e9-8f96-bddd461aba35.png)

## Project Hierarchy
Project has one root folder named as **Event System** and two subfolders **Core**(the actual system, which is only two scripts), **Demo** a tiny demo to see the system in work.
You can uncheck or delete(if you have already imported) the demo and can only have the core folder, but I will recommend to check the demo as it will really help you understand the system.


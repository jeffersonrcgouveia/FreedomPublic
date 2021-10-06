# Freedom
It is a Top-Down game with simple mechanics just to serve as a portfolio project. After the player selects a character, waves of enemies start spawning until the player cannot survive anymore. 

After you get defeated, if you make a record of waves passed or enemies killed, a Record screen will be shown, if you don't make a record, a Game Over screen will be shown.

> :warning: **Paid Assets**: The paid assets like character animations, environment textures and the Barbarian axe were removed from this repository. The materials with paid textures were replaced by simple materials.

## Gameplay Video
https://www.youtube.com/watch?v=0zind_KFq2c

## Online Playable Version
https://simmer.io/@jgouveia/freedom

### Controls
- **Movement:**             WASD
- **Sprint:**               Shift (Hold)
- **Walk/Run:**             Shift (Press)
- **Roll:**                 Space
- **Attack:**               Left Mouse Button
- **Block (Knight):**       Right Button

## Project Architecture
### Databases (Scriptable Object)
The scenes data are saved on Scriptable Object databases.

![image](https://user-images.githubusercontent.com/65473098/135723554-def162d9-89c9-4670-8316-3c8b6365b693.png)
![image](https://user-images.githubusercontent.com/65473098/135770808-9970df8b-6dad-4d06-9584-a843c2edb16c.png)

### Game States (Scriptable Object)
The states between scenes are saved on and loaded from Scriptable Objects, which makes each scene **testable** and **independent** from each other.

![image](https://user-images.githubusercontent.com/65473098/135723618-99715644-a8da-462c-8263-bae79a2aabab.png)
![image](https://user-images.githubusercontent.com/65473098/135770724-214831d1-b625-4332-86c9-4c94df87673e.png)

### Organized Prefabs Structure
The prefabs and their variants contain game objects inside to separate responsibilities.

![image](https://user-images.githubusercontent.com/65473098/135773198-4453c452-b9ab-426c-aabf-0af535e64f09.png)
![image](https://user-images.githubusercontent.com/65473098/135773229-a6936b09-9f55-477f-b485-e34326cb6594.png)

![Nhv115rHaT](https://user-images.githubusercontent.com/65473098/135773838-deddab5f-dba4-4e47-b814-dce3c31454a2.png)
![hb4fZff5Hj](https://user-images.githubusercontent.com/65473098/135773839-2f1384d3-b3a8-4b14-b460-2a249bba1a46.png)

### Organized Scene Structure
The game objects in the scene are organized by sections to make it easy to find the game objects.

![Unity_AEXjvhjOGP](https://user-images.githubusercontent.com/65473098/135773998-07c1bee5-567a-47a2-8fc6-5e82fc734039.png)

### Organized Animator
The Animator contains organized layers and sub-state machines to avoid spaghetti code.

![4rgGgQHPnp](https://user-images.githubusercontent.com/65473098/135775151-87c9cc6b-7ba3-48f5-b30a-c740885cc325.gif)

The Base Animator Controller contains the blocking animation that supposes to be just on the Knight's Animator Controller. In a real project, I'd put just the common animations on the Base Animator Controller and use a paid asset to reuse them on each character's Animator Controller.

### Shareable Projects (Git Submodules)
The projects that can be shared between other projects are imported as a git submodule and can be found in the folder **"Projects"**.

![VavN6PUyq4](https://user-images.githubusercontent.com/65473098/135778665-c1319681-a953-4d03-972d-c8d5cc69f863.png)
![image](https://user-images.githubusercontent.com/65473098/135830156-bba4b97d-ce2a-46e1-b9a9-f08675a6ce4f.png)

In the future, I'm planning to improve it making it installable via package and auto updatable.

## Code Architecture
### Assembly Definitions
The project uses assembly definitions to restrict internal modules accesses and improve the compile time.
![Ym0RALVGGI](https://user-images.githubusercontent.com/65473098/135871734-64643e62-d9ec-4684-bdc1-88405c80bc2e.png)

### Namespaces
The classes have namespaces.

### Encapsulation
All fields are private and properties just expose their setters if necessary.

```c#
public class CharacterHealth : MonoBehaviour
{
    ...
    [field: SerializeField] public int MaxHealth { get; set; }

    [field: SerializeField] public int Health { get; private set; }

    [SerializeField] bool invincible;

    public event Action<int> OnChange;

    public event Action<float> OnChangePercent;

    public event Action OnOver;

    const int MinHealth = 0;
    ...
}
```

### Classes With Few Lines
All classes have less than 100 lines.

### Single Responsibility Classes
Most classes contain a **single responsibility**, making them easier to read and maintain.

### No Circular Dependencies
The classes use events when they need to access the class that is referencing themselves instead of referencing each other directly.

## Code Examples

```c#
public class CharacterVelocity : MonoBehaviour
{
    [SerializeField] CharacterDirection characterDirection;
    [SerializeField] CharacterGait characterGait;

    public event Action<Vector3> OnCalculateVelocity;

    float _currentSpeed;

    void Awake()
    {
        characterDirection.OnFixedUpdateMovingDirection += CalculateVelocity;
        characterGait.OnCalculateGaitSpeed += SetCurrentSpeed;
    }

    public void CalculateVelocity(Vector3 direction)
    {
        Vector3 velocity = direction.normalized * (_currentSpeed * Time.deltaTime);
        OnCalculateVelocity?.Invoke(velocity);
    }

    public void SetCurrentSpeed(float currentSpeed) => _currentSpeed = currentSpeed;
}
```

```c#
[RequireComponent(typeof(CharacterVelocity))]
public class CharacterMovement : MonoBehaviour, IMovableCharacter
{
    Transform _rootTransform;

    CharacterVelocity _characterVelocity;

    void Awake()
    {
        _rootTransform = GetComponentInParent<CharacterRoot>().transform;
        _characterVelocity = GetComponent<CharacterVelocity>();
    }

    void OnEnable() => _characterVelocity.OnCalculateVelocity += Move;

    void OnDisable() => _characterVelocity.OnCalculateVelocity -= Move;

    public void Move(Vector3 velocity) => _rootTransform.position += velocity;
}
```

In the example above, the CharacterMovement class needs to know the current velocity to position the character, so it just adds a delegate to the OnCalculateVelocity event to move the character after the velocity has been calculated. In that way, both classes have a single responsibility and no circular dependencies.

### What I've Learned With This Project

In the example above, the CharacterMovement class has the responsibility of delegating its method on the CharacterVelocity's event. This creates a dependency between the event caller and receiver, resulting in a more coupled code. In a new project I'd delegate this responsibility to another class, making it possible to remove all their dependencies, like the following example:

```c#
public class CharacterVelocity : MonoBehaviour
{
    public event Action<Vector3> OnCalculateVelocity;

    float _currentSpeed;

    public void CalculateVelocity(Vector3 direction)
    {
        Vector3 velocity = direction.normalized * (_currentSpeed * Time.deltaTime);
        OnCalculateVelocity?.Invoke(velocity);
    }

    public void SetCurrentSpeed(float currentSpeed) => _currentSpeed = currentSpeed;
}
```

```c#
public class CharacterMovement : MonoBehaviour, IMovableCharacter
{
    Transform _rootTransform;

    void Awake() => _rootTransform = GetComponentInParent<CharacterRoot>().transform;

    public void Move(Vector3 velocity) => _rootTransform.position += velocity;
}
```

```c#
[RequireComponent(typeof(CharacterDirection))]
[RequireComponent(typeof(CharacterGait))]
[RequireComponent(typeof(CharacterVelocity))]
[RequireComponent(typeof(CharacterMovement))]
public class LocomotionEventsController : MonoBehaviour
{
    CharacterDirection _characterDirection;
    CharacterGait _characterGait;
    CharacterVelocity _characterVelocity;
    CharacterMovement _characterMovement;

    void Awake()
    {
        _characterDirection = GetComponent<CharacterDirection>();
        _characterGait = GetComponent<CharacterGait>();
        _characterVelocity = GetComponent<CharacterVelocity>();
        _characterMovement = GetComponent<CharacterMovement>();
    }

    void OnEnable()
    {
        _characterDirection.OnFixedUpdateMovingDirection += _characterVelocity.CalculateVelocity;
        _characterGait.OnCalculateGaitSpeed += _characterVelocity.SetCurrentSpeed;
        _characterVelocity.OnCalculateVelocity += _characterMovement.Move;
    }

    void OnDisable()
    {
        _characterDirection.OnFixedUpdateMovingDirection -= _characterVelocity.CalculateVelocity;
        _characterGait.OnCalculateGaitSpeed -= _characterVelocity.SetCurrentSpeed;
        _characterVelocity.OnCalculateVelocity -= _characterMovement.Move;
    }
}
```

This approach removes most dependencies from classes.

Another approach would be using UnityEvents instead of Actions and completely remove the necessity of the LocomotionEventsController class.

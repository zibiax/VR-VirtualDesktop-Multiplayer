public enum FingerType
{
    None,
    Thumb,
    Index,
    Middle,
    Ring,
    Pinky
}
// Script to differentiate between the different fingers

public class Finger
{
    public FingerType type = FingerType.None;
    public float current = 0.0f;
    public float target = 0.0f;

    public Finger(FingerType type)
    {
        this.type = type;
    }
    // Script to hold the value it is at the time and what it will be. And smooth out the transition
}

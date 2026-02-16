using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public int _health = 100;
    [SerializeField] public int _speed;

    public int Health
    {
        get
        {
            return _health;
        }

        set
        {
            _health = value;
        }

    }

    public int Speed
    {
        get
        {
            return _speed;
        }

        set
        {
            _speed = value;
        }
    }
}

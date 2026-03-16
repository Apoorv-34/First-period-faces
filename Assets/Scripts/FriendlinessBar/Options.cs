using UnityEngine;

public class Options : MonoBehaviour
{
    private float damage = 2;
    public Friendliness Attack;
    public void CorrectOption()
    {
        Attack.GiveHealth(damage);
    }
    public void IncorrectOption()
    {
        Attack.TakeDamage(damage);
    }
}

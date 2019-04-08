using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Transform Respawnpoint;
    public Slider HealthBar;
    public float Health = 100;
    public float damage = 25f;

    private float _currentHealth;

    void Start()
    {
        _currentHealth = Health;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        HealthBar.value = _currentHealth;
    }
    private void LateUpdate()
    {
        if (_currentHealth <= 0)
        {
            transform.position = Respawnpoint.position;
            _currentHealth = 100;
            HealthBar.value = _currentHealth;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == ("HarmFull"))
        {
            print(_currentHealth);
            TakeDamage(damage);
        }
    }
}
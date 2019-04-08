using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugHealth : MonoBehaviour
{
    public Transform Respawnpoint;
    public Slider HealthBar;
    public float Health = 100;
    public float damage = 25f;
    private float _currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = Health;
        HealthBar.transform.localScale = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        Mount Mounted = GetComponent<Mount>();
        if (Mounted.SmallBugMounted)
        {
            HealthBar.transform.localScale = new Vector3(1, 1, 1);
        }

    }
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        HealthBar.value = _currentHealth;
    }
    private void LateUpdate()
    {
        Mount Mounted = GetComponent<Mount>();
        if (Input.GetKey("e"))
        {
            HealthBar.transform.localScale = new Vector3(0, 0, 0);
        }
        if (_currentHealth <= 0)
        {
           // transform.position = Respawnpoint.position;
            _currentHealth = 100;
            HealthBar.value = _currentHealth;
            HealthBar.transform.localScale = new Vector3(0, 0, 0);
            if (transform.parent != null)
            {
                transform.parent = null;
                Mounted.SmallBugMounted = false;
                Mounted.player.transform.localScale = new Vector3(Mounted.Grow, Mounted.Grow, Mounted.Grow);
                Mounted.player.transform.position = Mounted.SmallBug.transform.position;
            }
            Mounted.SmallBug.transform.position = Respawnpoint.transform.position;
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

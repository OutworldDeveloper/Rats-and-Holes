using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    public delegate void PlayerShooted(RaycastHit2D hit);
    public delegate void HealthChanged(int health);
    public delegate void DeadeyeStarted(bool started);
    public delegate void DeadeyeChanged(float deadeye);

    public event HealthChanged OnHealthChanged;
    public event PlayerShooted OnPlayerShooted;
    public event DeadeyeStarted OnDeadeyeStart;
    public event DeadeyeChanged OnDeadeyeChanged;

    public bool godmode = false;

    public BoolParameter isCheats;
    public float deadeye { get; private set; } = 0;
    public float deadeyeTreashold { get; private set; } = 20;
    public int health { get; private set; } = 3;
    public int maxHealth { get; private set; } = 3;
    public int ratsKilled { get; private set; } = 0;
    public bool isDeadeye { get; private set; } = false;

    [SerializeField]
    private float shootCooldown = 0.1f;

    [SerializeField]
    private DamageType damageType;

    [SerializeField]
    private Bucket bucketPrefab;

    private float nextShootTime;

    public UnityEvent OnDeadeyeFailedToStart;

    private Bucket currentBucket;

    public void SetDamage(int damage)
    {
        if (health - damage > 0)
        {
            health -= damage;
        }
        else
        {
            if (!godmode)
            {
                health = 0;
            }
        }
        if (OnHealthChanged != null) OnHealthChanged(health);
    }

    public void Heal(int heal)
    {
        if (health + heal <= maxHealth)
        {
            health += heal;
        }
        else
        {
            health = maxHealth;
        }
        if (OnHealthChanged != null) OnHealthChanged(health);
    }

    public void AddHealth(int health)
    {
        maxHealth += health;
        Heal(health);
    }

    public void AddDeadeye(float amount)
    {
        if(deadeye + amount > 100)
        {
            deadeye = 100;
        }
        else
        {
            deadeye += amount;
        }
        if (OnDeadeyeChanged != null) OnDeadeyeChanged(deadeye);
    }
    public void EnableDeadeye(bool b)
    {    
        if (b)
        {
            if (deadeye >= deadeyeTreashold)
            {
                shootCooldown = 0.02f;
                Time.timeScale = 0.2f;
                isDeadeye = true;
                if (OnDeadeyeStart != null) OnDeadeyeStart(b);
            }
            else
            {
                OnDeadeyeFailedToStart.Invoke();
            }
        }
        else
        {
            shootCooldown = 0.1f;
            Time.timeScale = 1f;
            isDeadeye = false;
            if (OnDeadeyeStart != null) OnDeadeyeStart(b);
        }
    }

    public void Shoot()
    {
        if (Time.time >= nextShootTime)
        {
            nextShootTime = Time.time + shootCooldown;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.transform.GetComponent<Drop>())
                {
                    hit.transform.GetComponent<Drop>().Take(this);
                }
                if (hit.transform.GetComponent<IDamageable>() != null)
                {
                    hit.transform.GetComponent<IDamageable>().ApplyDamage(1, damageType);
                }
            }
            if (OnPlayerShooted != null) OnPlayerShooted(hit);
        }
    }

    public void CatchRat()
    {
        Rat[] rats = FindObjectsOfType<Rat>();
        if(rats.Length > 0)
        {
            List<Rat> targets = new List<Rat>();
            foreach (var item in rats)
            {
                if(!item.IsDead() && !item.IsStunned())
                {
                    targets.Add(item);
                }
            }
            if(targets.Count > 0)
            {
                if (currentBucket != null) currentBucket.ApplyDamage(1, damageType);
                Rat targetRat = targets[UnityEngine.Random.Range(0, targets.Count)];
                currentBucket = Instantiate(bucketPrefab, Vector3.zero, Quaternion.identity);
                currentBucket.CatchRat(targetRat);
            }
        }
    }

    private void Update()
    {
        if(isDeadeye)
        {
            if(deadeye > 0)
            {
                deadeye -= Time.deltaTime * 100;
            }
            else
            {
                deadeye = 0;
                EnableDeadeye(false);
            }
            if (OnDeadeyeChanged != null) OnDeadeyeChanged(deadeye);
        }
        //Это должно быть в отдельном классе. Потом!
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            MobileInput();
        }
        else
        {
            DefaultInput();
        }    
    }

    private void DefaultInput()
    {
        //Deadeye
        if (Input.GetMouseButtonDown(1))
        {
            EnableDeadeye(true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            EnableDeadeye(false);
        }

        //Shoot
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }

        //Test
        if(Input.GetKeyDown(KeyCode.R))
        {
            CatchRat();
        }

        //Cheats
        if (isCheats.GetValue())
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                godmode = !godmode;
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                if (Time.timeScale < 16f)
                {
                    Time.timeScale = Time.timeScale + 4f;
                }
                else
                {
                    Time.timeScale = 1f;
                }
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                AddDeadeye(100);
            }
        }
    }

    private void MobileInput()
    {
        //Shoot
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }
}
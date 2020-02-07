using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int hp = 100;
    public int maxHP = 100;

    public float timeElapsedSinceLastDamage = 0;
    public float regenTimeThreshold = 3f;

    public int hpRegenAmount = 2;
    public int bufferMultiplier = 2;

    public bool willApplyHP = false;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsedSinceLastDamage += Time.deltaTime;
        if(hp < maxHP)
        { 
            if(willApplyHP)
            { 
                if(timeElapsedSinceLastDamage < regenTimeThreshold)
                {

                    bufferMultiplier = bufferMultiplier * 2;
                    hp += hpRegenAmount * bufferMultiplier;
                    willApplyHP = false;
                    timeElapsedSinceLastDamage = 0;
                }
            }
            else { 
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    takeDamage();
                }
            }
        }
    }

    void takeDamage()
    {
        willApplyHP = true;
        Debug.Log("Took damage.");

    }
}

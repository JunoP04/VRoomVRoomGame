using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnColid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 5f);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].GetComponent<ParticleSystem>() != null)
            {
                ParticleSystem ps = hitColliders[i].GetComponent<ParticleSystem>();
                var emission = ps.emission;
                emission.enabled = true;
                //Debug.Log(hitColliders[i].tag);
            }
            i++;
        }

    }
}

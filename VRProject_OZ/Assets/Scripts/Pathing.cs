using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine.AI;

public class Pathing : MonoBehaviour
{
    public Animator Anim;
    public NavMeshAgent agent;
    public List<Transform> waypoints;
    public Transform target;
    public int currentPoint = 0;
    int randomPoint;
    public bool targetLocked = false;
    public float distanceBetween = 2.5f;
    public int abandonTime;
    public float distanceCheck;
    public string enemyType;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        enemyType = "Player";
        Anim = GetComponent<Animator>();
        randomPoint = Random.Range(0, waypoints.Count);
        currentPoint = randomPoint;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[currentPoint].position);

    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag == "AllyZombie")
        {
            enemyType = "Zombie";
        }
        Anim.SetFloat("Speed", this.agent.speed);
        RaycastHit hit;
        distanceCheck = Vector3.Distance(transform.position, waypoints[currentPoint].position);
        if (distanceCheck < distanceBetween && targetLocked == false)
        {
            randomPoint = Random.Range(0, waypoints.Count);
            currentPoint = randomPoint;
           // Debug.Log(randomPoint);

            StartCoroutine(lookAroundRandomly());
        }
        
        //if you are within 10 meters of a zombie it will detect you
        if (Physics.SphereCast(this.gameObject.transform.position, 10f, transform.forward, out hit, 1) && hit.transform.gameObject.tag ==  enemyType){
            targetLocked = true;
            target = hit.transform;

        }

        if (Physics.SphereCast(this.gameObject.transform.position, 1f, transform.forward, out hit, 1) && hit.transform.gameObject.tag == enemyType)
        {
            Anim.SetBool("Attack", true);
            if (enemyType == "Player")
            {

                StartCoroutine(killPlayer());
            }
            else if(enemyType == "Zombie")
            {
                StartCoroutine(attack(hit.transform.gameObject));
            }
        }
        //if it has detected you it will chase you, every second it is chasing you it will increment a timer
        if (targetLocked == true)
        {
            abandonTime++;
            agent.SetDestination(target.position);
            return;
        }
        //it will always be raycasting forward, if this raycast hits you it will reset the chase timer, if it isn't already chasing you it will start
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity) && hit.transform.gameObject.tag ==enemyType)
        {
            abandonTime = 0; 
            targetLocked = true;
            target = hit.transform;
        }
        //if it can't see you for 4 seconds it gives up chasing
        if (abandonTime == 4)
        {
            targetLocked = false;
        }


    }

    IEnumerator attack(GameObject target)
    {
        yield return new WaitForSeconds(3);
        Destroy(target);
        Destroy(this.gameObject);
    }

    IEnumerator killPlayer()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
        Debug.Log("Player Died");
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == enemyType)
        {
            Debug.Log("hit");
        }
    }
    IEnumerator lookAroundRandomly()
    {
        
        int randomTime = Random.Range(0, 4);
        Debug.Log(randomTime);
        yield return new WaitForSeconds(randomTime);
        
        agent.SetDestination(waypoints[currentPoint].position);
    }
}

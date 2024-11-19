using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesTuple
{
    public GameObject gameObject;
    public int lifeValue;

    public EnemiesTuple(GameObject obj, int value)
    {
        gameObject = obj;
        lifeValue = value;
    }
}
public class GunFire : MonoBehaviour
{
    public GameObject gun; // gun must have line renderer component
    public GameObject target;
    public GameObject startPoint;
    public GameObject aCamera;
    LineRenderer line;
    AudioSource gunSound;
    public GameObject enemies;
    public GameObject musicL;
    AudioSource scream;
    AudioSource music;
    int health;
    int bossHealth;
    bool isWounded = false;
    bool isDead = false;
    static int enemiesCount = 7;
    public static bool bossDead = false;
    private EnemiesTuple[] enemiesArray = new EnemiesTuple[enemiesCount];
    int counterEnemies = 0;
    // Start is called before the first frame update
    void Start()
    {

        line = gun.GetComponent<LineRenderer>();
        gunSound = gun.GetComponent<AudioSource>();
        scream = enemies.GetComponent<AudioSource>();
        music = musicL.GetComponent<AudioSource>();
        health = 3;
        bossHealth=3;
        
        for (int i = 0; i < enemiesCount; i++)
        {
            GameObject enemy =enemies.transform.GetChild(i).gameObject;
            if (enemy.tag == "Enemy")
            {
                enemiesArray[i] = new EnemiesTuple(enemies.transform.GetChild(i).gameObject, health);
                enemiesCount++;
            }
                
        }
        Debug.Log("enemies :" + enemiesCount);

    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesCount == 0)
            music.Stop();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            music.Play();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (gun.gameObject.activeSelf)
            {
                RaycastHit hit;
                if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
                {
                    target.transform.position = hit.point;
                    StartCoroutine(Fire());

                    for (int i = 0; i < enemiesCount; i++)
                    {
                        if (hit.collider.gameObject == enemiesArray[i].gameObject)
                        {
                            Debug.Log("Hit GameObject tag: " + hit.collider.gameObject.tag);
                            if ( enemiesArray[i].gameObject.tag == "Boss")
                            {
                                Debug.Log("you are attacking the boss");
                                 enemiesArray[i].lifeValue --;
                                if (enemiesArray[i].lifeValue <= 0)
                                {
                                    
                                    // Boss is dead, kill all other enemies
                                    bossDead=true;
                                    KillAllEnemies();
                                }
                            }

                            else if (hit.collider.GetType() == typeof(BoxCollider))
                            {
                                Debug.Log("you should be dead");
                                scream.Play();
                                StartCoroutine(DyingEnemy(i)); // Pass the index
                                //enemiesArray[i].gameObject.SetActive(false);
                            }
                            else if (hit.collider.GetType() == typeof(CapsuleCollider))
                            {
                                Debug.Log("you are hit");
                                scream.Play();
                                enemiesArray[i].lifeValue--;
                                if ( enemiesArray[i].lifeValue == 0)
                                {
                                    Debug.Log("you are hit to death");
                                    StartCoroutine(DyingEnemy(i)); // Pass the index
                                }
                                else
                                {
                                     StartCoroutine(enemyWounded(i)); // Pass the index
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    void KillAllEnemies()
    {
        for (int i = 0; i < enemiesCount; i++)
        {
            if (enemiesArray[i].gameObject.activeSelf)
            {
                enemiesArray[i].gameObject.SetActive(false);
            }
        }
    }

    IEnumerator DyingEnemy(int i)
    {
        isDead = true;
        
        NavMeshAgent agent = enemiesArray[i].gameObject.GetComponent<NavMeshAgent>();
        agent.enabled = false;
        Animator a = enemiesArray[i].gameObject.GetComponent<Animator>();
        a.SetInteger("Status", 2);
        yield return new WaitForSeconds(0.01f);
        scream.Play();
        enemiesCount--;
        enemiesArray[i].gameObject.GetComponent<EnemyS>().SetDeadState(true);
        StartCoroutine(DelayDeath(i));
    }
    IEnumerator DelayDeath(int i)
    {
        yield return new WaitForSeconds(3f);
        enemiesArray[i].gameObject.SetActive(false);
    }

    IEnumerator enemyWounded(int i)
    {
        isWounded = true;

        NavMeshAgent agent = enemiesArray[i].gameObject.GetComponent<NavMeshAgent>();
        Animator a = enemiesArray[i].gameObject.GetComponent<Animator>();
        a.SetInteger("Status", 3);
        yield return new WaitForSeconds(0.01f);
        scream.Play();
        a.SetInteger("Status", 0);

        StartCoroutine(TimeWoundedEnemy(i));
    }
    IEnumerator TimeWoundedEnemy(int i)
    {
        enemiesArray[i].gameObject.GetComponent<EnemyS>().SetWoundedState(true);
        yield return new WaitForSeconds(3f);
        isWounded = false;
        enemiesArray[i].gameObject.GetComponent<EnemyS>().SetWoundedState(false);
    }
    IEnumerator Fire()
    {
        // before delay
        // draw fire line
        line.enabled = true;
        line.SetPosition(0, startPoint.transform.position);
        line.SetPosition(1, target.transform.position);
        gunSound.Play();
        yield return new WaitForSeconds(0.1f);

        // after delay
        line.enabled = false;
    }
}

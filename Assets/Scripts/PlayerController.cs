using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Pathfinding;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public bool isAttacking = false;
    public bool isDead = false;
    [HideInInspector] public bool slowed = false;
    public GameObject bloodEffectPrefab;
    public GameObject knightPrefab;
    public GameObject archerPrefab;
    public GameObject magePrefab;
    public float moveSpeed;
    public Rigidbody2D rb;
    
    [HideInInspector] public float idleTime;
    private HUDController hudController;
    private float timeToIdle = 1f;
    private Vector2 movement;
    private bool facingRight;
    private bool facingFront;
    private bool facingLeft;
    private bool facingBack;
    private bool isKnight;
    private bool isArcher;
    private bool isMage;
    
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hudController = FindObjectOfType<HUDController>();
        facingRight = true;

        if (transform.name == "Knight(Clone)")
        {
            isKnight = true;
        }
        else if (transform.name == "Archer(Clone)")
        {
            isArcher = true;
        }
        else if (transform.name == "Mage(Clone)")
        {
            isMage = true;
        }
    }
   
    public void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0 || movement.y != 0 || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("Move", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Move", false);
        }

        if (!isAttacking)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                facingBack = true;
                facingFront = false;
                facingLeft = false;
                facingRight = false;
            }
        
            if (Input.GetKeyDown(KeyCode.A))
            {
                facingLeft = true;
                facingBack = false;
                facingFront = false;
                facingRight = false;
            }
            
            if (Input.GetKeyDown(KeyCode.S))
            {
                facingFront = true;
                facingBack = false;
                facingLeft = false;
                facingRight = false;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                facingRight = true;
                facingBack = false;
                facingLeft = false;
                facingFront = false;
            }
        }

        SetPosition();

        if (!GetComponent<Animator>().GetBool("Move"))
        {
        idleTime += Time.deltaTime;

        if (idleTime >= timeToIdle)
        {
            GetComponent<Animator>().SetBool("Idle", true);
        }
        }
        else 
        {
            idleTime = 0;
            GetComponent<Animator>().SetBool("Idle", false);
        }

    }

    void SetPosition()
    {
        if (facingBack)
        {
            GetComponent<Animator>().SetFloat("LastVertical", 1f);
            GetComponent<Animator>().SetFloat("LastHorizontal", 0f);
        }
        else if (facingFront)
        {
            GetComponent<Animator>().SetFloat("LastVertical", -1f);
            GetComponent<Animator>().SetFloat("LastHorizontal", 0f);
        }
        else if (facingLeft)
        {
            GetComponent<Animator>().SetFloat("LastVertical", 0f);
            GetComponent<Animator>().SetFloat("LastHorizontal", -1f);
        }
        else if (facingRight)
        {
            GetComponent<Animator>().SetFloat("LastVertical", 0f);
            GetComponent<Animator>().SetFloat("LastHorizontal", 1f);
        }
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.CompareTag("Red Orb") && !isMage)
        {
            Destroy(collision.gameObject);
            TransformPlayer(magePrefab);
            ChangePortrait(magePrefab);
            SpawnController.SetLastCharacter(magePrefab);
            isMage = true;
        }
        else if (collision.gameObject.CompareTag("Green Orb") && !isArcher)
        {
            Destroy(collision.gameObject);
            TransformPlayer(archerPrefab);
            ChangePortrait(archerPrefab);
            SpawnController.SetLastCharacter(archerPrefab);
            isArcher = true;
        }
        else if (collision.gameObject.CompareTag("Blue Orb") && !isKnight)
        {
            Destroy(collision.gameObject);
            TransformPlayer(knightPrefab);
            ChangePortrait(knightPrefab);
            SpawnController.SetLastCharacter(knightPrefab);
            isKnight = true;
        }

        if (collision.gameObject.CompareTag("EnemyBodyCollider") && isAttacking)
        {
            EnemyController enemyController = collision.transform.parent.GetComponent<EnemyController>();
            if (collision.transform.parent.name != "Eye")
            {
                enemyController.Die();
            }
        }
    }

    public void Die()
    {
        GameObject bloodEffect = Instantiate(bloodEffectPrefab, transform.position, Quaternion.identity);
        Destroy(bloodEffect, 2f);
        GetComponent<Animator>().SetBool("Dead", true);
        transform.Find("BodyCollider").GetComponent<EdgeCollider2D>().enabled = false;
        CircleCollider2D[] colliders = transform.Find("MovementCollider").GetComponents<CircleCollider2D>();
        foreach (CircleCollider2D collider in colliders)
        {
            collider.enabled = false;
        }
        isDead = true;
        GameObject deathMenu = GameObject.Find("DeathMenu");
        SceneManager.LoadScene("DeathMenu");
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void TransformPlayer(GameObject newPlayerPrefab)
    {
        GameObject currentPlayer = GameObject.FindGameObjectWithTag("Player");

        Vector3 playerPosition = currentPlayer.transform.position;
        Quaternion playerRotation = currentPlayer.transform.rotation;

        Destroy(currentPlayer);

        GameObject newPlayer = Instantiate(newPlayerPrefab, playerPosition, playerRotation);

        GameObject mainCamera = GameObject.FindWithTag("MainCamera");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        mainCamera.GetComponent<CameraController>().target = newPlayer.transform;

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyController>().target = newPlayer.transform;
        }            
    }

    public void ChangePortrait(GameObject newPlayerPrefab)
    {
        GameObject newPortrait;
        if (newPlayerPrefab == magePrefab)
        {
            SpawnController.SetLastCharacterPortrait(hudController.magePortrait);
            newPortrait = hudController.magePortrait;
        }
        else if (newPlayerPrefab == archerPrefab)
        {
            SpawnController.SetLastCharacterPortrait(hudController.archerPortrait);
            newPortrait = hudController.archerPortrait;
        }
        else if (newPlayerPrefab == knightPrefab)
        {
            SpawnController.SetLastCharacterPortrait(hudController.knightPortrait);
            newPortrait = hudController.knightPortrait;
        }
        else
        {
            newPortrait = null;
        }

        if (newPortrait != null)
        {
            hudController.SetCharacterPortrait(newPortrait);
        }
    }
}

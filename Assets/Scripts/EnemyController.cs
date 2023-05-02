using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
    public AIDestinationSetter destinationSetter;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool isDead = false;
    public GameObject bloodEffectPrefab;
    public LayerMask obstacleLayer;
    public float detectionDistance;
    public float moveSpeed;
    public float deathDelay;

    private GameObject sprite;
    private Vector2 previousPosition;

    [SerializeField] private AudioSource damageSound;

    public void Start()
    {
        previousPosition = transform.position;

        target = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = transform.Find("Sprite").gameObject;
        sprite.GetComponent<Animator>().SetBool("Idle", true);
    }

    public void Update()
    {
        if (isDead) return;

        Vector2 currentPosition = transform.position;
        float horizontalMovement = Mathf.Abs(currentPosition.x - previousPosition.x);
        float verticalMovement = Mathf.Abs(currentPosition.y - previousPosition.y);

        if ((horizontalMovement > verticalMovement) && (currentPosition.x > previousPosition.x))
        {
            sprite.GetComponent<Animator>().SetBool("Move", true);
            sprite.GetComponent<Animator>().SetBool("FaceRight", true);
            sprite.GetComponent<Animator>().SetBool("FaceFront", false);
            sprite.GetComponent<Animator>().SetBool("FaceLeft", false);
            sprite.GetComponent<Animator>().SetBool("FaceBack", false);
        }
        else if ((horizontalMovement > verticalMovement) && (currentPosition.x < previousPosition.x))
        {
            sprite.GetComponent<Animator>().SetBool("Move", true);
            sprite.GetComponent<Animator>().SetBool("FaceLeft", true);
            sprite.GetComponent<Animator>().SetBool("FaceRight", false);
            sprite.GetComponent<Animator>().SetBool("FaceFront", false);
            sprite.GetComponent<Animator>().SetBool("FaceBack", false);
        }
        else if ((horizontalMovement < verticalMovement) && (currentPosition.y > previousPosition.y))
        {
            sprite.GetComponent<Animator>().SetBool("Move", true);
            sprite.GetComponent<Animator>().SetBool("FaceRight", false);
            sprite.GetComponent<Animator>().SetBool("FaceFront", true);
            sprite.GetComponent<Animator>().SetBool("FaceLeft", false);
            sprite.GetComponent<Animator>().SetBool("FaceBack", false);
        }
        else if ((horizontalMovement < verticalMovement) && (currentPosition.y < previousPosition.y))
        {
            sprite.GetComponent<Animator>().SetBool("Move", true);
            sprite.GetComponent<Animator>().SetBool("FaceRight", false);
            sprite.GetComponent<Animator>().SetBool("FaceFront", false);
            sprite.GetComponent<Animator>().SetBool("FaceLeft", false);
            sprite.GetComponent<Animator>().SetBool("FaceBack", true);
        }

        previousPosition = currentPosition;

        if (Vector3.Distance(transform.position, target.position) < detectionDistance)
        {
            Debug.Log(Vector3.Distance(transform.position, target.position));
            Vector3 direction = target.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, direction.magnitude, obstacleLayer);

            if (hit.collider == null)
            {
                destinationSetter.target = target.transform;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (isDead) return;

        if (collision.gameObject.CompareTag("PlayerBodyCollider"))
        {
            PlayerController playerController = collision.transform.parent.GetComponent<PlayerController>();
            playerController.Die(); 
        }
    }

    public void Die()
    {
        damageSound.Play();
        GameObject bloodEffect = Instantiate(bloodEffectPrefab, transform.position, Quaternion.identity);
        sprite.GetComponent<Animator>().SetBool("Dead", true);
        isDead = true;
        Destroy(bloodEffect, deathDelay);
        Destroy(gameObject, deathDelay);
        transform.Find("BodyCollider").GetComponent<BoxCollider2D>().enabled = false;
        transform.GetComponent<AIPath>().enabled = false;
        CircleCollider2D[] colliders = transform.Find("MovementCollider").GetComponents<CircleCollider2D>();
        foreach (CircleCollider2D collider in colliders)
        {
            collider.enabled = false;
        }
    }
}

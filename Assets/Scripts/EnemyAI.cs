using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform[] friend;
    [SerializeField] NavMeshAgent enemyAi;
    //public Transform player;
    Vector3 distance;
    public static int friendIndex;
    private float distanceFloat;
    private bool targetDetected;
    private Vector3 vecPos;

    [SerializeField] UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        friendIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(friend[friendIndex].position, this.transform.position) < 0.2f && ThrowBall.isExitFriend == false)
        {
                uIManager.gameOverScreen.SetActive(true);
        }
        if (targetDetected == true) //&& ThrowBall.isPickUp == false)
        {
            TargetDetected();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Friend")
        {
            targetDetected = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Friend")
        {
            targetDetected = false;
        }
    }
    void TargetDetected()
    {
        enemyAi.SetDestination(friend[friendIndex].position);
        //distance = friend[friendIndex].position - enemyAi.position ;
        //distance = distance.normalized; // The normalized direction in LOCAL space
        //transform.Translate(distance.x * Time.deltaTime * 15f, 3f, 3f);
        ////transform.LookAt(ball.position);
    }
}

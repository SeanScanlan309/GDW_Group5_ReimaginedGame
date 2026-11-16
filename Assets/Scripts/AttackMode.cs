using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackMode : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject aimer;
    [SerializeField] private float speed = 10;
    [SerializeField] private DamageCalculator dc;
    private float randomSpeed = 1;
    [SerializeField] private InputActionAsset inputAction;
    public TextMeshProUGUI text;
    private string doesAttackHit = "";

    private InputAction enterAction;
    private bool stop = false;
    private int moveNum;
    public bool CalculateHit()
    {
        float distance = aimer.transform.position.x - target.transform.position.x;
        float randomDistance = Random.Range(0.3f, 5);
        if (distance < randomDistance && distance > (-randomDistance))
        {
            return true;
        }
        return false;
    }
    public void Awake()
    {
        var playerActoinMap = inputAction.FindActionMap("Player");
        enterAction = playerActoinMap.FindAction("Enter");
        enterAction.Enable();

        randomSpeed = Random.Range(-8, 10);

        aimer.transform.position = new Vector2(-10, aimer.transform.position.y);
        stop = false;
    }



    // Update is called once per frame
    void Update()
    {
        
        if (aimer.transform.position.x > 10)
        {
            stop = true;
        }
        if (stop == false)
        {
            aimer.transform.position = new Vector2(aimer.transform.position.x + (Time.deltaTime * (speed + randomSpeed)), aimer.transform.position.y);
            if (enterAction.WasPressedThisFrame())
            {
                stop = true;
                if (CalculateHit())
                {

                    dc.Damage(moveNum);
                    //text.text = doesAttackHit;
                }
                else
                {
                    Debug.Log("YOU MISSED KID!");
                    text.text = "Miss!";
                }
            }
        }
        
    }
    public void SendInfo(int moveNumber)
    {
        moveNum = moveNumber;
    }
}

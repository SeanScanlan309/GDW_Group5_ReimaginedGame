using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Pokemon : MonoBehaviour
{
    void AddToListMoves(GameObject item)
    {
        if (item != null)
        {
            moveList.Add(item);
        }
    }
    void AddToListWeak(string item)
    {
        if (item != null)
        {
            weakToList.Add(item);
        }
    }
    void AddToListResist(string item)
    {
        if (item != null)
        {
            ressistantToList.Add(item);
        }
    }

    public GameObject selfObject;
    [SerializeField] private string elementType1;
    [SerializeField] private string elementType2;
    //[SerializeField] private int level = 1;
    [SerializeField] public int currentHealth;
    //[SerializeField] private int evoultionStage = 1;
    [SerializeField] private GameObject healthBar;
    private float desiredHealthWidth;
    [Header("MOVES")]
    [SerializeField] private GameObject move1;
    [SerializeField] private GameObject move2;
    [SerializeField] private GameObject move3;
    [SerializeField] private GameObject move4;

    public List<GameObject> moveList = new List<GameObject>();
    private SpriteRenderer spriteRenderer;


    [Header("STATS")]
    [SerializeField] private int damageStat = 1;
    //[SerializeField] private int speedStat = 1;
    [SerializeField] private int defenseStat = 1;
    //[SerializeField] private int specialAttackStat = 1;
    //[SerializeField] private int specialDefenseStat = 1;
    [SerializeField] private int maxHealth = 1;
    [Header("WEAK TO")]
    [SerializeField] private string weakToType1;
    [SerializeField] private string weakToType2;
    [SerializeField] private string weakToType3;
    [SerializeField] private string weakToType4;
    public List<string> weakToList = new List<string>();
    [Header("RESISTANT TO")]
    [SerializeField] private string resistantToType1;
    [SerializeField] private string resistantToType2;
    [SerializeField] private string resistantToType3;
    [SerializeField] private string resistantToType4;
    public List<string> ressistantToList = new List<string>();
    void Awake()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        AddToListMoves(move1);
        AddToListMoves(move2);
        AddToListMoves(move3);
        AddToListMoves(move4);

        AddToListWeak(weakToType1);
        AddToListWeak(weakToType2);
        AddToListWeak(weakToType3);
        AddToListWeak(weakToType4);

        AddToListResist(resistantToType1);
        AddToListResist(resistantToType2);
        AddToListResist(resistantToType3);
        AddToListResist(resistantToType4);

    }
    void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("dead");
            spriteRenderer.color = Color.white;
        }


    }
    void FixedUpdate()
    {
        
        if (currentHealth > 0)
        {
            GameObject healthShown = Instantiate(healthBar,new Vector3(transform.position.x + (healthBar.transform.localScale.x * ((float)currentHealth / (float)maxHealth)/2)-0.5f, transform.position.y + 1, transform.position.z), Quaternion.identity);
            healthShown.transform.localScale = new Vector3(healthShown.transform.localScale.x*((float)currentHealth/(float)maxHealth), healthShown.transform.localScale.y, healthShown.transform.localScale.z);
            Destroy(healthShown, 0.05f);
        }        
    }
}

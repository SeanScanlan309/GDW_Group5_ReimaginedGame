using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DamageCalculator : MonoBehaviour
{
    [Header("PlayerPokemon")]
    [SerializeField] private Pokemon playerPokemon1;
    [SerializeField] private Pokemon playerPokemon2;
    [SerializeField] private Pokemon playerPokemon3;
    [Header("EnemyPokemon")]
    [SerializeField] private Pokemon enemyPokemon1;
    [SerializeField] private Pokemon enemyPokemon2;
    [SerializeField] private Pokemon enemyPokemon3;
    [Header("Spawn")]
    [SerializeField] private GameObject spawn1;
    [SerializeField] private GameObject spawn2;
    private List<Pokemon> playerPokemonList = new List<Pokemon>();
    private List<Pokemon> enemyPokemonList = new List<Pokemon>();
    private bool playersTurn = true;
    private int playerInputAccuracy = 1;
    public TextMeshProUGUI text;

    public TextMeshProUGUI textMove1;
    public TextMeshProUGUI textMove2;

    public TextMeshProUGUI textMove3;
    public TextMeshProUGUI textMove4;

    public void DamageEnemy()
    {
        if (enemyPokemonList.Count != 0)
        {
            enemyPokemonList[0].currentHealth--;
        }

    }
    public void Damage(int moveInList)
    {
        GameObject move = playerPokemonList[moveInList].move1;
        moveBase moveScript = move.GetComponent<moveBase>();

        Pokemon enemy = enemyPokemonList[0];
        float damageMultiply = 1f;
        foreach (string type in enemy.ressistantToList)
        {
            if (type == moveScript.moveType)
            {
                damageMultiply = 0.5f;
            }
        }
        foreach (string type in enemy.weakToList)
        {
            if (type == moveScript.moveType)
            {
                damageMultiply = 2f;
            }
        }
        Debug.Log($"Damage : {moveScript.moveDamage * damageMultiply}");
        Debug.Log($"Health : {enemyPokemonList[0].currentHealth}");
        text.text = $" {moveScript.moveName} Hit For {moveScript.moveDamage}!";
        Debug.Log(text.text);
        enemyPokemonList[0].currentHealth -= (moveScript.moveDamage*damageMultiply);
    }
    void Awake()
    {
        playerPokemonList.Add(playerPokemon1);
        playerPokemonList.Add(playerPokemon2);
        playerPokemonList.Add(playerPokemon3);

        enemyPokemonList.Add(enemyPokemon1);
        enemyPokemonList.Add(enemyPokemon2);
        enemyPokemonList.Add(enemyPokemon3);
    }

    // Update is called once per frame
    void Update()
    {
        Pokemon playerPokemon = playerPokemonList[0];
        moveBase moveBase1 = playerPokemon.move1.GetComponent<moveBase>();
        textMove1.text = moveBase1.moveName;
        moveBase moveBase2 = playerPokemon.move2.GetComponent<moveBase>();
        textMove2.text = moveBase2.moveName;
        moveBase moveBase3 = playerPokemon.move3.GetComponent<moveBase>();
        textMove3.text = moveBase3.moveName;
        moveBase moveBase4 = playerPokemon.move4.GetComponent<moveBase>();
        textMove4.text = moveBase4.moveName;
        if (enemyPokemonList.Count != 0)
        {
            enemyPokemonList[0].transform.position = spawn2.transform.position;
            playerPokemonList[0].transform.position = spawn1.transform.position;
            if (enemyPokemonList[0].currentHealth <= 0)
            {
                //Debug.Log("!@#!#!@#!#");
                //Destroy(enemyPokemonList[0].GetComponent<GameObject>());
                enemyPokemonList[0].transform.position = new Vector2(100, 100);
                enemyPokemonList.Remove(enemyPokemonList[0]);
            }


        }
        else
        {
            Debug.Log("YOU WIN!");
        }

    }
}

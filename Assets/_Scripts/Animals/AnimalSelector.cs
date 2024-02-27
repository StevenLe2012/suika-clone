using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AnimalSelector : MonoBehaviour
{
    public static AnimalSelector Instance;

    public GameObject[] Animals;
    public GameObject[] NoPhysicsAnimals;
    public int HighestStartingIndex = 3;

    [SerializeField] private Image nextAnimalImage;
    
    [SerializeField] private Sprite[] AnimalSprites;
    
    public GameObject NextAnimal { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PickNextAnimal();
    }

    public GameObject PickRandomAnimalForThrow()
    {
        int randomIndex = Random.Range(0, HighestStartingIndex + 1);
        
        if (randomIndex < NoPhysicsAnimals.Length)
        {
            GameObject randomAnimal = NoPhysicsAnimals[randomIndex];
            return randomAnimal;
        }

        return null;
    }
    
    public void PickNextAnimal()
    {
        int randomIndex = Random.Range(0, HighestStartingIndex + 1);
        print("randomIndex: " + randomIndex);
        if (randomIndex < Animals.Length)
        {
            GameObject nextAnimal = NoPhysicsAnimals[randomIndex];
            NextAnimal = nextAnimal;
            nextAnimalImage.sprite = AnimalSprites[randomIndex];
        }
        // NextFruit = Fruits[randomIndex];
        // nextFruitImage.sprite = fruitSprites[randomIndex];
    }
}

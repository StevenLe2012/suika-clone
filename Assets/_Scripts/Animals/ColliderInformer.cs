using UnityEngine;

public class ColliderInformer : MonoBehaviour
{
    public bool WasCombinedIn { get; set; }

    private bool _hasCollided;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!_hasCollided && !WasCombinedIn)
        {
            _hasCollided = true;
            ThrowFruitController.Instance.CanThrow = true;
            ThrowFruitController.Instance.SpawnFruit(AnimalSelector.Instance.NextAnimal);
            AnimalSelector.Instance.PickNextAnimal();
            Destroy(this);
        }
    }
}

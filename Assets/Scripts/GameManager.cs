using UnityEngine;

public class GameManager : MonoBehaviour
{
    [field: SerializeField] public ColorsViewController ColorsViewController { private set; get; }
    [field: SerializeField] public CellsController CellsController { private set; get; }
    [field: SerializeField] public ConstructorsController ConstructorsController { private set; get; }

    public static GameManager Instance { private set; get; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(Instance);
        }
    }

    private void Start() {
        ConstructorsController.Init();
        CellsController.Init();
        ColorsViewController.Init(ConstructorsController);
    }
}

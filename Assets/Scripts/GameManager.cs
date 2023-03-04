using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [field: SerializeField] public LayerController LayerController { private set; get; }
    [field: SerializeField] public CellsController CellsController { private set; get; }

    public static GameManager Instance { private set; get; }

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }
        else {
            Destroy(Instance);
        }
    }

    private void Start() {
        LayerController.Init();
        CellsController.Init();   
    }
}

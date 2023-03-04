using UnityEngine;

public class ConstructorsController : MonoBehaviour
{
    [SerializeField] private PatternConstructor[] _pages;

    public PatternConstructor SelectedConstructor { private set; get; }

    public void Init() {
        SelectedConstructor = _pages[0];
        SelectedConstructor.Init();
    }

    public void ShowNextConsturctor() {
    }
}

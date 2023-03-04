using System;
using UnityEngine;

public class ConstructorsController : MonoBehaviour
{
    [SerializeField] private PatternConstructor[] _pages;

    public PatternConstructor SelectedConstructor { private set; get; }

    public event Action OnRandomColorsClick;

    public event Action OnNextPatternClick;

    public event Action OnPrevPatternClick;

    public void Init() {
        SelectedConstructor = _pages[0];
        SelectedConstructor.Init();
    }

    public void ShowNextConsturctor() {
    }

    public void SetRandomColors() {
        OnRandomColorsClick?.Invoke();
    }

    public void ClickNextPattern() {
        OnNextPatternClick?.Invoke();
    }

    public void ClickPrevPattern() {
        OnPrevPatternClick?.Invoke();
    }
}

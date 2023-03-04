
using System.Linq;
using UnityEngine;

public class PatternConstructor : MonoBehaviour
{
    [field: SerializeField] public PatternLayer[] PatternLayers;

    public delegate void PatternLayerDelegate(PatternLayer layer);
    public event PatternLayerDelegate OnPatternLayerChanged;

    public PatternLayer SelectedPattern { private set; get; }

    public void Init() {
        ShowPattern(PatternLayers[0]);
    }

    public void SetNextPattern() {
        ShowPattern(1);
    }

    public void SetPrevPattern() {
        ShowPattern(-1);
    }

    private void ShowPattern(int offset) {
        var currentIndex = PatternLayers.ToList().FindIndex(p => p == SelectedPattern);
        currentIndex += offset;

        if (currentIndex < 0) {
            currentIndex = PatternLayers.Length - 1;
        }
        else if (currentIndex >= PatternLayers.Length) {
            currentIndex = 0;
        }

        ShowPattern(PatternLayers[currentIndex]);
    }

    private void ShowPattern(PatternLayer layer) {
        SelectedPattern?.SetView(false);
        SelectedPattern = layer;
        SelectedPattern.SetView(true);
        OnPatternLayerChanged?.Invoke(SelectedPattern);
    }
}

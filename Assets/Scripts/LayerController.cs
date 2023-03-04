using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayerController : MonoBehaviour
{
    [SerializeField] private RectTransform[] _patternParents;
    [SerializeField] private Image[] _layers;
    [SerializeField] private ColorLayer _colorLayerPrefab;

    private List<PatternLayer> _patternLayers;
    private ColorLayer _selectedLayer;

    public void Init() {
        GameManager.Instance.CellsController.OnColorPicked += CellsController_OnColorPicked;
        
        foreach (var patternParent in _patternParents) {
            _patternLayers.Add(new PatternLayer(patternParent.GetComponentsInChildren<Image>()));
        }
        
        for (int i = 0; i < _layers.Length; i++) {
            var colorLayer = Instantiate(_colorLayerPrefab);
            colorLayer.Init(_layers[i], Color.white);
            colorLayer.OnSelected += ColorLayer_OnSelected;
        }
    }

    private void ColorLayer_OnSelected(ColorLayer colorLayer) {
        _selectedLayer?.SetSelect(false);
        _selectedLayer = colorLayer;
        _selectedLayer.SetSelect(true);
    }

    private void CellsController_OnColorPicked(Color color) {
        _selectedLayer.SetColor(color);
    }

    public void SetNextPattern() {

    }

    public void SetPrevPattern() {

    }
}

public class PatternLayer
{
    public Image[] Layers { get; private set; }

    public PatternLayer(Image[] layers) {
        Layers = layers;
    }
}

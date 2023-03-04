using UnityEngine;

public class ColorsViewController : MonoBehaviour
{
    [SerializeField] private ColorView[] _colorsView;

    public delegate void ColorViewSelectedDelegate(ColorView colorView);

    public event ColorViewSelectedDelegate OnColorViewSelected;

    private ColorView _selectedColorView;

    public void Init(ConstructorsController constructorsController) {
        GameManager.Instance.CellsController.OnColorPicked += CellsController_OnColorPicked;

        constructorsController.SelectedConstructor.OnPatternLayerChanged += PatternConstructor_OnPatternLayerChanged;
        Subscribe();
        InitColorsView(constructorsController.SelectedConstructor.SelectedPattern);
    }

    private void InitColorsView(PatternLayer pattern) {
        for (int i = 0; i < pattern.ImageLayers.Length; i++) {
            _colorsView[i].Init(pattern.ImageLayers[i], Color.white);
        }
    }

    public void SetRandomColors() {
        foreach (var view in _colorsView) {
            view.SetColor(GameManager.Instance.CellsController.GetRandomColor());
        }
    }

    private void Subscribe() {
        foreach (var colorView in _colorsView) {
            colorView.OnSelected += ColorView_OnSelected;
        }
    }

    private void PatternConstructor_OnPatternLayerChanged(PatternLayer layer) {
        foreach (var view in _colorsView) {
            view.gameObject.SetActive(false);
        }

        for (int i = 0; i < layer.ImageLayers.Length; i++) {
            InitColorsView(layer);
            //TODO: saving color
        }
    }

    private void ColorView_OnSelected(ColorView colorLayer) {
        SelectColorView(colorLayer);
    }

    private void SelectColorView(ColorView colorLayer) {
        _selectedColorView?.SetSelection(false);
        _selectedColorView = colorLayer;
        _selectedColorView.SetSelection(true);
        OnColorViewSelected?.Invoke(_selectedColorView);
    }

    private void CellsController_OnColorPicked(Color color) {
        _selectedColorView?.SetColor(color);
    }
}

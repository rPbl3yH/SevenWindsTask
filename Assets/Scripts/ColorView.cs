
using UnityEngine;
using UnityEngine.UI;

public class ColorView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _borders;

    public Color Color { get; private set; }

    public delegate void LayerSelected(ColorView colorLayer);
    public event LayerSelected OnSelected;

    private Image _targetImage;

    public void Init(Image targetImage, Color color) {
        gameObject.SetActive(true);
        _targetImage = targetImage;
        SetColor(color);
        _borders.gameObject.SetActive(false);
    }

    public void SetColor(Color color) {
        Color = color;
        _targetImage.color = color;
        _image.color = color;
    }

    public void Click() {
        OnSelected?.Invoke(this);
    }

    public void SetSelection(bool isSelect) {
        _borders.gameObject.SetActive(isSelect);
    }
}

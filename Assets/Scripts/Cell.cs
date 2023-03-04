using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _borders;

    public Color Color { get; private set; }

    public delegate void OnSelectedDelegate(Cell cell);

    public event OnSelectedDelegate OnSelected;

    public void Init(Color color) {
        Color = color;
        _image.color = color;
        _borders.gameObject.SetActive(false);
    }

    public void Click() {
        OnSelected?.Invoke(this);
    }

    public void SetSelection(bool isSelect) {
        _borders.gameObject.SetActive(isSelect);
    }
}

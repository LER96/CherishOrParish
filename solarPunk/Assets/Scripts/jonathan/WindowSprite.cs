using UnityEngine;

public class WindowSprite : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _index;
    
    private Sprite _sprite;
    private bool _isOn = false;

    public bool IsOn
    {
        get => _isOn;
    }
    
    public int Index
    {
        get => _index;
    }

    public string Name
    {
        get => _name;
    }
    
    public Sprite Sprite
    {
        get => _sprite;
    }

    private void Start()
    {
        _sprite = GetComponent<Sprite>();
    }

    public void TurnOn()
    {
        _isOn = true;
        gameObject.SetActive(true);
    }
}

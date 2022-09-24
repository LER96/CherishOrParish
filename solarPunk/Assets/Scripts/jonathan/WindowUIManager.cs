using UnityEngine;

public class WindowUIManager : MonoBehaviour
{
    [SerializeField] private WindowSprite[] _sprites;

    private void Start()
    {
        foreach (var windowSprite in _sprites)
        {
            windowSprite.gameObject.SetActive(false);
        }
    }

    public void LoadSprite(int spriteIndex)
    {
        FindWindowSprite(spriteIndex).TurnOn();
    }
    
    public void LoadSprite(string windowName)
    {
        FindWindowSprite(windowName).TurnOn();
    }

    public WindowSprite FindWindowSprite(int spriteIndex)
    {
        foreach (var windowSprite in _sprites)
        {
            if (windowSprite.Index == spriteIndex)
            {
                return windowSprite;
            }
        }

        Debug.LogWarning("Cant Find Sprite");
        return null;
    }
    
    public WindowSprite FindWindowSprite(string spriteName)
    {
        foreach (var windowSprite in _sprites)
        {
            if (windowSprite.name == spriteName)
            {
                return windowSprite;
            }
        }

        Debug.LogWarning("Cant Find Sprite");
        return null;
    }
}

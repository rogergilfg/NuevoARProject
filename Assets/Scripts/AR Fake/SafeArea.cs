using UnityEngine;

public class SafeArea : MonoBehaviour
{
    private RectTransform rectTransform;
    private Rect lastSafeArea;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        lastSafeArea = Rect.zero;
    }

    void Update()
    {
        if (Screen.safeArea != lastSafeArea)
        {
            AppSafeArea(Screen.safeArea);
        }
    }

    void AppSafeArea(Rect safeArea)
    {
        lastSafeArea = safeArea;

        Vector2 anchorMin = safeArea.position / new Vector2(Screen.width, Screen.height);
        Vector2 anchorMax = (safeArea.position + safeArea.size) / new Vector2(Screen.width, Screen.height);

        rectTransform.anchorMin = anchorMin;
        rectTransform.anchorMax = anchorMax;
    }
}

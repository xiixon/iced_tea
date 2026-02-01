using UnityEngine;

public class ShopSwipe : MonoBehaviour
{
    private Vector2 startTouch;
    private bool isSwiping;

    public System.Action OnSwipeLeft;
    public System.Action OnSwipeRight;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                startTouch = t.position;
                isSwiping = true;
            }
            else if (t.phase == TouchPhase.Ended)
            {
                if (!isSwiping) return;

                Vector2 delta = t.position - startTouch;

                if (Mathf.Abs(delta.x) > 100f) // threshold
                {
                    if (delta.x > 0)
                        OnSwipeRight?.Invoke();
                    else
                        OnSwipeLeft?.Invoke();
                }

                isSwiping = false;
            }
        }
    }
}
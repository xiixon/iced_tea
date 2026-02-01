using UnityEngine;
using UnityEngine.EventSystems;

public class ShopSwipe : MonoBehaviour
{
    private Vector2 startTouch;
    private bool isSwiping;

    public System.Action OnSwipeLeft;
    public System.Action OnSwipeRight;

    void Start()
    {
        transform.position = new Vector3(1080, 0, 0);
    }

    void Update()
    {
        // Block if touching UI
        if (EventSystem.current.IsPointerOverGameObject(0))
            return;

        #if UNITY_EDITOR
            // Mouse version
            if (Input.GetMouseButtonDown(0))
            {
                startTouch = Input.mousePosition;
                isSwiping = true;
            }
            else if (Input.GetMouseButtonUp(0) && isSwiping)
            {
                Vector2 delta = (Vector2)Input.mousePosition - startTouch;
                HandleSwipe(delta);
                isSwiping = false;
            }
        #else
            // Mobile version
            if (Input.touchCount > 0)
            {
                Touch t = Input.GetTouch(0);

                if (t.phase == TouchPhase.Began)
                {
                    startTouch = t.position;
                    isSwiping = true;
                }
                else if (t.phase == TouchPhase.Ended && swiping)
                {
                    Vector2 delta = t.position - startTouch;
                    HandleSwipe(delta);
                    isSwiping = false;
                }
            }
        #endif
    }

    void HandleSwipe(Vector2 delta)
    {
        if (Mathf.Abs(delta.x) > 50f)
        {
            if (delta.x > 0)
                OnSwipeRight?.Invoke();
            else
                OnSwipeLeft?.Invoke();
        }
    }
}
        

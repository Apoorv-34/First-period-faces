using UnityEngine;

public class PerfectSnap : MonoBehaviour
{
    public RectTransform handle;
    public RectTransform perfectArea;
    public PingPongSlider slider;

    bool snapped = false;

    void Update()
    {
        if (snapped) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            snapped = true;

            if (IsInsidePerfectZone())
            {
                Debug.Log("Perfect!");
                slider.AddPoint();
            }
            else
            {
                Debug.Log("Miss!");
            }

            Invoke(nameof(ResetSnap), 0.15f);
        }
    }

    void ResetSnap()
    {
        snapped = false;
    }

    bool IsInsidePerfectZone()
    {
        Vector3 handlePos = handle.position;
        Vector3[] areaCorners = new Vector3[4];
        perfectArea.GetWorldCorners(areaCorners);

        return handlePos.x >= areaCorners[0].x &&
               handlePos.x <= areaCorners[2].x;
    }
}

using UnityEngine;

public class MobilityLimiter
{
    private Vector2 min = new Vector2();
    private Vector2 max = new Vector2();

    public void moveLimit(PlayerController player)
    {
        var mainCamera = Camera.main;
        min = mainCamera.ViewportToWorldPoint(new Vector2(0.0f, 0.0f));
        max = mainCamera.ViewportToWorldPoint(new Vector2(1.0f, 1.0f));
        player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, min.x, max.x),
            Mathf.Clamp(player.transform.position.y, min.y, max.y),
            player.transform.position.z);
    }
}

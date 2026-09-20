using UnityEngine;

public class TrajectoryPredictor : MonoBehaviour
{
    // Fix SCRUM-19: clamp trajectory endpoint to actual collider surface
    public Vector3 GetAdjustedLandingPoint(Vector3 predictedLanding)
    {
        if (Physics.Raycast(predictedLanding + Vector3.up * 5f, Vector3.down, out RaycastHit hit, 10f))
        {
            // Snap the predicted Y coordinate to the actual terrain height,
            // so the visual trajectory line matches uneven mesh colliders.
            predictedLanding.y = hit.point.y;
        }
        return predictedLanding;
    }
}

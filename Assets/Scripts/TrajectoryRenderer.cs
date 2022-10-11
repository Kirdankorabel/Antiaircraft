using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    private LineRenderer lineRendererComponent;

    private void Start()
    {
        lineRendererComponent = GetComponent<LineRenderer>();
    }

    public Vector3[] ShowTrajectory(MoveEquation positionCaclulator, int pointsCount, float step)
    {
        Vector3[] points = new Vector3[pointsCount];
        lineRendererComponent.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * step;
            points[i] = positionCaclulator.CalcPosition(time);

            if (points[i].y < 0)
            {
                lineRendererComponent.positionCount = i + 1;
                break;
            }
        }

        lineRendererComponent.SetPositions(points);
        return points;
    }
}
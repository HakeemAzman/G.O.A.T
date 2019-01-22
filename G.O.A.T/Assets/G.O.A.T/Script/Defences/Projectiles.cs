using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour {

    [Header ("Projectile Settings")]
    public float speed;
    public int predictionStepPerFrame = 6;
    public Vector3 projectileVelocity;

    [Header("Tracer")]
    public GameObject trajectoryTrace;

    [Header("Raycast hit")]
    RaycastHit hit;
    Vector3 placementPosition;

    [Header("Things To Spawn")]
    public GameObject tower_OR_troops;

    private void Start()
    {
        Tracer();
    }

    private void Update()
    {
        ProjectileBehavior();
    }

    void ProjectileBehavior()
    {
            Vector3 point1 = this.transform.position;
            float stepSize = 1.0f / predictionStepPerFrame; //Based of Set Number in Inspector

            for (float step = 0; step < 1; step += stepSize)
            {
                projectileVelocity += Physics.gravity * stepSize * Time.deltaTime;
                Vector3 point2 = point1 + transform.TransformDirection(projectileVelocity) * stepSize * Time.deltaTime;

                Ray ray = new Ray(point1, point2 - point1);

                if (Physics.Raycast(ray, out hit, (point2 - point1).magnitude))
                {
                    if(hit.collider.tag == "Floor")
                    {
                    placementPosition = hit.point;
                    Instantiate(tower_OR_troops, placementPosition, Quaternion.identity);
                    }

                if (hit.collider.tag == "SF")
                {
                    print("SF hit");
                }
            }
                point1 = point2;
            }
            this.transform.position = point1;
    }

    private void Tracer()
    {
        //Gizmos.color = Color.red;
        Vector3 point1 = this.transform.position;
        Vector3 predictedBulletVelocity = projectileVelocity;

        float stepSize = 0.01f;

        for (float step = 0; step < 1; step += stepSize)
        {
            predictedBulletVelocity += Physics.gravity * stepSize;
            Vector3 point2 = point1 + transform.TransformDirection(predictedBulletVelocity) * stepSize;
            //Gizmos.DrawLine(point1, point2);
            point1 = point2;
            trajectoryTrace = (GameObject)Instantiate(trajectoryTrace);
            trajectoryTrace.transform.position = point2;
            Destroy(trajectoryTrace, 1f);
        }
    }
}

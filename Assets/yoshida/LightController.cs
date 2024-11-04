using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LightController : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCamera;
    [SerializeField] private float rotationSpeedMultiplier = 500f;

    private bool canMoveCamera = true;

    void Start()
    {
        mainCamera = Camera.main;
        GameOverManager.Instance.IsGameOverProp.
            TakeUntilDestroy(this).Where(value => value).Subscribe(_ => canMoveCamera = false);
        GoalManager.Instance.IsGoalProp.
            TakeUntilDestroy(this).Where(value => value).Subscribe(_ => canMoveCamera = false);
    }

    // Update is called once per frame
    void Update()
    {
       if(canMoveCamera)
        {
            RotateLight();
        }
    }

    private void RotateLight()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, angle), rotationSpeedMultiplier * Time.deltaTime);
    }
}

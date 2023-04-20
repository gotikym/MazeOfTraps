using System.Collections;
using UnityEngine;

public class AxeTrap : Trap
{
    [SerializeField] private float _rotationSpeed;

    protected override IEnumerator ActivateTrap()
    {
        base.ActivateTrap();

        while (true)
        {
            transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
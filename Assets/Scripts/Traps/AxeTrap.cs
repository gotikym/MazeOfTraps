using System.Collections;
using UnityEngine;

public class AxeTrap : Trap
{
    [SerializeField] private float _rotationSpeed;

    protected override IEnumerator ActivateTrap()
    {
        yield return new WaitForSeconds(_delayBeforeStart);
        _audioSource.Play();

        while (true)
        {
            transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
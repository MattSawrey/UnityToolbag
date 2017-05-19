using System.Collections;
using UnityEngine;

public static class EnumeratorStatics
{
    public static IEnumerator TimeIndependantWaitForSeconds(float seconds)
    {
        float timer = 0f;
        while (timer < seconds)
        {
            timer += Time.fixedDeltaTime;
            yield return null;
        }
    }
}

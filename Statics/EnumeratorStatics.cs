using System.Collections;
using UnityEngine;

public static class EnumeratorStatics
{
    // Bases the wait time on the delta time from the last frame (time the last frame took to execute)
    public static IEnumerator TimeIndependantWaitForSeconds(float seconds)
    {
        float timer = 0f;
        while (timer < seconds)
        {
            timer += Time.deltaTime;
            yield return null;
        }
    }
}

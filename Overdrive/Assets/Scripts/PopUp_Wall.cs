using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PopUp_Wall : MonoBehaviour
{
    public AK.Wwise.Event Beep;
    [Range(1,8)] public int WarningTime;
    [Range(1,3)] public int WarningAmount;
    public Transform[] Warnings;

    private void OnValidate()
    {
        if(Warnings[0] == null) fillWarning();

        ActivateWarning();

        placeWarnings();
    }

    void placeWarnings()
    {
        for (int i = 0; i < Warnings.Length; i++)
        {
            Vector3 newpos = transform.position;
            newpos.z = Mathf.Lerp(10 * WarningTime, 0 ,(float)(i) / (WarningAmount));
            Warnings[i].position = newpos;
        }
    }

    private void fillWarning()
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            Warnings[i] = child.transform;
            i++;
        }
    }

    private void ActivateWarning()
    {
        for (int i = Warnings.Length - 1; i >= 0; i--)
        {
            if (i < WarningAmount) Warnings[i].gameObject.SetActive(true);
            else Warnings[i].gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2 : MonoBehaviour
{
    public GameObject Orb1;
    public GameObject Orb2;
    public GameObject VerticalPrefab;
    public static int OrbStack;
    // Start is called before the first frame update
    void Start()
    {
        OrbStack = 2;

        StartCoroutine(Vertical());
    }
    // Update is called once per frame
    void Update()
    {
        if (OrbStack==0)
        {
            KingMain.OpenPhase++;
            Destroy(gameObject);
        }
    }

    IEnumerator Vertical()
    {
        while (true)
        {

            VerticalSkill(-11);
            yield return new WaitForSeconds(3f);
            VerticalSkill(-12);
            yield return new WaitForSeconds(3f);
        }
    }
    void VerticalSkill(float VSspawn)
    {
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, 5, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, 5, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, 5, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, 5, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, 5, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, 5, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, 5, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, 5, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, 5, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, 5, 0), VerticalPrefab.transform.rotation, gameObject.transform);

    }

}

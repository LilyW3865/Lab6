using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.Rendering;

public class DesertScene : MonoBehaviour
{

    public int sizeofforest;
    public int stonesRequired;
    public GameObject[] trees;
    public GameObject[] stones;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InitalizeVariables();
        CreateGround();
        CreateRandomForest();
        //CreatePyramid();



    }

    /*void InitalizeVariables()
    {
        GameObject cubeParent = new GameObject("CubeParent");
    }*/

    void CreateGround()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        Renderer renderer = plane.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard"));
        renderer.material.color = Color.green;
    }
    void CreateRandomForest()
    {
        GameObject testParent = new GameObject("TestParent");

        for (int i = 0; i < 4; i++)
        {
            GameObject test = GameObject.CreatePrimitive(PrimitiveType.Cube);
            test.transform.parent = testParent.transform;
            test.transform.position = new Vector3(i * 2, 0, 0);
        }

        float scaleX = UnityEngine.Random.Range(0.5f, 2.0f);
        float scaleY = UnityEngine.Random.Range(0.5f, 2.0f);
        float scaleZ = UnityEngine.Random.Range(0.5f, 2.0f);
       // test.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);

    }
   /*  void CreatePyramid()

     {
        GameObject cubeParent = new GameObject("CubeParent");

        for (int i = 0; i < 4; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.parent = cubeParent.transform;
            cube.transform.position = new Vector3(i * 2, 0, 0);
        }

     }*/

    // Update is called once per frame
    void Update()
    {

    }

}





       
   




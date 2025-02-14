using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class DesertScene : MonoBehaviour
{

    public int sizeofforest;
    public int stonesRequired;
    public GameObject[] trees;
    public GameObject[] stones;
    public int pyramidSize = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InitalizeVariables();
        CreateGround();
        CreateRandomForest();
        CreatePyramid();
    }

    /*void InitalizeVariables()
    {
        GameObject cubeParent = new GameObject("CubeParent");
    }*/

    void CreateGround()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.localScale = new Vector3(2, 1, 2); //enlarges plane

        Renderer renderer = plane.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard"));
        renderer.material.color = Color.green;
    }
    void CreateRandomForest()
    {
        GameObject cylinderParent = new GameObject("CylinderParent");

        //creates rows and columns of trees (x and z axis)
        int rowsofForest = 5;
        int columnsofForest = 5;

        for (int x = 0; x < rowsofForest; x++)
        {
            for (int z = 0; z < columnsofForest; z++)
            {
                GameObject randomcylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                randomcylinder.transform.parent = cylinderParent.transform;
                randomcylinder.GetComponent<Renderer>().material.color = Color.green;
                randomcylinder.transform.parent = randomcylinder.transform;

                //randomize scale and position of trees
                float scaleX = UnityEngine.Random.Range(0.1f, 2.0f);
                float scaleY = UnityEngine.Random.Range(0.5f, 2.0f);
                float scaleZ = UnityEngine.Random.Range(0.1f, 2.0f);
                randomcylinder.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
                float positionX = UnityEngine.Random.Range(2.0f, 7.0f);
                float positionZ = UnityEngine.Random.Range(-2.0f, 7.0f);
                randomcylinder.transform.position = new Vector3(positionX, scaleY, positionZ);//keeps y value from falling through plane

            }
        }

    }
    void CreatePyramid()

    {
        GameObject cubeParent = new GameObject("CubeParent");
        float cubeSize = 1.0f;
        float spacing = 1.1f;
        float pyramidBaseHeight = cubeSize / 2; //keep cubes above the plane
        float xShift = -2.0f; //shifts pyramid slightly to right for room for forest

        for (int y = 0; y < pyramidSize; y++)
        {
            int cubesInLayer = pyramidSize - y; //reduce cubes on layer value as layers rise up in the loop
            for (int x = 0; x < cubesInLayer; x++)
            {
                for (int z = 0; z < cubesInLayer; z++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.parent = cubeParent.transform;

                    float xOffset = (cubesInLayer - 1) * 0.5f * spacing; //for centering cubes along x axis
                    float zOffset = (cubesInLayer - 1) * 0.5f * spacing; //for centering cubes along z axis

                    cube.transform.position = new Vector3(
                        x * spacing - xOffset + xShift, //adjusts lef and right (along x axis)
                        pyramidBaseHeight + y * spacing, //keep cubes above plane level           
                        z * spacing - zOffset //adjusts forward and back (along z axis)
                    );
                    if (cubesInLayer == 5)
                    {
                        cube.GetComponent<Renderer>().material.color = Color.black;
                    }

                    if (cubesInLayer == 4)
                    {
                        cube.GetComponent<Renderer>().material.color = Color.white;
                    }

                    if (cubesInLayer == 3)
                    {
                        cube.GetComponent<Renderer>().material.color = Color.red;
                    }

                    if (cubesInLayer == 2)
                    {
                        cube.GetComponent<Renderer>().material.color = Color.blue;
                    }

                    if (cubesInLayer == 1)
                    {
                        cube.GetComponent<Renderer>().material.color = Color.green;
                    }
                }
            }
        }
        /*
                  for (int i = 0; i < 4; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.parent = cubeParent.transform;
            cube.transform.position = new Vector3(i * 2, 0, 0);
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }

}











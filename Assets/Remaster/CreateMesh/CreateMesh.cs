using UnityEngine;

public class CreateMesh : MonoBehaviour
{
    [SerializeField]
    private Material _material;
    private int[] triangles;
    public CustomCube customCube;
    void Start()
    {
    }

    private void Test1()
    {
        Vector3[] vertices = new Vector3[24];
        //face
        vertices[0] = new(0, 1, 0);
        vertices[1] = new(1, 1, 0);
        vertices[2] = new(0, 0, 0);
        vertices[3] = new(1, 0, 0);
        //left
        vertices[4] = new(0, 1, 1);
        vertices[5] = new(0, 1, 0);
        vertices[6] = new(0, 0, 1);
        vertices[7] = new(0, 0, 0);
        //right
        vertices[8] = new(1, 1, 0);
        vertices[9] = new(1, 1, 1);
        vertices[10] = new(1, 0, 0);
        vertices[11] = new(1, 0, 1);
        //back
        vertices[12] = new(1, 1, 1);
        vertices[13] = new(0, 1, 1);
        vertices[14] = new(1, 0, 1);
        vertices[15] = new(0, 0, 1);
        //up
        vertices[16] = new(0, 1, 1);
        vertices[17] = new(1, 1, 1);
        vertices[18] = new(0, 1, 0);
        vertices[19] = new(1, 1, 0);
        //down
        vertices[20] = new(0, 0, 0);
        vertices[21] = new(1, 0, 0);
        vertices[22] = new(0, 0, 1);
        vertices[23] = new(1, 0, 1);


        int[] triangles = new int[36];
        //face
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 2;
        triangles[4] = 1;
        triangles[5] = 3;
        //left
        triangles[6] = 4;
        triangles[7] = 5;
        triangles[8] = 6;
        triangles[9] = 6;
        triangles[10] = 5;
        triangles[11] = 7;
        //right
        triangles[12] = 8;
        triangles[13] = 9;
        triangles[14] = 10;
        triangles[15] = 10;
        triangles[16] = 9;
        triangles[17] = 11;
        //back
        triangles[18] = 12;
        triangles[19] = 13;
        triangles[20] = 14;
        triangles[21] = 14;
        triangles[22] = 13;
        triangles[23] = 15;
        //up
        triangles[24] = 16;
        triangles[25] = 17;
        triangles[26] = 18;
        triangles[27] = 18;
        triangles[28] = 17;
        triangles[29] = 19;
        //down
        triangles[30] = 20;
        triangles[31] = 21;
        triangles[32] = 22;
        triangles[33] = 22;
        triangles[34] = 21;
        triangles[35] = 23;

        Vector2[] uv = new Vector2[24];
        uv[0] = new(0, 1);
        uv[1] = new(1, 1);
        uv[2] = new(0, 0);
        uv[3] = new(1, 0);

        uv[4] = new(0, 1);
        uv[5] = new(1, 1);
        uv[6] = new(0, 0);
        uv[7] = new(1, 0);

        uv[8] = new(0, 1);
        uv[9] = new(1, 1);
        uv[10] = new(0, 0);
        uv[11] = new(1, 0);

        uv[12] = new(0, 1);
        uv[13] = new(1, 1);
        uv[14] = new(0, 0);
        uv[15] = new(1, 0);

        uv[16] = new(0, 1);
        uv[17] = new(1, 1);
        uv[18] = new(0, 0);
        uv[19] = new(1, 0);

        uv[20] = new(0, 1);
        uv[21] = new(1, 1);
        uv[22] = new(0, 0);
        uv[23] = new(1, 0);


        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        GameObject go = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider));
        go.transform.localScale = new Vector3(10, 10, 10);
        //mesh.Optimize();
        //mesh.RecalculateNormals();
        go.GetComponent<MeshFilter>().mesh = mesh;
        go.GetComponent<MeshRenderer>().material = _material;


        //go.GetComponent<MeshCollider>().sharedMesh = mesh;
        //go.GetComponent<MeshCollider>().convex= true;
    }

    private void Test2()
    {
        Vector3[] vertices = new Vector3[24];
        //face
        vertices[0] = vertices[18] = vertices[5] = new(0, 1, 0);
        vertices[1] = vertices[8] = vertices[19] = new(1, 1, 0);
        vertices[2] = vertices[7] = vertices[20] = new(0, 0, 0);
        vertices[3] = vertices[10] = vertices[21] = new(1, 0, 0);
        //left
        vertices[4] = vertices[13] = vertices[16] = new(0, 1, 1);
        vertices[6] = vertices[15] = vertices[22] = new(0, 0, 1);
        //right
        vertices[9] = vertices[12] = vertices[17] = new(1, 1, 1);
        vertices[11] = vertices[14] = vertices[23] = new(1, 0, 1);

        triangles = new int[36];
        for (int i = 0, d = 0; i < 12; i += 2, d += 4)
        {
            triangles[0 + i + d] = 0 + d;
            triangles[1 + i + d] = triangles[4 + i + d] = 1 + d;
            triangles[2 + i + d] = triangles[3 + i + d] = 2 + d;
            triangles[5 + i + d] = 3 + d;
        }

        Vector2[] uv = new Vector2[24];
        uv[0] = uv[4] = uv[8] = uv[12] = uv[16] = uv[20] = new(0, 1);
        uv[1] = uv[5] = uv[9] = uv[13] = uv[17] = uv[21] = new(1, 1);
        uv[2] = uv[6] = uv[10] = uv[14] = uv[18] = uv[22] = new(0, 0);
        uv[3] = uv[7] = uv[11] = uv[15] = uv[19] = uv[23] = new(1, 0);

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        GameObject go = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider));
        go.transform.localScale = new Vector3(10, 10, 10);
        mesh.Optimize();
        mesh.RecalculateNormals();
        go.GetComponent<MeshFilter>().mesh = mesh;
        go.GetComponent<MeshRenderer>().material = _material;


        go.GetComponent<MeshCollider>().sharedMesh = mesh;
        go.GetComponent<MeshCollider>().convex = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            customCube = new CustomCube(_material, gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            if (customCube != null)
                customCube.Hit(Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            if (customCube != null)
                customCube.Hit(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            if (customCube != null)
                customCube.Hit(Vector3.back);
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (customCube != null)
                customCube.Hit(Vector3.forward);
        }
    }
}
[System.Serializable]
public class CustomUV
{
    public Vector2[] uv = new Vector2[24];

    public CustomUV()
    {
        uv[0] = uv[4] = uv[8] = uv[12] = uv[16] = uv[20] = new(0, 1);
        uv[1] = uv[5] = uv[9] = uv[13] = uv[17] = uv[21] = new(1, 1);
        uv[2] = uv[6] = uv[10] = uv[14] = uv[18] = uv[22] = new(0, 0);
        uv[3] = uv[7] = uv[11] = uv[15] = uv[19] = uv[23] = new(1, 0);
    }
}
[System.Serializable]
public class CustomTriangles
{
    public int[] triangles;

    public CustomTriangles()
    {
        triangles = new int[36];
        for (int i = 0, d = 0; i < 12; i += 2, d += 4)
        {
            triangles[0 + i + d] = 0 + d;
            triangles[1 + i + d] = triangles[4 + i + d] = 1 + d;
            triangles[2 + i + d] = triangles[3 + i + d] = 2 + d;
            triangles[5 + i + d] = 3 + d;
        }
    }
}
[System.Serializable]
public class CustomVertices
{
    public Vector3[] vertices = new Vector3[24];

    public CustomVertices()
    {
        //vertices[0] = vertices[18] = vertices[5] = new(0, 1, 0);
        //vertices[1] = vertices[8] = vertices[19] = new(1, 1, 0);
        //vertices[2] = vertices[7] = vertices[20] = new(0, 0, 0);
        //vertices[3] = vertices[10] = vertices[21] = new(1, 0, 0);
        //vertices[4] = vertices[13] = vertices[16] = new(0, 1, 1);
        //vertices[6] = vertices[15] = vertices[22] = new(0, 0, 1);
        //vertices[9] = vertices[12] = vertices[17] = new(1, 1, 1);
        //vertices[11] = vertices[14] = vertices[23] = new(1, 0, 1);

        vertices[0] = vertices[18] = vertices[5] = new(-0.5f, 1, -0.5f);
        vertices[1] = vertices[8] = vertices[19] = new(0.5f, 1, -0.5f);
        vertices[2] = vertices[7] = vertices[20] = new(-0.5f, 0, -0.5f);
        vertices[3] = vertices[10] = vertices[21] = new(0.5f, 0, -0.5f);
        vertices[4] = vertices[13] = vertices[16] = new(-0.5f, 1, 0.5f);
        vertices[6] = vertices[15] = vertices[22] = new(-0.5f, 0, 0.5f);
        vertices[9] = vertices[12] = vertices[17] = new(0.5f, 1, 0.5f);
        vertices[11] = vertices[14] = vertices[23] = new(0.5f, 0, 0.5f);
    }
}

[System.Serializable]
public class CustomCube
{
    public CustomUV customUV;
    public CustomTriangles customTriangles;
    public CustomVertices customVertices;
    private Mesh _mesh;
    GameObject gameObject;

    public Vector3 size = Vector3.zero;
    public Vector3 invSize = Vector3.zero;
    public Vector3 _currentSize = Vector3.one;

    public CustomCube(Material material, GameObject parent)
    {
        customUV = new CustomUV();
        customTriangles = new CustomTriangles();
        customVertices = new CustomVertices();

        _mesh = new Mesh();
        _mesh.vertices = customVertices.vertices;
        _mesh.uv = customUV.uv;
        _mesh.triangles = customTriangles.triangles;
        parent.transform.localScale = new Vector3(0.5f, 1f, 0.5f);
        _mesh.Optimize();
        _mesh.RecalculateNormals();
        parent.GetComponent<MeshFilter>().mesh = _mesh;
        parent.GetComponent<MeshRenderer>().material = material;
        parent.GetComponent<MeshCollider>().sharedMesh = _mesh;
        parent.GetComponent<MeshCollider>().convex = true;

        gameObject = parent;
    }

    public bool Hit(Vector3 direction)
    {
        size = Vector3.zero;
        invSize = Vector3.zero;

        if (direction == Vector3.left)
        {
            size.x -= 0.25f;
            _currentSize.x += size.x;
        }

        if (direction == Vector3.back)
        {
            size.z -= 0.25f;
            _currentSize.z += size.z;
        }

        if (direction == Vector3.forward)
        {
            invSize.z += 0.25f;
            _currentSize.z -= invSize.z;
        }

        if (direction == Vector3.right)
        {
            invSize.x += 0.25f;
            _currentSize.x -= invSize.x;
        }

        //face
        customVertices.vertices[0] = new(customVertices.vertices[0].x + invSize.x, customVertices.vertices[0].y, customVertices.vertices[0].z + invSize.z);
        customVertices.vertices[1] = new(customVertices.vertices[1].x + size.x, customVertices.vertices[1].y, customVertices.vertices[1].z + invSize.z);
        customVertices.vertices[2] = new(customVertices.vertices[2].x + invSize.x, customVertices.vertices[2].y, customVertices.vertices[2].z + invSize.z);
        customVertices.vertices[3] = new(customVertices.vertices[3].x + size.x, customVertices.vertices[3].y, customVertices.vertices[3].z + invSize.z);
        // левую не трогаем
        customVertices.vertices[4] = new(customVertices.vertices[4].x + invSize.x, customVertices.vertices[4].y, customVertices.vertices[4].z + size.z);
        customVertices.vertices[5] = new(customVertices.vertices[5].x + invSize.x, customVertices.vertices[5].y, customVertices.vertices[5].z + invSize.z);
        customVertices.vertices[6] = new(customVertices.vertices[6].x + invSize.x, customVertices.vertices[6].y, customVertices.vertices[6].z + size.z);
        customVertices.vertices[7] = new(customVertices.vertices[7].x + invSize.x, customVertices.vertices[7].y, customVertices.vertices[7].z + invSize.z);
        //правая
        customVertices.vertices[8] = new(customVertices.vertices[8].x + size.x, customVertices.vertices[8].y, customVertices.vertices[8].z + invSize.z);
        customVertices.vertices[9] = new(customVertices.vertices[9].x + size.x, customVertices.vertices[9].y, customVertices.vertices[9].z + size.z);
        customVertices.vertices[10] = new(customVertices.vertices[10].x + size.x, customVertices.vertices[10].y, customVertices.vertices[10].z + invSize.z);
        customVertices.vertices[11] = new(customVertices.vertices[11].x + size.x, customVertices.vertices[11].y, customVertices.vertices[11].z + size.z);
        //back
        customVertices.vertices[12] = new(customVertices.vertices[12].x + size.x, customVertices.vertices[12].y, customVertices.vertices[12].z + size.z);
        customVertices.vertices[13] = new(customVertices.vertices[13].x + invSize.x, customVertices.vertices[13].y, customVertices.vertices[13].z + size.z);
        customVertices.vertices[14] = new(customVertices.vertices[14].x + size.x, customVertices.vertices[14].y, customVertices.vertices[14].z + size.z);
        customVertices.vertices[15] = new(customVertices.vertices[15].x + invSize.x, customVertices.vertices[15].y, customVertices.vertices[15].z + size.z);
        //up
        customVertices.vertices[16] = new(customVertices.vertices[16].x + invSize.x, customVertices.vertices[16].y, customVertices.vertices[16].z + size.z);
        customVertices.vertices[17] = new(customVertices.vertices[17].x + size.x, customVertices.vertices[17].y, customVertices.vertices[17].z + size.z);
        customVertices.vertices[18] = new(customVertices.vertices[18].x + invSize.x, customVertices.vertices[18].y, customVertices.vertices[18].z + invSize.z);
        customVertices.vertices[19] = new(customVertices.vertices[19].x + size.x, customVertices.vertices[19].y, customVertices.vertices[19].z + invSize.z);
        //down
        customVertices.vertices[20] = new(customVertices.vertices[20].x + invSize.x, customVertices.vertices[20].y, customVertices.vertices[20].z + invSize.z);
        customVertices.vertices[21] = new(customVertices.vertices[21].x + size.x, customVertices.vertices[21].y, customVertices.vertices[21].z + invSize.z);
        customVertices.vertices[22] = new(customVertices.vertices[22].x + invSize.x, customVertices.vertices[22].y, customVertices.vertices[22].z + size.z);
        customVertices.vertices[23] = new(customVertices.vertices[23].x + size.x, customVertices.vertices[23].y, customVertices.vertices[23].z + size.z);

        customUV.uv[16] = new(customUV.uv[16].x + invSize.x, customUV.uv[16].y + size.z);
        customUV.uv[17] = new(customUV.uv[17].x + size.x, customUV.uv[17].y + size.z);
        customUV.uv[18] = new(customUV.uv[18].x + invSize.x, customUV.uv[18].y + invSize.z);
        customUV.uv[19] = new(customUV.uv[19].x + size.x, customUV.uv[19].y + invSize.z);

        _mesh.vertices = customVertices.vertices;
        _mesh.uv = customUV.uv;
        _mesh.triangles = customTriangles.triangles;

        _mesh.Optimize();
        _mesh.RecalculateNormals();

        gameObject.GetComponent<MeshCollider>().sharedMesh = _mesh;

        if (_currentSize.x == 0 || _currentSize.z == 0)
            return true;

        return false;
    }
}
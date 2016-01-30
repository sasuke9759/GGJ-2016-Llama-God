// raycast light test - mgear - http://unitycoder.com/blog
// not much comments here, but all it does, shoots rays to every direction, and builds a 2D array of the hit points,
// then triangulate that 2d array to mesh..

#pragma strict

public var lightmeshholder:GameObject;

private var RaysToShoot:int=512; //64; 128; 1024; 
private var distance:int=15;
private var vertices : Vector3[];
private var vertices2d : Vector2[];
private var triangles : int[];
//private var vertices2 : Vector3[];
private var mesh : Mesh;

// texture grabber
private var texture:Texture2D;
private var screenwidth:int;
private var screenheight:int;
private var grab:int=0;


function Start () 
{
	screenwidth = Screen.width;
	screenheight = Screen.height;
	var texture = new Texture2D (screenwidth, screenheight, TextureFormat.RGB24, false);

	vertices = new Vector3[RaysToShoot];
	vertices2d = new Vector2[RaysToShoot];
	triangles = new int[RaysToShoot];
//	vertices2 = new Vector3[4];
	mesh= lightmeshholder.GetComponent(MeshFilter).mesh;

}

function Update () 
{

	// dont cast if not moved?
	// build prelook-array of hit points/pixels/areas?
	// skip duplicate hit points (compare previous)
	// always same amount of vertices, no need create new mesh?..but need to triangulate or not??

	var angle:float = 0;
	for (var i:int=0;i<RaysToShoot;i++)
	{
		var x = Mathf.Sin(angle);
		var y = Mathf.Cos(angle);
		angle += 2*Mathf.PI/RaysToShoot;
		
		var dir:Vector3 = Vector3(x,0,y);
		var hit : RaycastHit;
		if (Physics.Raycast (transform.position, dir, hit, distance)) 
		{
//			Debug.DrawLine (transform.position, hit.point, Color(1,1,0,1));
			
			/*
			// bounce ray, ignore last hit object?
			// reflect more than 1 ray?
			var dir2:Vector3 = Vector3.Reflect(dir, hit.normal);
			var hit2 : RaycastHit;
			if (Physics.Raycast (hit.point, dir2, hit2, distance/4)) 
			{
				Debug.DrawLine (hit.point, hit2.point, Color(1,0,0,1));
			}else{ // we might not hit anything, because of short bounce distance
				Debug.DrawRay (hit.point, dir2*(distance/4), Color(1,0,0,1));
			}
			*/
			
			var tmp = lightmeshholder.transform.InverseTransformPoint(hit.point);
			vertices2d[i] = Vector2(tmp.x,tmp.z);
			
			
		}else{ // no hit
//			Debug.DrawRay (transform.position, dir*distance, Color(1,1,0,1));

			var tmp2 = lightmeshholder.transform.InverseTransformPoint(lightmeshholder.transform.position+dir);
			vertices2d[i] = Vector2(tmp2.x,tmp2.z);


		}
	}

	// triangulate.cs
    var tr : Triangulator = new Triangulator(vertices2d);
    var indices : int[] = tr.Triangulate();
	
	// build mesh
    var uvs : Vector2[] = new Vector2[vertices2d.Length];
    var newvertices : Vector3[] = new Vector3[vertices2d.Length];
    for (var n : int = 0; n<newvertices.Length;n++) 
	{
        newvertices[n] = new Vector3(vertices2d[n].x, 0, vertices2d[n].y);

	// create some uv's for the mesh?
	// uvs[n] = vertices2d[n];
		
    }
   
    // Create the mesh
    //var msh : Mesh = new Mesh();
    mesh.vertices = newvertices;
    mesh.triangles = indices;
    mesh.uv = uvs;
	
//    mesh.RecalculateNormals(); // need?
//    mesh.RecalculateBounds(); // need ?

	// last triangles
//	triangles[i+1] = 0;
//	triangles[i+2] = 0;
//	triangles[i+1] = 0;

	//triangles.Reverse();

//	mesh.vertices = newvertices;
//	mesh.triangles = triangles;

	// not every frame? clear texture before take new shot?
//	if (grab>10) GrabToTexture();
//	grab++;

}

/*
function GrabToTexture()
{
	yield WaitForEndOfFrame ();
  	texture.ReadPixels(new Rect(0, 0, screenwidth, screenheight), 0, 0, false);
	texture.Apply();
	renderer.material.mainTexture = texture;
	grab=0;
}
*/
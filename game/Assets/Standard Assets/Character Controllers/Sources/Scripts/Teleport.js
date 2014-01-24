var desPos : Vector3;
var x;
var y;
var z;
//private var controller : CharacterController;
private var controller : ThirdPersonController;
private var rObject : GameObject;

// Use this for initialization
function Start () {
	//desPos = new Vector3(0,0,0);
	
}

// Update is called once per frame
function Update () {

}

function OnTriggerEnter(object : Collider){
	print ("I'm Hit again");
	var dx = desPos.x-object.transform.position.x;
	var dy = desPos.y-object.transform.position.y;
	var dz = desPos.z-object.transform.position.z;
	var dxa = -object.transform.eulerAngles.x;
	var dya = -object.transform.eulerAngles.y;
	var dza = -object.transform.eulerAngles.z;
	//var rotDes = new Vector3(dxa, dya, dza);
	moveDes = new Vector3(dx,dy,dz);
	object.transform.Rotate(dxa, dya, dza);
	object.transform.Translate(moveDes);
	object.transform.Rotate(-dxa, -dya, -dza);
	//object.transform.position.Set(1313, 116, 980);
	//print(object.transform.position.x);
	//object.collider.active = false;
	//object.Move(shift);
	//object.collider.active = true;
	//object.
}

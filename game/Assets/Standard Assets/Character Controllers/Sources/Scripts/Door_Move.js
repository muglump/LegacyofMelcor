var shift : Vector3 = Vector3.forward;
var tobject : GameObject;
//private var controller : CharacterController;
private var controller : ThirdPersonController;
private var rObject : GameObject;


// Use this for initialization
function Start () {
	//do nothing, wait for them to walk into you for punishing
}

// Update is called once per frame
function Update () {
/*
	if (collider.isTrigger == true) {
		print("the door was hit");
		if(collider.gameObject.GetInstanceID == controller.gameObject.getInstanceID){
			controller.Move(shift);
		}
		//print(controller.Move.collisionFlags);
	}
*/
}

function OnTriggerEnter(object : Collider){
	print (object.name);

	var dxa = -object.transform.eulerAngles.x;
	var dya = -object.transform.eulerAngles.y;
	var dza = -object.transform.eulerAngles.z;
	//var rotDes = new Vector3(dxa, dya, dza);
	object.transform.Rotate(dxa, dya, dza);
	object.transform.Translate(shift);
	object.transform.Rotate(-dxa, -dya, -dza);
	//object.collider.active = false;
	//object.Move(shift);
	//object.collider.active = true;
	//object.
}
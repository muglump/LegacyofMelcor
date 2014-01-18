var shift : Vector3 = Vector3.forward;
var tobject : GameObject;
//private var controller : CharacterController;
private var controller : ThirdPersonController;


// Use this for initialization
function Start () {
	collider.;
	shift = new Vector3(5, 0, 0);

	//do nothing, wait for them to walk into you for punishing
}

// Update is called once per frame
function Update () {
	if (collider.isTrigger == true) {
		print("the door was hit");
		if(collider.gameObject.GetInstanceID == controller.gameObject.getInstanceID){
			controller.Move(shift);
		}
		//print(controller.Move.collisionFlags);
	}
}

function OnTriggerEnter(object : Collider){
	tobject.SendMessage


}
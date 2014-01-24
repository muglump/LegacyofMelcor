var flag = false;
var enteree;
var x;
var y;
var z;
var vect = Vector3;
// Use this for initialization
function Start () {
}

// Update is called once per frame
function Update () {
	if (flag){
		var dx = transform.position.x-enteree.transform.position.x;
		var dy = transform.position.y-enteree.transform.position.y;
		var dz = transform.position.z-enteree.transform.position.z;
		if (Mathf.Abs(dx) > x){
			moveDes = new Vector3(-dx+x,0,0);
			transform.Translate(moveDes);
		}
		if (Mathf.Abs(dy) > y){
			moveDes = new Vector3(0,-dy+y,0);
			transform.Translate(moveDes);
		}
		if (Mathf.Abs(dz) > z){
			moveDes = new Vector3(0,0,-dz+z);
			transform.Translate(moveDes);
		}
		//moveDes = new Vector3(dx,dy,dz);
		//transform.Translate(moveDes);
	}
}

function OnTriggerEnter(object : Collider){
	flag = true; 
	enteree = object;
	x = transform.position.x - object.transform.position.x;
	y = transform.position.y - object.transform.position.y;
	z = transform.position.z - object.transform.position.z;

	print("Bad Decision");
}

function OnTriggerExit(object : Collider){
	
	print("Good Decision");
}


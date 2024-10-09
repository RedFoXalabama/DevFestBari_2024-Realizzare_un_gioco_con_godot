extends CharacterBody3D


var SPEED = 5.0
@export var JUMP_VELOCITY = 4.5
var ISRUNNING : bool = false
@export var RUNSPEED = 12
@export var WALKSPEED = 5
@onready var fox_mesh : Node3D = $FoxMesh
@onready var camera_mount : Node3D = $CameraMount
@onready var fox_collision : CollisionShape3D = $foxCollision
@onready var animation_player : AnimationPlayer = $FoxMesh/AnimationPlayer

func _ready() -> void:
	Input.mouse_mode = Input.MOUSE_MODE_CAPTURED

func _physics_process(delta: float) -> void:
	# Add Run
	if (Input.is_action_pressed("Run")):
		SPEED = RUNSPEED
		ISRUNNING = true
	else:
		SPEED = WALKSPEED
		ISRUNNING = false
	
	# Add the gravity.
	if not is_on_floor():
		velocity += get_gravity() * delta

	# Handle jump.
	if Input.is_action_just_pressed("ui_accept") and is_on_floor():
		if (animation_player.current_animation == "Gallop" && ISRUNNING):
			animation_player.play("Gallop_Jump")
		else:
			animation_player.play("Jump_ToIdle")
		velocity.y = JUMP_VELOCITY

	# Get the input direction and handle the movement/deceleration.
	# As good practice, you should replace UI actions with custom gameplay actions.
	var input_dir := Input.get_vector("ui_left", "ui_right", "ui_up", "ui_down")
	var direction := (transform.basis * Vector3(input_dir.x, 0, input_dir.y)).normalized()
	if direction:
		velocity.x = direction.x * SPEED
		velocity.z = direction.z * SPEED
		fox_mesh.look_at(position + direction)
		fox_collision.rotation = Vector3(fox_collision.rotation.x, fox_mesh.rotation.y, fox_collision.rotation.z)
		if (animation_player.current_animation != "Walk" || animation_player.current_animation != "Gallop"):
			if (ISRUNNING):
				animation_player.play("Gallop")
			else: 
				animation_player.play("Walk")
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
		velocity.z = move_toward(velocity.z, 0, SPEED)
		if (animation_player.current_animation != "Idle"  && animation_player.current_animation != "Jump_ToIdle"):
			animation_player.play("Idle")
		
	move_and_slide()

func _input(event: InputEvent) -> void:
	if (event.is_action_pressed("ui_cancel")): # libera il mouse
		Input.mouse_mode = Input.MOUSE_MODE_VISIBLE
		
	if (event is InputEventMouseButton): # cattura il mouse
		Input.mouse_mode = Input.MOUSE_MODE_CAPTURED
		
	if (event is InputEventMouseMotion):
		rotate_y(deg_to_rad(-event.relative.x) * 0.1) # movimento orizzontale
		camera_mount.rotate_x(deg_to_rad(-event.relative.y * 0.1)) # movimento verticale
		fox_mesh.rotate_y(deg_to_rad(event.relative.x * 0.1)) # rotazione mesh
		fox_collision.rotate_y(deg_to_rad(event.relative.x * 0.1)) # rotazione collisione, ruota in senso opposto al player
		camera_mount.rotation = Vector3(clamp(camera_mount.rotation.x, deg_to_rad(-45), deg_to_rad(45)), camera_mount.rotation.y, camera_mount.rotation.z) # clamp della rotazione verticale

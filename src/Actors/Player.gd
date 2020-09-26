extends Actor

func _physics_process(delta: float) -> void:
	var is_jump_interrupted: = Input.is_action_just_released("jump") and velocity.y < 0.0
	var direction: =  get_direction()
	velocity = calc_move_velocity(velocity, speed, direction, is_jump_interrupted)
	velocity = move_and_slide(velocity, FLOOR_NORMAL)

func get_direction() -> Vector2: 
	return Vector2(
		Input.get_action_strength("move_right") - Input.get_action_strength("move_left"),
	 -1.0 if Input.get_action_strength("jump") and is_on_floor() else 1.0)

func calc_move_velocity(
	linear_velocity: Vector2,
	speed: Vector2,
	direction: Vector2, 
	is_jump_interrupted: bool
	) -> Vector2: 
	var out: = linear_velocity
	out.x = speed.x * direction.x
	out.y += gravity * get_physics_process_delta_time()
	if direction.y == -1.0: 
		out.y = speed.y * direction.y
	if is_jump_interrupted:
		out.y = 0.0
	return out
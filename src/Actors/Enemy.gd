extends "res://src/Actors/Actor.gd"

func _ready() -> void:
	set_physics_process(false)
	velocity.x = -speed.x
	
func _on_StompDetector_body_entered(body: PhysicsBody2D) -> void:
	if body.global_position.y > get_node("StompDetector").global_position.y:
		return
	get_node("CollisionShape2D").disabled = true
	queue_free()
	
	
func _physics_process(delta: float) -> void:
	velocity.y += gravity * delta
	if is_on_wall(): 
		velocity.x *= -1
	velocity.y = move_and_slide(velocity, FLOOR_NORMAL).y




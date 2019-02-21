extends "res://scenes/characters/Character.gd"

var motion : Vector2 = Vector2();

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta : float):
	update_motion(delta);
	move_and_slide(motion);

func update_motion(delta : float):
	look_at(get_global_mouse_position());
	
	if Input.is_action_pressed("ui_up") and not Input.is_action_pressed("ui_down"):
		motion.y = clamp((motion.y - SPEED), - MAX_SPEED, 0);
	elif Input.is_action_pressed("ui_down") and not Input.is_action_pressed("ui_up"):
		motion.y = clamp((motion.y + SPEED), MAX_SPEED, 0);
	else:
		motion.y = lerp(motion.y, 0, FRICTION);
		
	if Input.is_action_pressed("ui_left") and not Input.is_action_pressed("ui_right"):
		motion.x = clamp((motion.x - SPEED), - MAX_SPEED, 0);
	elif Input.is_action_pressed("ui_right") and not Input.is_action_pressed("ui_left"):
		motion.x = clamp((motion.x + SPEED), MAX_SPEED, 0);
	else:
		motion.x = lerp(motion.x, 0, FRICTION);
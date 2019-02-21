extends Character

# Declare member variables here. Examples:
# var a = 2
# var b = "text"
Vector2 MOTION = Vector2();

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	update_motion(delta);
	move_and_slide(MOTION);

func update_motion(float delta):
	if input.is_action_pressed:
		print("up");

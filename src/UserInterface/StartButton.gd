tool
extends Button

export(String, FILE) var next_schene_path: = ""

func _on_button_up() -> void:
	get_tree().change_scene(next_schene_path)

func _get_configuration_warning() -> String:
	return "nex_scene_path muss gesetzt sein" if next_schene_path == "" else ""

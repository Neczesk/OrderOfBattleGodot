using Godot;
using System;

public partial class app : Node
{
	private bool IsSideBarOpen = false;
	private enum Modes{
		oob,
		ruleset
	}
	private app.Modes Mode = Modes.oob;
	private RSMenu rsMain;
	private ruleset_editor rsEdit;
	private LSMenu lsMain;
	private baseWindow currentDisplay;
	private HBoxContainer MainWindow;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PackedScene s = GD.Load<PackedScene>("res://RSMenu.tscn");
		PackedScene l = GD.Load<PackedScene>("res://LSMenu.tscn");
		PackedScene r = GD.Load<PackedScene>("res://ruleset_editor.tscn");
		rsMain = (RSMenu)s.Instantiate();
		lsMain = (LSMenu)l.Instantiate();
		rsEdit = (ruleset_editor)r.Instantiate();
		currentDisplay = (baseWindow)GetNode("UI/VBoxContainer/Window/MainDisplay");
		MainWindow = (HBoxContainer)GetNode("UI/VBoxContainer/Window");
		int pos = currentDisplay.GetIndex();
		MainWindow.RemoveChild(currentDisplay);
		MainWindow.AddChild(lsMain);
		MainWindow.MoveChild(lsMain, pos);
		currentDisplay = lsMain;
	}
	

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OpenSideBar(){
		AnimationPlayer sidebar_player = (AnimationPlayer)GetNode("SideBar");
		sidebar_player.Play("sidebar");
		IsSideBarOpen = true;
	}

	private void CloseSideBar(){
		AnimationPlayer sidebar_player = (AnimationPlayer)GetNode("SideBar");
		sidebar_player.PlayBackwards("sidebar");
		IsSideBarOpen = false;
	}

	public void OnMenuPressed(){
		if (!IsSideBarOpen){
			OpenSideBar();
		} else {
			CloseSideBar();
		}
			
	}

	public void OnChangePressed(){
		Label modeLabel = (Label)GetNode("UI/VBoxContainer/Bar/Panel/HBoxContainer/MarginContainer2/HBoxContainer/CenterContainer2/ModeTitle");
		if (Mode == Modes.oob){
			Mode = Modes.ruleset;
			modeLabel.Text = "Ruleset Editor";
			changeWindow(rsMain);
		}
		else if (Mode == Modes.ruleset) {
			Mode = Modes.oob;
			modeLabel.Text = "List Editor";
			changeWindow(lsMain);
		}
	}

	public void OnAddPressed(){
		if (Mode == Modes.ruleset){
			if (currentDisplay == rsMain){
				changeWindow(rsEdit);
			}
		}
		else if (Mode == Modes.oob){

		}
	}

	private void changeWindow(baseWindow newWindow){
		int pos = currentDisplay.GetIndex();
		MainWindow.RemoveChild(currentDisplay);
		MainWindow.AddChild(newWindow);
		MainWindow.MoveChild(newWindow, pos);
		currentDisplay = newWindow;
	}
}


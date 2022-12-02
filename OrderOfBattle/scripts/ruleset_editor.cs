using Godot;
using System;

public partial class ruleset_editor : baseWindow
{
	private enum Modes{
		newRuleset,
		editingRules
	}
	private Modes mode = Modes.newRuleset;
	private LineEdit gameName;
	private LineEdit gameVersion;
	private LineEdit fileAuthor;
	private LineEdit gameRootCat;
	private TextEdit gameDesc;
	private LineEdit gameAuthor;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gameName = GetNode<LineEdit>("VBoxContainer/VBoxContainer/Metadata/VBoxContainer/MarginContainer/VBoxContainer/GridContainer/GameName/LineEdit");
		gameVersion = GetNode<LineEdit>("VBoxContainer/VBoxContainer/Metadata/VBoxContainer/MarginContainer/VBoxContainer/GridContainer/Version/LineEdit");
		fileAuthor = GetNode<LineEdit>("VBoxContainer/VBoxContainer/Metadata/VBoxContainer/MarginContainer/VBoxContainer/GridContainer/Author/LineEdit");
		gameRootCat = GetNode<LineEdit>("VBoxContainer/VBoxContainer/Metadata/VBoxContainer/MarginContainer/VBoxContainer/GridContainer/RootCategory/LineEdit");
		gameDesc = GetNode<TextEdit>("VBoxContainer/VBoxContainer/Metadata/VBoxContainer/MarginContainer/VBoxContainer/Description/LineEdit");
		gameAuthor = GetNode<LineEdit>("VBoxContainer/VBoxContainer/Metadata/VBoxContainer/MarginContainer/VBoxContainer/GridContainer/GameAuthor/LineEdit");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private bool validateMetadata(){
		string name = gameName.Text;
		string version = gameVersion.Text;
		string author = fileAuthor.Text;
		string rootcat = gameRootCat.Text;
		string desc = gameDesc.Text;
		string gAuthor = gameAuthor.Text;
		if (name.Length < 2){
			return false;
		}
		if (version.Length < 5){
			return false;
		}
		if (author.Length < 2){
			return false;
		}
		if (rootcat.Length < 2){
			return false;
		}
		if (desc.Length < 2){
			return false;
		}
		if (gAuthor.Length < 2){
			return false;
		}
		return true;
	}

	public void OnMetadataChanged(String _newText){
		if (validateMetadata()){
			GD.Print("valid");
			Button addbutton = GetNode<Button>("VBoxContainer/VBoxContainer/Metadata/VBoxContainer/AddButton");
			addbutton.Disabled = false;
		}
	}
	public void OnRuleSetSubmit(){
		string name = gameName.Text;
		string version = gameVersion.Text;
		string author = fileAuthor.Text;
		string rootcat = gameRootCat.Text;
		string desc = gameDesc.Text;
		string gAuthor = gameAuthor.Text;
		if (validateMetadata()){
			Model.Ruleset newRules = new Model.Ruleset(name, gAuthor, author, desc, rootcat, version);
			GD.Print(newRules);
		}
	}
}

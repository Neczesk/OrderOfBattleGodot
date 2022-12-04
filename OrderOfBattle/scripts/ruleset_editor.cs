using Godot;
using System;
using OrderOfBattle.Model.Ruleset;
using Newtonsoft.Json;

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
	private bool isMetadataFolded = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gameName = GetNode<LineEdit>("VBoxContainer/VBoxContainer/Metadata/VBoxContainer/Metadata/VBoxContainer/GridContainer/GameName/LineEdit");
		gameVersion = GetNode<LineEdit>("VBoxContainer/VBoxContainer/Metadata/VBoxContainer/Metadata/VBoxContainer/GridContainer/Version/LineEdit");
		fileAuthor = GetNode<LineEdit>("VBoxContainer/VBoxContainer/Metadata/VBoxContainer/Metadata/VBoxContainer/GridContainer/Author/LineEdit");
		gameRootCat = GetNode<LineEdit>("VBoxContainer/VBoxContainer/Metadata/VBoxContainer/Metadata/VBoxContainer/GridContainer/RootCategory/LineEdit");
		gameDesc = GetNode<TextEdit>("VBoxContainer/VBoxContainer/Metadata/VBoxContainer/Metadata/VBoxContainer/Description/LineEdit");
		gameAuthor = GetNode<LineEdit>("VBoxContainer/VBoxContainer/Metadata/VBoxContainer/Metadata/VBoxContainer/GridContainer/GameAuthor/LineEdit");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetEditedRuleset(Ruleset er){
		gameName.Text = er.GameName;
		gameVersion.Text = er.Version.ToString();
		fileAuthor.Text = er.FileAuthor;
		gameRootCat.Text = er.RootName;
		gameDesc.Text = er.GameDesc;
		gameAuthor.Text = er.GameAuthor;
		GetNode<Button>("VBoxContainer/VBoxContainer/Metadata/VBoxContainer/AddButton").Visible = false;
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
			Ruleset newRules = new Ruleset(name, gAuthor, author, desc, rootcat, version);
			GD.Print(newRules.Version);
			string temp = newRules.ToJson();
			GD.Print(temp);
			Ruleset loadedRules = JsonConvert.DeserializeObject<Ruleset>(newRules.ToJson());
			SetEditedRuleset(loadedRules);
		}
	}

	public void OnMetadataFold(){
		isMetadataFolded = !isMetadataFolded;
		if (isMetadataFolded){
			GetNode<MarginContainer>("VBoxContainer/VBoxContainer/Metadata/VBoxContainer/MarginContainer").Visible = false;
		} else {
			GetNode<MarginContainer>("VBoxContainer/VBoxContainer/Metadata/VBoxContainer/MarginContainer").Visible = true;
		}
	}
}

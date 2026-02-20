using Godot;
using System;

public partial class GalleryManager : Control
{
    private TextureRect _galleryImage;
    private RichTextLabel _imageLabel;
    private AnimationPlayer _animPlayer;
    private int _currentIndex = 0;

    // Populate these in the editor
    [Export] private string _nextScenePath = "res://scenes/MasterScene.tscn";
    [Export] private Godot.Collections.Array<Texture2D> _images;
    [Export] private Godot.Collections.Array<string> _descriptions;

    public override void _Ready()
    {
        _galleryImage = GetNode<TextureRect>("GalleryImage");
        _imageLabel = GetNode<RichTextLabel>("ImageLabel");
        _animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        UpdateGallery();
    }

    public override void _Input(InputEvent @event)
    {
        // Detect mouse click
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
        {
            NextImage();
        }
    }

    private void NextImage()
    {
        // last index
        if (_currentIndex == _images.Count - 1)
        {
            // go to the game
            GetTree().ChangeSceneToFile(_nextScenePath);
        }

        if (_images == null || _images.Count == 0) return;

        _currentIndex = (_currentIndex + 1) % _images.Count;
        UpdateGallery();
    }

    private void UpdateGallery()
    {
        if (_images != null && _currentIndex < _images.Count)
        {
            _galleryImage.Texture = _images[_currentIndex];
            _imageLabel.Text = _descriptions[_currentIndex];
            _animPlayer.Play("TypewriterEffect");
        }
    }
}

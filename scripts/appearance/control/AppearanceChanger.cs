using Godot;

namespace Project.Appearance.Control
{
    public partial class AppearanceChanger : Node, IAppearanceChanger
    {
        [Export] private CsgMesh3D _visuals;
        private float redGreenAmount = 0f;

        private StandardMaterial3D mat = new StandardMaterial3D
        {
            AlbedoColor = new Color(1, 1, 1)
        };

        public override void _Ready()
        {
            _visuals.Material = mat;
        }

        public void ChangeColor(Color color)
        {
            mat.AlbedoColor = color;
        }
    }
}
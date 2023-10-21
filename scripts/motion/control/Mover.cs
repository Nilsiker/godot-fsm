using Godot;
using Project.Motion;

namespace Project.Systems.Control {
    [GlobalClass]
    public partial class Mover : Node, IMover
    {
        [Export] RigidBody3D rigidbody;
        [Export] float forceMultiplier = 20;

        public void Move(Vector2 velocity)
        {
            Vector3 force = new(velocity.X, 0f, velocity.Y);
            rigidbody.ApplyForce(force * forceMultiplier);
        }
    }
}

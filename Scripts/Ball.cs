using Godot;
using System;
using System.Runtime.Serialization;
 
public partial class Ball : RigidBody2D
{
    [Export]
    float DefaultSpeed = 10f;
    [Export]
    RichTextLabel opponentScore;
    [Export]
    RichTextLabel playerScore;
    [Export]
    AudioStreamPlayer BallAudio;

    [Export] float SpeedIncreaseInterval;
    [Export] float SpeedIncrement;
    [Export] float SpeedCap;
    
    float currentTime;
 
    public override void _Ready()
    {
        LinearVelocity = new Godot.Vector2(-1, 1) * DefaultSpeed;
        currentTime=0;
    }
 
    void updateTimer(float del)
    {
        currentTime+=del;
    }
 
    void SpeedUp()
    {
        if(currentTime>SpeedIncreaseInterval)
        {
            DefaultSpeed+=SpeedIncrement;
            GD.Print("Speed Up! DefaultSpeed =" + DefaultSpeed.ToString());
            LinearVelocity = LinearVelocity.Normalized() * DefaultSpeed;
            currentTime=0;
        }
    }
 
    public override void _Process(double delta)
    {
        updateTimer((float)delta);
        if(DefaultSpeed<SpeedCap)
        SpeedUp();
    }
 
    public void OnBallHit(Area2D area)
    {
        BallAudio.Play();
    }
}
 
# Deep Racer Notes

Amazon Deep Racer is a managed automous driving simulator that simplifies testing racing algorithms.

## Table of Contents

- [Reward Functions](RewardFunctions) - Reward Functions used by the various trials.
- [Trials and Results](Trials) - Notes and results from evaluting the reward functions.
- [Minimum Curved Path](EfficientPath) - A physics based approach to approximate the `race line`.

## What parameters are available to the vehicle

```text
{
    "all_wheels_on_track": Boolean,    # flag to indicate if the vehicle is on the track
    "x": float,                        # vehicle's x-coordinate in meters
    "y": float,                        # vehicle's y-coordinate in meters
    "distance_from_center": float,     # distance in meters from the track center
    "is_left_of_center": Boolean,      # Flag to indicate if the vehicle is on the left side to the track center or not.
    "heading": float,                  # vehicle's yaw in degrees
    "progress": float,                 # percentage of track completed
    "steps": int,                      # number steps completed
    "speed": float,                    # vehicle's speed in meters per second (m/s)
    "steering_angle": float,           # vehicle's steering angle in degrees
    "track_width": float,              # width of the track
    "waypoints": [[float, float], … ], # list of [x,y] as milestones along the track center
    "closest_waypoints": [int, int]    # indices of the two nearest waypoints.
}
```

### How can we use these in rewards function

* The `speed` is between 0 and 8 mps; there could be a bonus of `speed/MAX_SPEED`

* The `all_wheels_on_track` should become a large penalty when that occurs

* The `stearing_angle` could be penalized if over stearing (maybe ratio)

* The `closest_waypoint` is (x,y) location of next objective if the car is not pointed in that general direction then reduce points.

* The `angle and speed` as tuple will be important for keeping on the road

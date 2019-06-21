# Simulator Trials

## MoqOne

The first attempt failed due to an agent process crash.

![moq1.png](moq1.png)

## Moq2

The next attempt used all defaults and trained for `1 hour`

- Max Speed: 1 mps
- Script: [HelloWorld](HelloWorld.py)
- Granularity : 2 speeds
- Action Space : 10 choices
- Best Lap: `1:06.7`

![moq2.png](moq2.png)

## MoqFast

The next attempt was trained for `1 hours`

- Max Speed: 6mph
- Script: [HelloWorld](HelloWorld.py)
- Granularity: 3 speeds
- Angles: 7
- Action Space: 20

This would take a long time to converge but did provide new insights.

The biggest challenge was accelerating around corners and off the track. This would suggest that we need to account for the tuple `(steering_angle, max_speed)`.

## Moq3

This is a clone of Moq2 with `1 hour training`

It uses the [Moq3.py](Moq3.py) script to give a combined score of `near_center * has_correct_heading`.

The theory is that this will become the foundation for addition additional properties.

## Moq3-faster

This is a new job that uses the [Moq3.py](Moq3.py) script and speeds between 1-2mps.

It is also using max `speed=2` and changing the course to `kumo torakku` the next world cup.
